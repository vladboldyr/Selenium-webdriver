using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mir.AutoTests.TestEngine.Finder
{
  /// <summary>
  /// Помошник поиска элемента
  /// </summary>
  public interface IElementFinder
  {
    /// <summary>
    /// Найти элемент по виртуальному идентификатору
    /// </summary>
    /// <param name="key">Виртуальный идентификатор элемента</param>
    /// <param name="timeout">Время для поиска элемента</param>
    /// <returns></returns>
    IWebElement FindElement(string key, TimeSpan timeout = default(TimeSpan));
    /// <summary>
    /// Найти элементы по виртуальному идентификатору
    /// </summary>
    /// <param name="key"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    ReadOnlyCollection<IWebElement> FindElements(string key, TimeSpan timeout = default(TimeSpan));
    /// <summary>
    /// Найти элемен по виртуальному идентификатору
    /// </summary>
    /// <param name="key">Виртуальный идентификатор элемента</param>
    /// <param name="timeout">Время для поиска элемента</param>
    /// <param name="waitPredicate">Предикат ожидания</param>
    /// <returns></returns>
    IWebElement FindElement(string key, TimeSpan timeout, Func<IWebElement, bool> waitPredicate);
    /// <summary>
    /// Найти элемент по виртуальному идентификатору
    /// </summary>
    /// <param name="key">Виртуальный идентификатор элемента</param>
    /// <param name="timeout">Время для поиска элемента</param>
    /// <param name="waitPredicate">Предикат ожидания</param>
    /// <returns></returns>
    ReadOnlyCollection<IWebElement> FindElements(string key, TimeSpan timeout, Func<ReadOnlyCollection<IWebElement>, bool> waitPredicate);
    /// <summary>
    /// Найти элементы, находящийся внутри контейнера по виртуальному идентификатору
    /// </summary>
    /// <param name="container">Контейнер</param>
    /// <param name="key">Виртуальный идентификатор элемента</param>
    /// <returns></returns>
    ReadOnlyCollection<IWebElement> FindElements(IWebElement container, string key);
    /// <summary>
    /// Найти элементы, находящийся внутри контейнера по виртуальному идентификатору
    /// </summary>
    /// <param name="container">Контейнер</param>
    /// <param name="key">Виртуальный идентификатор элемента</param>
    /// <param name="waitPredicate">Предикат ожидания</param>
    /// <returns></returns>
    /// 
    ReadOnlyCollection<IWebElement> FindElements(IWebElement container,string key,Func<ReadOnlyCollection<IWebElement>, bool> waitPredicate);
    /// <summary>
    /// Найти элементы, находящийся внутри контейнера по виртуальному идентификатору
    /// </summary>
    /// <param name="container">Контейнер</param>
    /// <param name="key">Виртуальный идентификатор элемента</param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    /// 
    ReadOnlyCollection<IWebElement> FindElements(IWebElement container, string key, TimeSpan timeout = default(TimeSpan));
    /// <summary>
    /// Найти элементы, находящийся внутри контейнера по виртуальному идентификатору
    /// </summary>
    /// <param name="container">Контейнер</param>
    /// <param name="key">Виртуальный идентификатор элемента</param>
    /// <returns></returns>
    IWebElement FindElement(IWebElement container, string key);
    /// <summary>
    /// Найти элемент, находящийся внутри контейнера по виртуальному идентификатору
    /// </summary>
    /// <param name="container">Контейнер</param>
    /// <param name="key">Виртуальный идентификатор элемента</param>
    /// <param name="waitPredicate">Предикат ожидания</param>
    /// <returns></returns>
    IWebElement FindElement(IWebElement container, string key, Func<IWebElement, bool> waitPredicate);
  }
}
