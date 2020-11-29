using Mir.AutoTests.TestEngine.Finder;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Mir.AutoTests.TestEngine.TestExec
{
  /// <summary>
  /// Контекст выполнения теста
  /// </summary>
  public class ExecContext
  {
    /// <summary>
    /// Конструктор 
    /// </summary>
    /// <param name="getDriver">Фабричный метод получения Web-драйвера</param>
    /// <param name="getElementFinder">Фабричный метод получения 'поисковика' элементов</param>
    public ExecContext(Func<IWebDriver> getDriver,
                       Func<IElementFinder> getElementFinder)
    {
      if (getDriver is null)
      {
        throw new ArgumentNullException(nameof(getDriver));
      }
      if (getElementFinder is null)
      {
        throw new ArgumentNullException(nameof(getElementFinder));
      }
      _getDriver = getDriver;
      _getElementFinder = getElementFinder;
    }

    /// <summary>
    /// Web драйвер
    /// </summary>
    public IWebDriver Driver => _driver ?? (_driver = _getDriver());
    /// <summary>
    /// Помошник поиска элемента
    /// </summary>
    public IElementFinder ElementFinder => _elementFinder ?? (_elementFinder = _getElementFinder());
    /// <summary>
    /// Расширенные действи для браузера
    /// (Должны создаваться для каждого теста отдельно)
    /// </summary>
    public Actions Actions => new Actions(Driver);

    private IWebDriver _driver;
    private IElementFinder _elementFinder;

    private Func<IWebDriver> _getDriver;
    private Func<IElementFinder> _getElementFinder;
  }
}
