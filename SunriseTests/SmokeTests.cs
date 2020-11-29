using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Mir.AutoTests.TestEngine.TestExec;
using Mir.AutoTests.TestEngine.Finder;
using SunriseTests.ElementsContext;
using Mir.AutoTests.TestEngine.Interfaces;
using System.IO;
using Microsoft.Extensions.Logging;
using LoggerHelper;

namespace SunriseTests
{
  [TestFixture]
  public class SmokeTests
  {
    public SmokeTests()
    {
      IConfig config = new XmlConfigReader();
      _driver = new ChromeDriver();
      _lsClear = _driver as IJavaScriptExecutor;
      _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
      _openSunrisePageWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(300));

      _elementFinder = new ElementFinder(SunriseFinderContext.ElementsContext, _wait);
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
    public void Test001Main()
    {
      string nameTest = nameof(Test001Main);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
        {
          var mainPageElem = ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageName);
          _logger.LogInformation(messageFinderElement(SunriseFinderContext.MainPageName));
          mainPageElem.Click();
          _logger.LogInformation(messageClickElement(SunriseFinderContext.MainPageName));

          ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticSystemTailOnMainPage);
          _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticSystemTailOnMainPage));

          var versionPoElem = ctx.ElementFinder.FindElement(SunriseFinderContext.VersionTail);
          _logger.LogInformation(messageFinderElement(SunriseFinderContext.VersionTail));
          Assert.Pass();
        }, null, (ctx) =>
        {
          TabsClose(nameTest);
        });
    }

    [Test]
    public void Test002SubscriberManagement()
    {
      string nameTest = nameof(Test002SubscriberManagement);
      ChangePathFile(nameTest);

      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var subcrManTab = ctx.ElementFinder.FindElement(SunriseFinderContext.SubscrMan);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.SubscrMan));
        subcrManTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.SubscrMan));
        ctx.ElementFinder.FindElement(SunriseFinderContext.SubscrManPlus);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.SubscrManPlus));
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test003DiagnosticNSD()
    {
      string nameTest = nameof(Test003DiagnosticNSD);
      ChangePathFile(nameTest);

      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var diagNSDTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagNSD);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagNSD));
        diagNSDTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagNSD));

        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagNSDDiagSystem);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagNSDDiagSystem));
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test004LightingControl()
    {
      string nameTest = nameof(Test004LightingControl);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var lightCtrlTab = ctx.ElementFinder.FindElement(SunriseFinderContext.LightCtrl);
        lightCtrlTab.Click();
        var lightCtrlSelectAll = ctx.ElementFinder.FindElement(SunriseFinderContext.LightCtrlSelectAll);
        lightCtrlSelectAll.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.LightCtrlTurnOn);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test005Protocol()
    {
      string nameTest = nameof(Test005Protocol);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        _logger.LogInformation("Start test Protocol");
        var protocolTab = ctx.ElementFinder.FindElement(SunriseFinderContext.ProtocolPage);
        protocolTab.Click();
        _logger.LogInformation("Click ProtocolPage");
        ctx.ElementFinder.FindElement(SunriseFinderContext.DateTimeRangeComp);
        _logger.LogInformation("FindElement DateTimeRangeComp");
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test006Abonents()
    {
      string nameTest = nameof(Test006Abonents);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var abonentsTab = ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPage);
        abonentsTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageChoose);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test007AbonentsMini()
    {
      string nameTest = nameof(Test007AbonentsMini);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var abonentsMiniTab = ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageMini);
        abonentsMiniTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.MirDialogComTextForConnection);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test008Connection()
    {
      string nameTest = nameof(Test008Connection);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var connectionTab = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPage);
        connectionTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.MirMatTreeNodeCom);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test009Graphs()
    {
      string nameTest = nameof(Test009Graphs);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var graphsTab = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPage);
        graphsTab.Click();
        var graphsTabButtonBuild = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPageButtonBuild);
        graphsTabButtonBuild.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPageChooseObj);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test010Balance()
    {
      string nameTest = nameof(Test010Balance);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var balanceTab = ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePage);
        balanceTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageNoGroup);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test011BalanceMini()
    {
      string nameTest = nameof(Test011BalanceMini);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var balanceTabMini = ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageMini);
        balanceTabMini.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageMiniCalendar);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test012Reports()
    {
      string nameTest = nameof(Test012Reports);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var reportsTabMenu = ctx.ElementFinder.FindElement(SunriseFinderContext.ReportsPage);
        reportsTabMenu.Click();
        var reportsTabAct11 = ctx.ElementFinder.FindElement(SunriseFinderContext.ReportsPageAct11);
        reportsTabAct11.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ReportsPageAct11NotReq);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test013ImportExport()
    {
      string nameTest = nameof(Test013ImportExport);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var importExpTabMenu = ctx.ElementFinder.FindElement(SunriseFinderContext.ImportExportPage);
        importExpTabMenu.Click();
        var importExpTabGorSet11 = ctx.ElementFinder.FindElement(SunriseFinderContext.ImportExportPageGorSet11);
        importExpTabGorSet11.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ImportExportPageGorSet11NotReq);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test014CollectionService()
    {
      string nameTest = nameof(Test014CollectionService);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var collectionServiceTab = ctx.ElementFinder.FindElement(SunriseFinderContext.CollectionServicePage);
        collectionServiceTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.CollectionServicePageStatus);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    // TO DO на странице,если пустая конфигурация на сервере,то на клиенте будет приходить 500-ая ошибка при запросе
    // и бесконечная надпись загрузки 
    [Test]
    public void Test015Integration()
    {
      string nameTest = nameof(Test015Integration);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var integrationTab = ctx.ElementFinder.FindElement(SunriseFinderContext.IntegrationPage);
        integrationTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.IntegrationPagePicto);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test016AccessRights()
    {
      string nameTest = nameof(Test016AccessRights);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var accessRightTab = ctx.ElementFinder.FindElement(SunriseFinderContext.AccessRightsPage);
        accessRightTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.AccessRightsPageUserGr);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test017Themes()
    {
      string nameTest = nameof(Test017Themes);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var themesTab = ctx.ElementFinder.FindElement(SunriseFinderContext.ThemesPage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.ThemesPage));

        themesTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.ThemesPage));

        ctx.ElementFinder.FindElement(SunriseFinderContext.ThemesPageVesteros);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.ThemesPageVesteros));

        ctx.ElementFinder.FindElement(SunriseFinderContext.TabContent).Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.TabContent));

        Assert.Pass();
      }, null, (ctx) =>
        {
        });
    }

    [Test]
    public void Test018DiagnosticDebugging()
    {
      string nameTest = nameof(Test018DiagnosticDebugging);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(DiagnosticEnter, (ctx) =>
      {
        var diagnosticDebaggingTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticDebaggingPage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticDebaggingPage));

        diagnosticDebaggingTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticDebaggingPage));

        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticDebaggingPageDelDiag);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticDebaggingPageDelDiag));

        Assert.Pass();
      }, (ctx) =>
      {
        _logger.LogInformation("Test if fail");
        Assert.Fail();
      }, (ctx) =>
      {
        TabsClose(nameTest);
        CloseWindow();
      });
    }

    [Test]
    public void Test019DiagnosticDatabase()
    {
      string nameTest = nameof(Test019DiagnosticDatabase);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(DiagnosticEnter, (ctx) =>
      {
        var diagnosticDatabaseTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticDatabasePage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticDatabasePage));

        diagnosticDatabaseTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticDatabasePage));

        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticDatabasePageNameBD);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticDatabasePageNameBD));

        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
        CloseWindow();
      });
    }

    [Test]
    public void Test020DiagnosticAboutServer()
    {
      string nameTest = nameof(Test020DiagnosticAboutServer);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(DiagnosticEnter, (ctx) =>
      {
        var diagnosticAboutServerTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticAboutServerPage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticAboutServerPage));

        diagnosticAboutServerTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticAboutServerPage));

        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticAboutServerPageInfo);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticAboutServerPageInfo));

        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
        CloseWindow();
      });
    }

    [Test]
    public void Test021DiagnosticProcesses()
    {
      string nameTest = nameof(Test021DiagnosticProcesses);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(DiagnosticEnter, (ctx) =>
      {
        var diagnosticProcessTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticProcessPage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticProcessPage));

        diagnosticProcessTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticProcessPage));

        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticProcessPageList);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticProcessPageList));

        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
        CloseWindow();
      });
    }

    [Test]
    public void Test022DiagnosticProgrammes()
    {
      string nameTest = nameof(Test022DiagnosticProgrammes);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(DiagnosticEnter, (ctx) =>
      {
        var diagnosticProgrammTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticProgrammPage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticProgrammPage));

        diagnosticProgrammTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticProgrammPage));

        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticProgrammPageInstProg, TimeSpan.FromSeconds(120));
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticProgrammPageInstProg));

        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
        CloseWindow();
      });
    }

    [Test]
    public void Test023DiagnosticPorts()
    {
      string nameTest = nameof(Test023DiagnosticPorts);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(DiagnosticEnter, (ctx) =>
      {
        var diagnosticPortsTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticPortsPage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticPortsPage));

        diagnosticPortsTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticPortsPage));

        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticPortsPagePorts);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticPortsPagePorts));

        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
        CloseWindow();
      });
    }

    [Test]
    public void Test024DiagnosticEditorAP()
    {
      string nameTest = nameof(Test024DiagnosticEditorAP);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(DiagnosticEnter, (ctx) =>
      {
        var diagnosticEditorTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticEditorPage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticEditorPage));

        diagnosticEditorTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticEditorPage));

        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticEditorPageBrTower);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticEditorPage));

        Assert.Pass();
      }, null, (ctx) =>
        {
          TabsClose(nameTest);
          CloseWindow();
        });
    }

    [Test]
    public void Test027DiagnosticThemes()
    {
      string nameTest = nameof(Test027DiagnosticThemes);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(DiagnosticEnter, (ctx) =>
      {
        var diagnosticThemesTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticThemesPage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticThemesPage));

        diagnosticThemesTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticThemesPage));

        Thread.Sleep(1000);
        diagnosticThemesTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticThemesPage));

        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticThemesPageVesteros);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticThemesPageVesteros));

        Assert.Pass();
      }, null, (ctx) =>
      {
        CloseWindow();
      }
      );
    }

    [Test]
    public void Test025DiagnosticScheduleManagement()
    {
      string nameTest = nameof(Test025DiagnosticScheduleManagement);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(DiagnosticEnter, (ctx) =>
      {
        var diagnosticScheManagTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticScheManagPage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticScheManagPage));

        diagnosticScheManagTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticScheManagPage));

        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticScheManagPageScheGr);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticScheManagPageScheGr));

        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
        CloseWindow();
      });
    }

    [Test]
    public void Test026DiagnosticDebuggingManagement()
    {
      string nameTest = nameof(Test026DiagnosticDebuggingManagement);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(DiagnosticEnter, (ctx) =>
      {
        var diagnosticDebagManagTab = ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticDebagManagPage);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticDebagManagPage));

        diagnosticDebagManagTab.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.DiagnosticDebagManagPage));


        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticDebagManagPageSaveB);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.DiagnosticDebagManagPageSaveB));

        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
        CloseWindow();
      });
    }

    [Test]
    public void Test028ConnectionST()
    {
      string nameTest = nameof(Test028ConnectionST);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var connectionSTTab = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPage);
        connectionSTTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTConnect);
        var connectionTabParameters = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTParameters);
        var connectionSTTabPicto = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPagePicto);
        connectionSTTabPicto.Click();
        ctx.Actions.ContextClick(connectionSTTabPicto).Perform();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTChangeTypePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCreatePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCommandsPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTUpdatePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCopyPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTDeletePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTSortPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTExportPicto);
        connectionTabParameters.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTTimeCorrection);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTData);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTListIndic);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTTarifList);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test029AbonentsST()
    {
      string nameTest = nameof(Test029AbonentsST);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var abonentsSTTab = ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPage);
        abonentsSTTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPagePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTRegion);
        var abonentsSTTabHouse = ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTHouse);
        abonentsSTTabHouse.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTInfo);
        ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTEdit);
        var abonentsSTTabRegionX = ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTRegion);
        abonentsSTTabRegionX.Click();
        ctx.Actions.ContextClick(abonentsSTTabRegionX).Perform();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCreatePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTUpdatePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCopyPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTDeletePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTSortPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCreateCardPicto);
        var abonentsSTTabFreeSpace = ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTFreeSpace);
        ctx.Actions.DoubleClick(abonentsSTTabFreeSpace).Perform();
        var abonentsSTTabConnectPicto = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPagePicto);
        ctx.Actions.ContextClick(abonentsSTTabConnectPicto).Perform();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTChangeTypePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTUpdatePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCopyPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTDeletePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTSortPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTCheckAbonents);
        ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTAddToAbonList);
        ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTExportAbonInfo);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test030MainST()
    {
      string nameTest = nameof(Test030MainST);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var mainSTTab = ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageName);
        mainSTTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticSystemTailOnMainPage);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTChannelConnect);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTCoeb);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTCollected);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTTotal);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTOnControl);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTWithoutControlTable);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTLagData);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTDuplicatesChannels);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTDiffTime);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTLanAddressDup);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTDuplicates);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTWithoutControl);
        ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTChannelPasport);
        var mainSTTabPlusRotate = ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTPlusRotate);
        mainSTTabPlusRotate.Click();
        var mainSTTabMinusRotate = ctx.ElementFinder.FindElement(SunriseFinderContext.MainPageSTMinusRotate);
        mainSTTabMinusRotate.Click();
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test031BalanceST()
    {
      string nameTest = nameof(Test031BalanceST);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var balanceSTTab = ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePage);
        balanceSTTab.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTPowerSystem);
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTConnection);
        var balanseSTTabAbonents = ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTAbonents);
        var balanceSTTabGeoRegion = ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTGeoRegion);
        var balanceSTTabChannel1 = ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTChannel1);
        ctx.Actions.ContextClick(balanceSTTabGeoRegion).Perform();
        var balanceSTTabCreate = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCreatePicto);
        balanceSTTabCreate.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTBalanceGroup);
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTGeoSubRegion);
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTReportGroup);
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTObjProc);
        ctx.Actions.ContextClick(balanceSTTabChannel1).Perform();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTChangeTypePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTUpdatePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCopyPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTDeletePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTSortPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTChannelTypeChange);
        ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTCheckAbonents);
        ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTAddToAbonList);
        ctx.ElementFinder.FindElement(SunriseFinderContext.AbonentsPageSTExportAbonInfo);
        balanseSTTabAbonents.Click();
        var balanceSTTabArrowRegion = ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTArrowRegion);
        balanceSTTabArrowRegion.Click();
        var balanceSTTabChannel11 = ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTChannel1Region);
        ctx.Actions.ContextClick(balanceSTTabChannel11).Perform();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCreatePicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTExport);
        ctx.ElementFinder.FindElement(SunriseFinderContext.BalancePageSTImport);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTMinusPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTPlusPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTCreateCardPicto);
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageSTShowCardPicto);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test032GraphsCheck()
    {
      string nameTest = nameof(Test032GraphsCheck);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var graphsPageElem = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPage);
        graphsPageElem.Click();
        var graphsPageButtonAddObj = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPageAddObj);
        graphsPageButtonAddObj.Click();
        var graphsPageArrowList = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPageArrowList);
        ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPageSqrAll);
        graphsPageArrowList.Click();        
        ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPageSqrMk);
        ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPageSqr1);
        ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPageSqr2);
        var graphsPageSqr3 = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphsPageSqr3);
        graphsPageSqr3.Click();
        Assert.IsTrue(graphsPageSqr3.Selected);
        var graphsPageCheckBoxAddObj = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphPageCheckBoxAddObj);
        Assert.IsTrue(graphsPageCheckBoxAddObj.Selected);
        var graphsPageButtonAddChannels = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphPageAddChannels);
        graphsPageButtonAddChannels.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.GraphPageButtonOther);
        //var graphsPageActiveLine = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphPageActiveLineDay);
        //graphsPageActiveLine.Click();
        //Assert.IsTrue(graphsPageActiveLine.Selected);//
        var graphsPageVoltageInstVal = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphPageVoltageInstVal);
        graphsPageVoltageInstVal.Click();
        Assert.IsTrue(graphsPageVoltageInstVal.Selected);
        var graphsPageButtonAcceptAddChannels = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphPageButtonAcceptAddChannels);
        graphsPageButtonAcceptAddChannels.Click();
        //var graphsPageActiveLineDayUnder = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphPageActiveLineDayUnder);
        //Assert.IsTrue(graphsPageActiveLineDayUnder.Selected);
        var graphsPageVoltageInstValUnder = ctx.ElementFinder.FindElement(SunriseFinderContext.GraphPageVoltageInstValUnder);
        Assert.IsTrue(graphsPageVoltageInstValUnder.Selected);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    [Test]
    public void Test033SearchCheck()
    {
      string nameTest = nameof(Test033SearchCheck);
      ChangePathFile(nameTest);
      _testExecutor.RunTest(MenuOpen, (ctx) =>
      {
        var connectionPageElem = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPage);
        connectionPageElem.Click();
        var connectionPageCheckFind = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageCheckFind);
        connectionPageCheckFind.Click();
        var currentSelect = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageCheckBy);
        var selectElement = new SelectElement(currentSelect);
        selectElement.SelectByText("Имя");
        var connectionPageFindString = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageFindString);
        connectionPageFindString.Click();
        connectionPageFindString.SendKeys("мк");
        var connectionPageFindMK = ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageFindMK);
        connectionPageFindMK.Click();
        ctx.ElementFinder.FindElement(SunriseFinderContext.ConnectionPageMK);
        Assert.Pass();
      }, null, (ctx) =>
      {
        TabsClose(nameTest);
      });
    }

    /// <summary>
    /// Логин
    /// </summary>
    private void LoginSunrise()
    {
      //string nameTest = nameof(LoginSunrise);
      //ChangePathFile(nameTest);
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
        _logger.LogInformation("clear localStorage");
        ctx.ElementFinder.FindElement(SunriseFinderContext.FormForAuthorization);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.FormForAuthorization));

        IWebElement input = ctx.ElementFinder.FindElement(SunriseFinderContext.Login);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.Login));

        input.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.Login));

        input.SendKeys(_loginForAuthorization);
        _logger.LogInformation("Enter login");

        input = ctx.ElementFinder.FindElement(SunriseFinderContext.Password);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.Password));

        input.Click();
        _logger.LogInformation(messageClickElement(SunriseFinderContext.Password));

        input.SendKeys(_passwordForAuthorization);
        _logger.LogInformation("Enter password");

        ctx.ElementFinder.FindElement(SunriseFinderContext.FormForAuthorizationButtonEntry).Click();
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.FormForAuthorizationButtonEntry));
        _logger.LogInformation(messageClickElement(SunriseFinderContext.FormForAuthorizationButtonEntry));

        ctx.ElementFinder.FindElement(SunriseFinderContext.MenuButtonMirBurger);
        _logger.LogInformation(messageFinderElement(SunriseFinderContext.MenuButtonMirBurger));

      }, null, null);
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

    /// <summary>
    /// Закрытие вкладок
    /// </summary>
    private void TabsClose(string message)
    {
      try
      {
        _testExecutor.RunTest(null, (ctx) =>
        {
          ctx.ElementFinder.FindElement(SunriseFinderContext.TabClose).Click();
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
      ctx.ElementFinder.FindElement(SunriseFinderContext.MenuButtonMirBurger).Click();
    }

    /// <summary>
    /// Вход в обслуживание
    /// </summary>
    private void DiagnosticEnter(ExecContext ctx)
    {
      MenuOpen(ctx);
      ctx.ElementFinder.FindElement(SunriseFinderContext.DiagnosticDebagTab).Click();
      _driver.SwitchTo().Window(_driver.WindowHandles.Last());
      ctx.ElementFinder.FindElement(SunriseFinderContext.MenuButtonMirBurger).Click();
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
    private readonly WebDriverWait _wait;
    private readonly WebDriverWait _openSunrisePageWait;
    private readonly string _addressSunrise;
    private readonly string _loginForAuthorization;
    private readonly string _passwordForAuthorization;
  }
}