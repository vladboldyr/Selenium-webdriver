using Mir.AutoTests.TestEngine.Finder;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mir.AutoTests.TestEngine.TestExec
{
  /// <summary>
  /// Обертка для выполнения теста
  /// </summary>
  public class TestExecutor
  {
    public TestExecutor(IWebDriver webDriver, 
                        IElementFinder elementFinder, 
                        ILoggerFactory loggerFactory)
    {
      _webDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
      _elementFinder = elementFinder ?? throw new ArgumentNullException(nameof(elementFinder));
      _logger = loggerFactory.CreateLogger<TestExecutor>();
    }

    /// <summary>
    /// Запустить тест
    /// </summary>
    /// <param name="testMethod">Метод теста</param>
    public void RunTest(Action<ExecContext> onStart,
                        Action<ExecContext> testMethod,
                        Action<ExecContext> onError,
                        Action<ExecContext> onFinally)
    {
      StackTrace stackTrace = new StackTrace();
      var testName = stackTrace.GetFrame(1)?.GetMethod()?.Name;
      _logger.LogDebug("===START Test=== '" + testName + "'");
      var sw = Stopwatch.StartNew(); //Запуск таймера
      ExecContext execContext = null;
      try
      {
        execContext = new ExecContext(() => _webDriver, () => _elementFinder);
        onStart?.Invoke(execContext);
        testMethod(execContext);
      }
      catch (SuccessException)
      {
        throw;
      }
      catch (Exception e)
      {
        onError?.Invoke(execContext);
        _logger.LogError(e, e.Message);
        throw;
      }
      finally
      {
        sw.Stop(); //Остановка таймера
        onFinally?.Invoke(execContext);
        _logger.LogDebug("===END Test=== '" + testName + "' " + "Total Time = " + sw.Elapsed);
      }
    }

    private IWebDriver _webDriver;
    IElementFinder _elementFinder;
    private ILogger _logger;
  }
}
