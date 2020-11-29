using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Mir.AutoTests.TestEngine.TestExec;
using Mir.AutoTests.TestEngine.Finder;
using Scada3Tests.ElementsContext;
using Mir.AutoTests.TestEngine.Interfaces;
using System.IO;
using Microsoft.Extensions.Logging;
using LoggerHelper;
using OpenQA.Selenium.Interactions;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Scada3Tests
{
  [TestFixture]
  public class SmokeTests
  {
    public SmokeTests()
    {
      IConfig config = new XmlConfigReader();
      ChromeOptions options = new ChromeOptions();
      options.SetLoggingPreference(LogType.Browser, OpenQA.Selenium.LogLevel.Warning);
      _driver = new ChromeDriver(options);
      _lsClear = _driver as IJavaScriptExecutor;
      _javaScript = _driver as IJavaScriptExecutor;
      _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
      _openSunrisePageWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(300));

      _elementFinder = new ElementFinder(Scada3FinderContext.ElementsContext, _wait);
      _testExecutor = new TestExecutor(_driver, _elementFinder, Assembly.LoggerFactory);

      _addressSunrise = config.GetUrl();
      _loginForAuthorization = config.GetLogin();
      _passwordForAuthorization = config.GetPassword();

      _logger = Assembly.LoggerFactory.CreateLogger<SmokeTests>();

    }

    /// <summary>
    /// Инициализация тестов
    /// </summary>
    [OneTimeSetUp]
    public void Setup()
    {
      _driver.Manage().Window.Maximize();
      LoginSunrise();
    }

    [OneTimeTearDown]
    public void Quit()
    {
      _driver.Quit();
    }

    [Test]
    public void Test001MenuCheck()
    {
      string nameTest = nameof(Test001MenuCheck);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        ctx.ElementFinder.FindElement(Scada3FinderContext.MenuButtonMirBurgerScada3);
        ctx.ElementFinder.FindElement(Scada3FinderContext.MainPageTabScada3);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabScada3);
        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        ctx.ElementFinder.FindElement(Scada3FinderContext.PowerSystemTabScada3);
        ctx.ElementFinder.FindElement(Scada3FinderContext.ScenariosTabScada3);
        ctx.ElementFinder.FindElement(Scada3FinderContext.ConnectionTabScada3);
        Thread.Sleep(100);
        Assert.Pass();
      }, null, null);
    }

    [Test]
    public void Test002MainTabCheck()
    {
      string nameTest = nameof(Test002MainTabCheck);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var mainPageTab = ctx.ElementFinder.FindElement(Scada3FinderContext.MainPageTabScada3);
        mainPageTab.Click();
        Thread.Sleep(100);
        ctx.ElementFinder.FindElement(Scada3FinderContext.MainPageTabScada3);
        ctx.ElementFinder.FindElement(Scada3FinderContext.MainPageTabScada3Hello);
        Assert.Pass();
      }, null, null);
    }

    [Test]
    public void Test003SchemeEditorTabCheck()
    {
      string nameTest = nameof(Test003SchemeEditorTabCheck);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabScada3);
        schemeEditorTab.Click();
        Thread.Sleep(100);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabToolbar);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabSchemes);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabElements);
        Assert.Pass();
      }, null, null);
    }

    [Test]
    public void Test004ComponentsEditorTabCheck()
    {
      string nameTest = nameof(Test004ComponentsEditorTabCheck);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        schemeEditorTab.Click();
        Thread.Sleep(100);
        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabToolbar);
        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabComponents);
        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabProperties);
        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabPrimitives);
        Assert.Pass();
      }, null, null);
    }

    [Test]
    public void Test005PowerSystemTabCheck()
    {
      string nameTest = nameof(Test005PowerSystemTabCheck);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.PowerSystemTabScada3);
        schemeEditorTab.Click();
        Thread.Sleep(100);
        ctx.ElementFinder.FindElement(Scada3FinderContext.PowerSystemTabPoster);
        Assert.Pass();
      }, null, null);
    }

    [Test]
    public void Test006ComponentsEditorTabCheckOpenFirstComponent()
    {
      string nameTest = nameof(Test006ComponentsEditorTabCheckOpenFirstComponent);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        schemeEditorTab.Click();
        var treeComponents = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorTreeComponents);
        var node = ctx.ElementFinder.FindElement(treeComponents, Scada3FinderContext.NodeTreeComponents);
        var nameComponent = node.Text;
        node.Click();
        ctx.Actions.ContextClick(node).Perform();
        ctx.ElementFinder.FindElement(Scada3FinderContext.NodeTreeComponentsBtnOpenComponent).Click();
        var nameOpenComponent = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorFirstOpenComponent).Text.Substring(0,nameComponent.Length);
        Assert.AreEqual(nameComponent, nameOpenComponent);
      }, null, null);
    }

    [Test]
    public void Test008SchemeEditorTabSTCheck()
    {
      string nameTest = nameof(Test008SchemeEditorTabSTCheck);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabScada3);
        schemeEditorTab.Click();
        Thread.Sleep(100);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabSchemes);
        var schemeEditorTabElements = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabElements);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabLibrary);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabLayers);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabHistory);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabGraphics);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabModel);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabTelemechanics);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabSimulator);
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabTestFolder);
        //var schemeEditorTabSchemesArrow = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabSchemesArrow);
        //schemeEditorTabSchemesArrow.Click();
        var schemeEditorTabFirstFolder = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabFirstFolder);
        schemeEditorTabFirstFolder.Click();
        ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabTestScheme);
        schemeEditorTabElements.Click();
        //ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabElemTree);
        Assert.Pass();
      }, null, null);
    }

    [Test]
    public void Test007SchemeEditorPropertiesCheck()
    {
      string nameTest = nameof(Test007SchemeEditorPropertiesCheck);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabScada3);
        schemeEditorTab.Click();
        Thread.Sleep(100);
        var schemeEditorTabScheme = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabSchemes);
        schemeEditorTabScheme.Click();
        var schemeEditorTabFirstFolder = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabFirstFolder);
        schemeEditorTabFirstFolder.Click();//открыть первую папку
        //var schemeEditorTabSchemesArrow = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabSchemesArrow);
        //schemeEditorTabSchemesArrow.Click();
        var schemeEditorTabAutotestScheme = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabTestScheme);
        ctx.Actions.ContextClick(schemeEditorTabAutotestScheme).Perform();
        var schemeEditorTabOpenScheme = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabOpenScheme);
        schemeEditorTabOpenScheme.Click();

        var schemeEditorProperties = ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabProperties);
        schemeEditorProperties.Click();
        //ctx.ElementFinder.FindElement(Scada3FinderContext.SchemeEditorTabCanvasProperties);
        Assert.Pass();
      }, null, null);
    }

    [Test]
    public void Test009EditorComponentAddNewComponent()
    {
      string nameTestComponent = "TestComponent";
      string nameTest = nameof(Test009EditorComponentAddNewComponent);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        schemeEditorTab.Click();

        var treeComponents = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorTreeComponents);
        var childNodes = ctx.ElementFinder.FindElements(treeComponents, Scada3FinderContext.NodeTreeComponents);
        var requiredNode = childNodes?.Where(elem => elem.Text.Equals(nameTestComponent))?.ToArray();

        //Если такой элемент есть в списке,тогда удаляем
        if (requiredNode != null && requiredNode.Any())
        {
          clearListComponent(ctx, nameTestComponent);
        }

        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponenEditorBtnAddNewComponent).Click();
 
        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorInputNameNewComponent).SendKeys(nameTestComponent);
        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorBtnCreateInModalWindow).Click();

        childNodes = ctx.ElementFinder.FindElements(treeComponents, Scada3FinderContext.NodeTreeComponents);
        requiredNode = childNodes?.Where(elem => elem.Text.Equals(nameTestComponent))?.ToArray();
        var nameCreatedComponent = requiredNode[0].Text;
        Assert.AreEqual(nameTestComponent, nameCreatedComponent);
      }, null, (ctx) => clearListComponent(ctx, nameTestComponent));
    }

    [Test]
    public void Test010EditorComponentDelComponent()
    {
      string nameTest = nameof(Test010EditorComponentDelComponent);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        schemeEditorTab.Click();

        string nameTestComponent = "TestComponent";
        var treeComponents = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorTreeComponents);
        var childNodes = ctx.ElementFinder.FindElements(treeComponents, Scada3FinderContext.NodeTreeComponents);
        var requiredNode = childNodes?.Where(elem => elem.Text.Equals(nameTestComponent))?.ToArray();
        if (requiredNode == null || !requiredNode.Any())
        {
          //Если такого элемента нету в списке,тогда создаем
          var btnPlus = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponenEditorBtnAddNewComponent);
          btnPlus.Click();

          ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorInputNameNewComponent).SendKeys(nameTestComponent);
          ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorBtnCreateInModalWindow).Click();
        }

        childNodes = ctx.ElementFinder.FindElements(treeComponents, Scada3FinderContext.NodeTreeComponents);
        requiredNode = childNodes?.Where(elem => elem.Text.Equals(nameTestComponent))?.ToArray();
        requiredNode[0].Click();
        var btnDelete = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponenEditorBtnDeleteComponent);
        btnDelete.Click();

        Actions builder = new Actions(_driver);
        builder.SendKeys(Keys.Enter).Build().Perform();

        Assert.Pass();
      }, null, null);
    }

    [Test]
    public void Test011EditorComponentRenameComponent()
    {
      string nameTestComponent = "TestComponent";
      string nameTest = nameof(Test011EditorComponentRenameComponent);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        schemeEditorTab.Click();

        var btnPlus = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponenEditorBtnAddNewComponent);
        btnPlus.Click();

        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorInputNameNewComponent).SendKeys(nameTestComponent);
        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorBtnCreateInModalWindow).Click();

        var treeComponents = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorTreeComponents);
        var childNodes = ctx.ElementFinder.FindElements(treeComponents, Scada3FinderContext.NodeTreeComponents);
        _logger.LogInformation("Поиск ноды в дереве");
        var requiredNode = childNodes?.Where(elem => elem.Text.Equals(nameTestComponent))?.ToArray();
        _logger.LogInformation("Нашли ноду в дереве");
        requiredNode[0].Click();
     
        _logger.LogInformation("Нажали ноду в дереве");

        var btnRename = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponenEditorBtnRenameComponent);
        btnRename.Click();

        nameTestComponent = nameTestComponent + "Rename";
        var input = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorInputNameNewComponent);
        input.Clear();
        input.SendKeys(nameTestComponent);

        _logger.LogInformation("Переименовали ноду в дереве");

        Actions builder = new Actions(_driver);
        builder.SendKeys(Keys.Enter).Build().Perform();

        requiredNode = childNodes?.Where(elem => elem.Text.Equals(nameTestComponent))?.ToArray();
        _logger.LogInformation("Переименованую ноду в дереве нашли");
        var newNameComponent = requiredNode[0].Text;
        _logger.LogInformation("Получили имя ноды в дереве =" + newNameComponent);

        Assert.AreEqual(nameTestComponent, newNameComponent);
      }, null, (ctx) => clearListComponent(ctx, nameTestComponent));
    }

    [Test]
    public void Test012EditorComponentCheckLocalStorage()
    {
      string nameTest = nameof(Test012EditorComponentCheckLocalStorage);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        schemeEditorTab.Click();
        var treeComponents = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorTreeComponents);
        var node = ctx.ElementFinder.FindElement(treeComponents, Scada3FinderContext.NodeTreeComponents);
        var selectedNameComponent = node.Text;
        node.Click();
        ctx.Actions.ContextClick(node).Perform();
        ctx.ElementFinder.FindElement(Scada3FinderContext.NodeTreeComponentsBtnOpenComponent).Click();
        var key = (string)_javaScript.ExecuteScript("return localStorage.getItem('ce_SCHEME_TABS');");
        var ce_SCHEME_TABS = JsonConvert.DeserializeObject<List<TabComponentEditor>>(key);

        TabComponentEditor selectedComponent = ce_SCHEME_TABS?.Where(elem => elem.wasSelected == true && elem.metadata.name.Equals(selectedNameComponent))?.ToArray()[0];
        Assert.IsNotNull(selectedComponent);
      }, null, null);
    }

    [Test]
    public void Test013EditorComponentImportAndExportFile()
    {
      var sim = new WindowsInput.InputSimulator();
      string nameTest = nameof(Test013EditorComponentImportAndExportFile);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        schemeEditorTab.Click();
        var treeComponents = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorTreeComponents);
        var node = ctx.ElementFinder.FindElement(treeComponents, Scada3FinderContext.NodeTreeComponents);
        node.Click();
        ctx.Actions.ContextClick(node).Perform();
        ctx.ElementFinder.FindElement(Scada3FinderContext.NodeTreeComponentsBtnOpenComponent).Click();
        var nameComponent = node.Text;
        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditroBtnExportFile).Click();
        
        var hostName = Environment.UserName;
        var path = $@"C:\Users\{hostName}\Downloads";
        var pattern = nameComponent + "*.json";

        //Надо подождать,пока сохранится
        while (!Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories).ToArray().Any())
        {
          Thread.Sleep(0);
        }

        _pathToComponentFile = Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories)?.OrderByDescending(t => new FileInfo(t).CreationTime)?.ToArray()[0];

        ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditroBtnImportFile).Click();
        var input = _driver.FindElement(By.Id("input-file-id"));//_driver.FindElement(By.XPath("/html/body/input"));

        input.SendKeys(_pathToComponentFile);
        sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.ESCAPE);

        Assert.Pass();
      }, null, (ctx) =>
      {
        sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.ESCAPE);
        if (File.Exists(_pathToComponentFile)) File.Delete(_pathToComponentFile);
      });
    }

    [Test]
    public void Test014EditorComponentToolbarTriggerToIncrementScale()
    {
      string nameTest = nameof(Test014EditorComponentToolbarTriggerToIncrementScale);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        schemeEditorTab.Click();

        //ОТкрыть первый компонент в дереве
        var treeComponents = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorTreeComponents);
        var node = ctx.ElementFinder.FindElement(treeComponents, Scada3FinderContext.NodeTreeComponents);
        var nameComponent = node.Text;
        node.Click();
        ctx.Actions.ContextClick(node).Perform();
        ctx.ElementFinder.FindElement(Scada3FinderContext.NodeTreeComponentsBtnOpenComponent).Click();

        var expandWide = ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarBtnMenuTriggerExpamdWide);
        expandWide.Click();
        ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarBtnMenuTriggerRestoreScale).Click();

        _driver.FindElement(By.ClassName("myDiagramDiv")).Click();//КОСТЫЛЬ!
        expandWide.Click();
        var btnToIcrement = ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarBtnMenuTriggerToIncrement);
        btnToIcrement.Click();

        var zoomText = ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarZoomText).Text;

        Assert.AreEqual(zoomText,"105%");
      }, null, ctx => _javaScript.ExecuteScript("location.reload()"));
    }

    [Test]
    public void Test015EditorComponentToolbarTriggerToDecrementScale()
    {
      string nameTest = nameof(Test015EditorComponentToolbarTriggerToDecrementScale);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        schemeEditorTab.Click();

        //Открыть первый компонент в дереве
        var treeComponents = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorTreeComponents);
        var node = ctx.ElementFinder.FindElement(treeComponents, Scada3FinderContext.NodeTreeComponents);
        var nameComponent = node.Text;
        node.Click();
        ctx.Actions.ContextClick(node).Perform();
        ctx.ElementFinder.FindElement(Scada3FinderContext.NodeTreeComponentsBtnOpenComponent).Click();

        var expandWide = ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarBtnMenuTriggerExpamdWide);
        expandWide.Click();
        ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarBtnMenuTriggerRestoreScale).Click();
        _driver.FindElement(By.ClassName("myDiagramDiv")).Click();//КОСТЫЛЬ!
        expandWide.Click();
        var btnToIcrement = ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarBtnMenuTriggerToDecrement);
        btnToIcrement.Click();

        var zoomText = ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarZoomText).Text;

        Assert.AreEqual(zoomText, "95%");
      }, null, ctx => _javaScript.ExecuteScript("location.reload()"));
    }

    [Test]
    public void Test016EditorComponentToolbarTriggerRestoreScale()
    {
      string nameTest = nameof(Test016EditorComponentToolbarTriggerRestoreScale);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var schemeEditorTab = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentsEditorTabScada3);
        schemeEditorTab.Click();

        //ОТкрыть первый компонент в дереве
        var treeComponents = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorTreeComponents);
        var node = ctx.ElementFinder.FindElement(treeComponents, Scada3FinderContext.NodeTreeComponents);
        ctx.Actions.DoubleClick(node).Perform();

        var expandWide = ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarBtnMenuTriggerExpamdWide);
        expandWide.Click();
        ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarBtnMenuTriggerRestoreScale).Click();
        var zoomText = ctx.ElementFinder.FindElement(Scada3FinderContext.ToolbarZoomText).Text;

        Assert.AreEqual(zoomText, "100%");
      }, null, null);
    }

 
   


    /// <summary>
    /// Логин
    /// </summary>
    private void LoginSunrise()
    {
      _testExecutor.RunTest(null, (ctx) =>
      {
        _openSunrisePageWait.Until(driver =>
        {
          try
          {
            driver.Navigate().GoToUrl(_addressSunrise);
            return true;
          }
          catch (Exception)
          {
            return false;
          }
        });

        _lsClear.ExecuteScript("localStorage.clear()");
        ctx.ElementFinder.FindElement(Scada3FinderContext.FormForAuthorization);
        IWebElement input = ctx.ElementFinder.FindElement(Scada3FinderContext.ScadaLoginUser); //Объект для Скады3
        input.Click();
        input.SendKeys(_loginForAuthorization);
        input = ctx.ElementFinder.FindElement(Scada3FinderContext.ScadaLoginPassword); //Объект для Скады3
        input.Click();
        input.SendKeys(_passwordForAuthorization);
        ctx.ElementFinder.FindElement(Scada3FinderContext.FormForAuthorizationButtonEntry).Click();
      }, null, null);
    }

    private bool IsFileLocked(FileInfo file)
    {
      FileStream fileStream = null;
      try
      {
        fileStream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
      }
      catch (IOException)
      {
        return true;
      }
      finally
      {
        if (fileStream != null)
          fileStream.Close();
      }
      return false;
    }

    [TearDown]
    public static void TearnDown()
    {
      LoggerHelper.LoggerHelper.Flush();
      if (File.Exists(ConfigurationLogger.pathFileLevelInfoLog))
        TestContext.AddTestAttachment(ConfigurationLogger.pathFileLevelInfoLog);
      if (File.Exists(ConfigurationLogger.pathFileLevelDebugAndErrorLog))
        TestContext.AddTestAttachment(ConfigurationLogger.pathFileLevelDebugAndErrorLog);
    }

    private void clearListComponent(ExecContext ctx, string nameTestComponent)
    {
        var treeComponents = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponentEditorTreeComponents);
        var childNodes = ctx.ElementFinder.FindElements(treeComponents, Scada3FinderContext.NodeTreeComponents);
        var requiredNode = childNodes?.Where(elem => elem.Text.Equals(nameTestComponent))?.ToArray();

        if (requiredNode != null || requiredNode.Any())
        {
          Actions builder = new Actions(_driver);
          builder.DoubleClick(requiredNode[0]).Build().Perform();
          //requiredNode[0].Click();
          var btnDelete = ctx.ElementFinder.FindElement(Scada3FinderContext.ComponenEditorBtnDeleteComponent);
          btnDelete.Click();

          builder.SendKeys(Keys.Enter).Build().Perform();
        }
    }

    /// <summary>
    /// Закрытие вкладок
    /// </summary>
    private void TabsClose(string message)
    {
      try
      {
        _testExecutor.RunTest(null, (ctx) =>
        {
          ctx.ElementFinder.FindElement(Scada3FinderContext.TabClose).Click();
          _logger.LogInformation(messageCloseTab(message));
        }, null, null);
      }
      catch (Exception)
      {
        _logger.LogInformation("Возникло исключение при закрытие вкладки");
      }
    }

    /// <summary>
    /// Открытие главного меню
    /// </summary>
    private void MenuOpen(ExecContext ctx)
    {
      ctx.ElementFinder.FindElement(Scada3FinderContext.MenuButtonMirBurger).Click();
    }

    /// <summary>
    /// Вход в обслуживание
    /// </summary>
    private void DiagnosticEnter(ExecContext ctx)
    {
      MenuOpen(ctx);
      ctx.ElementFinder.FindElement(Scada3FinderContext.DiagnosticDebagTab).Click();
      _driver.SwitchTo().Window(_driver.WindowHandles.Last());
      ctx.ElementFinder.FindElement(Scada3FinderContext.MenuButtonMirBurger).Click();
    }

    /// <summary>
    /// Закрытие окна
    /// </summary>
    private void CloseWindow()
    {
      _driver.Close();
      _driver.SwitchTo().Window(_driver.WindowHandles[0]);
    }

    /// <summary>
    /// Меняет путь до файлов логирования
    /// </summary>
    /// <param name="nameTest"></param>
    private void ChangePathFile(string nameTest)
    {
      var fileName = $"{nameTest}.txt";
      ConfigurationLogger.ChangeConfigurationLogManager(fileName);
    }


    private string _pathToComponentFile = "";

    private string messageFinderElement(string elem) => finderElement + elem;
    private string messageClickElement(string elem) => clickElement + elem;
    private string messageCloseTab(string elem) => closeTab + elem;

    private const string finderElement = "Нашел элемент ";
    private const string clickElement = "Произвел клик по элементу ";
    private const string closeTab = "Была закрыта вкладка для теста ";
    private ILogger _logger;

    private readonly TestExecutor _testExecutor;
    private readonly IElementFinder _elementFinder;
    private readonly IWebDriver _driver;
    private readonly IJavaScriptExecutor _lsClear;
    private readonly IJavaScriptExecutor _javaScript;
    private readonly WebDriverWait _wait;
    private readonly WebDriverWait _openSunrisePageWait;
    private readonly string _addressSunrise;
    private readonly string _loginForAuthorization;
    private readonly string _passwordForAuthorization;
  }
  public class TabComponentEditor
  {
    public bool autoActive;
    public string id;
    public Metadata metadata;
    public string progress;
    public string title;
    public bool wasSelected;
  }
  public class Metadata
  {
    public string id;
    public string name;
  }
}