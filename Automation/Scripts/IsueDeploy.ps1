param (
    [string]$siteName,
    [string]$webDeployCmd,
    [string]$serviceName,
    [string]$productId,
    [string]$serviceProcessName,
    [string]$installerPath,
    [string]$defaultWorkingDirectory
)

$currentUser = New-Object Security.Principal.WindowsPrincipal $([Security.Principal.WindowsIdentity]::GetCurrent())
$testadmin = $currentUser.IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)
if ($testadmin -eq $false) {
Write-Error "Агент должен быть запущен с правами администратора!!!"
exit 1
#Start-Process powershell.exe -Verb RunAs -ArgumentList ('-noprofile -noexit -file "{0}" -elevated' -f ($myinvocation.MyCommand.Definition))
#exit $LASTEXITCODE
}

Write-Host "Verbose mode: $global:VerbosePreference"

Write-Host "Searching sevice with name ${serviceName} and stopping it..."

try {
If (Get-Service $serviceName -ErrorAction Ignore) {
    If ((Get-Service $serviceName).Status -eq 'Running') {
        Stop-Service $serviceName
        Write-Host "Stopping $serviceName"
    } Else {
        Write-Host "$serviceName found, but it is not running."
    }

} Else {
    Write-Host "$serviceName not found"
}
}
catch {
  $Error.Clear()
}

try {
Stop-Service MirServiceDiagnostics
}
catch {
  $Error.Clear()
}

try {
Stop-Service MirOpcCoreService
}
catch {
  $Error.Clear()
}

try {
Stop-Service MirJournalService
}
catch {
  $Error.Clear()
}

try {
Stop-Service AuthSrv
}
catch {
  $Error.Clear()
}
 
Write-Host "If process is still running - killing it..."
Get-Process $serviceProcessName -ErrorAction Ignore | Stop-Process -PassThru -Force

Get-Process Mir.Swift.Wpf -ErrorAction Ignore | Stop-Process -PassThru -Force
Get-Process Mir.Journal.Viewer -ErrorAction Ignore | Stop-Process -PassThru -Force
Get-Process goldenway -ErrorAction Ignore | Stop-Process -PassThru -Force
Get-Process Mir.OPC.Connector -ErrorAction Ignore | Stop-Process -PassThru -Force

Import-Module WebAdministration -Verbose:$false

Write-Host $siteName
Write-Host $serviceName
Write-Host $productId
Write-Host $installerPath
Write-Host $webDeployCmd
Write-Host $defaultWorkingDirectory


try{
  Write-Host "Stopping web site $siteName..."
  $siteState = Stop-WebSite "$siteName" -PassThru
  while ($siteState.State -ne "Stopped")
  {
    Write-Host "Waiting for stopping site..."
    Start-Sleep -s 5
  }
}
catch {
  $Error.Clear()
}
Write-Host "Site $siteName stopped"

try {
  Write-Host "Stopping web app pool DefaultAppPool..."
  $poolState = Stop-WebAppPool "DefaultAppPool"-PassThru
  while ($poolState.State -ne "Stopped")
  {
    Write-Host "Waiting for stopping app pool..."
    Start-Sleep -s 5
  }
}
catch {
  $Error.Clear()
}
Write-Host "Pool stopped"

Write-Host "Run web deploy script..."

#Start-Process -FilePath c:\Deploy\scada_web.deploy.cmd -ArgumentList '/Y', '-setParamFile:c:\Deploy\Sunrise2ToLab09Deploy.SetParameters.xml' -Wait
if(!$webDeployCmd) {
  $webDeployCmd = "scada_web"
}
#$exe = "c:\Deploy\${webDeployCmd}.deploy.cmd"
$exe = "${defaultWorkingDirectory}\web\Scada.Web\${webDeployCmd}.deploy.cmd"
&$exe "/Y" | Write-Host

Write-Host "Starting web app pool DefaultAppPool..."
Start-WebAppPool "DefaultAppPool"
Write-Host "Web app pool DefaultAppPool started"

Write-Host "Starting  web site $siteName..."
Start-WebSite "$siteName"
Write-Host "Site $siteName started"

$sitePatch =  Get-WebFilePath "IIS:\Sites\$siteName"

Write-Output "Redirect to maintenance page and stop the site"
New-Item -Path $sitePatch -Name "App_offline.htm" -ItemType "file" -Value '<!DOCTYPE html>
 <html>
 <head>
     <meta charset="utf-8" />
     <title></title>
     <style>
         h1 {
             font-size: 36px;
             margin: 0;
             font-family: Open Sans,sans-serif;
             color: #3b4151;
         }

         body {
             font-family: Open Sans,sans-serif;
             color: #3b4151;
         }
     </style>
 </head>
 <body>
     <h1>Это приложение находится на обслуживании</h1>
     <p>Пожалуйста попробуйте ещё раз через несколько минут.</p>
 </body>
 </html>'


Write-Host "Searching product by name mask '${productId}%'..."
$prod = Get-WmiObject -Class Win32_Product -filter "Name like '${productId}%' or IdentifyingNumber like '${productId}%'" 
if ($prod)
{
  Write-Host "The product is found, uninstalling it..."
  $prod.uninstall()
}

Write-Host "Starting product installer: ${installerPath}"
Start-Process "msiexec" -ArgumentList "/i ${installerPath} /q /passive" -Wait #-ErrorAction Ignore
Write-Host "Product are installed."

try {
Start-Service AuthSrv
}
catch {
  $Error.Clear()
}

try {
Start-Service MirOpcCoreService
}
catch {
  $Error.Clear()
}

try{
  cd "C:\Program Files (x86)\MIR\Goldenway\"
  Start-Process "C:\Program Files (x86)\MIR\Goldenway\Goldenway.exe" -WorkingDirectory "C:\Program Files (x86)\MIR\Goldenway\" -ErrorAction Ignore
}
catch{
  $Error.Clear()
}

try{
  cd "C:\Program Files\MIR\Goldenway\"
  Start-Process "C:\Program Files\MIR\Goldenway\Goldenway.exe" -WorkingDirectory "C:\Program Files\MIR\Goldenway\" -ErrorAction Ignore
}
catch{
  $Error.Clear();
}

Remove-Item -Path $sitePatch\App_offline.htm
