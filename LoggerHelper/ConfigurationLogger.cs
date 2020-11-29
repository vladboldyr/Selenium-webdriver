using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Config;
using NLog;
using NLog.Targets;

namespace LoggerHelper
{
  public static class ConfigurationLogger
  {
    public static ILoggerFactory CreateLoggerFactory()
    {
      return LoggerFactory.Create(builder =>
      {
        builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
        builder.AddNLog(InitialConfigurationLogManager(_pathToFileInit));
      });
    }

    public static void ChangeConfigurationLogManager(string pathFile)
    {
      pathFileLevelInfoLog = pathFile;
      pathFileLevelDebugAndErrorLog = "TimeWork" + pathFile;
      var configuration = new LoggingConfiguration();
      var logfile = new FileTarget("logfile") { FileName = pathFileLevelInfoLog };
      logfile.KeepFileOpen = true;
      logfile.AutoFlush = false;
      var logfileTimeWork = new FileTarget("logfileTimeWork") { FileName = pathFileLevelDebugAndErrorLog };
      logfileTimeWork.KeepFileOpen = true;
      logfileTimeWork.AutoFlush = false;
      var bufferingWrapper = new NLog.Targets.Wrappers.BufferingTargetWrapper(logfile) { Name = "bufferingWrapper" };
      var bufferingWrapperTime = new NLog.Targets.Wrappers.BufferingTargetWrapper(logfileTimeWork) { Name = "bufferingWrapperTime" };

      configuration.AddRuleForOneLevel(NLog.LogLevel.Info, bufferingWrapper);
      configuration.AddRuleForOneLevel(NLog.LogLevel.Error, bufferingWrapperTime);
      configuration.AddRuleForOneLevel(NLog.LogLevel.Debug, bufferingWrapperTime);
      
      LogManager.Configuration = configuration;
      LogManager.Configuration?.Reload();
      LogManager.ReconfigExistingLoggers();
    }

    private static LoggingConfiguration InitialConfigurationLogManager(string nameFile)
    {
      var configuration = new LoggingConfiguration();
      var logfile = new FileTarget("logfile") { FileName = nameFile };
      var bufferingWrapper = new NLog.Targets.Wrappers.BufferingTargetWrapper(logfile) { Name = "bufferingWrapper" };
      configuration.AddRuleForAllLevels(bufferingWrapper);

      return configuration;
    }

    /// <summary>
    /// Путь до файла с логами уровня Info,который прикрепится к результату теста
    /// </summary>
    public static string pathFileLevelInfoLog { get; set; }
    /// <summary>
    /// Путь до файла с логами уровня Debug & Error,который прикрепится к результату теста
    /// </summary>
    public static string pathFileLevelDebugAndErrorLog { get; set; }
    /// <summary>
    /// File for init log
    /// </summary>
    private static string _pathToFileInit = "FileLogsTests.txt";
  }
}
