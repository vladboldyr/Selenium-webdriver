using Mir.AutoTests.TestEngine.CaptureElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Mir.AutoTests.TestEngine.Finder
{
  ///<inheritdoc/>
  public class ElementFinder : IElementFinder
  {
    public ElementFinder(IContext captureElementsontext,
                         IWait<IWebDriver> wait)
    {
      _captureElementsontext = captureElementsontext ?? throw new ArgumentNullException(nameof(captureElementsontext));
      _wait = wait ?? throw new ArgumentNullException(nameof(wait));
    }

    ///<inheritdoc/>
    public IWebElement FindElement(string key, TimeSpan timeout = default(TimeSpan))
    {
      if (timeout == default(TimeSpan)) timeout = TimeSpan.FromSeconds(30);
      return FindElement(key, timeout, DefaulteWaitPredicate);
    }

    ///<inheritdoc/>
    public IWebElement FindElement(string key, TimeSpan timeout, Func<IWebElement, bool> waitPredicate)
    {
     IWebElement webElement = null;
      var cMethods = _captureElementsontext.GetCaptureMethods(key);
      _wait.Timeout = timeout;
      _wait.Until(driver =>
      {
        for (int i = 0; i < cMethods.Count; i++)
        {
          var methodDescriptor = cMethods[i];
          try
          {
            webElement = driver.FindElement(methodDescriptor.Method(methodDescriptor.Key));
            break;
          }
          catch (NoSuchElementException)
          {
            if (i == cMethods.Count - 1)
            {
              throw;
            }
          }
        }
        return waitPredicate(webElement);
      });
      return webElement;
    }

    ///<inheritdoc/>
    public IWebElement FindElement(IWebElement container, string key) 
    {
      return FindElement(container, key, DefaulteWaitPredicate);
    }


    ///<inheritdoc/>
    public IWebElement FindElement(IWebElement container, string key, Func<IWebElement, bool> waitPredicate) 
    {
      IWebElement webElement = null;
      var cMethods = _captureElementsontext.GetCaptureMethods(key);
      _wait.Until(driver =>
      {
        for (int i = 0; i < cMethods.Count; i++)
        {
          var methodDescriptor = cMethods[i];
          try
          {
            webElement = container.FindElement(methodDescriptor.Method(methodDescriptor.Key));
            break;
          }
          catch (NoSuchElementException)
          {
            if (i == cMethods.Count - 1)
            {
              throw;
            }
          }
        }
        return waitPredicate(webElement);
      });
      return webElement;
    }

    public ReadOnlyCollection<IWebElement> FindElements(string key, TimeSpan timeout = default(TimeSpan))
    {
      if (timeout == default(TimeSpan)) timeout = TimeSpan.FromSeconds(30);
      return FindElements(key, timeout, DefaulteWaitPredicate);
    }
    public ReadOnlyCollection<IWebElement> FindElements(string key, TimeSpan timeout, Func<ReadOnlyCollection<IWebElement>, bool> waitPredicate)
    {
      ReadOnlyCollection<IWebElement> webElements = null;
      var cMethods = _captureElementsontext.GetCaptureMethods(key);
      _wait.Timeout = timeout;
      _wait.Until(driver =>
      {
        for (int i = 0; i < cMethods.Count; i++)
        {
          var methodDescriptor = cMethods[i];
          try
          {
            webElements = driver.FindElements(methodDescriptor.Method(methodDescriptor.Key));
            break;
          }
          catch (NoSuchElementException)
          {
            if (i == cMethods.Count - 1)
            {
              throw;
            }
          }
        }
        return waitPredicate(webElements);
      });
      return webElements;
    }

    public ReadOnlyCollection<IWebElement> FindElements(IWebElement context,string key, TimeSpan timeout = default(TimeSpan))
    {
      if (timeout == default(TimeSpan)) timeout = TimeSpan.FromSeconds(30);
      return FindElements(key, timeout, DefaulteWaitPredicate);
    }

    public ReadOnlyCollection<IWebElement> FindElements(IWebElement container, string key, TimeSpan timeout, Func<ReadOnlyCollection<IWebElement>, bool> waitPredicate)
    {
      ReadOnlyCollection<IWebElement> webElements = null;
      var cMethods = _captureElementsontext.GetCaptureMethods(key);
      _wait.Timeout = timeout;
      _wait.Until(driver =>
      {
        for (int i = 0; i < cMethods.Count; i++)
        {
          var methodDescriptor = cMethods[i];
          try
          {
            webElements = container.FindElements(methodDescriptor.Method(methodDescriptor.Key));
            break;
          }
          catch (NoSuchElementException)
          {
            if (i == cMethods.Count - 1)
            {
              throw;
            }
          }
        }
        return waitPredicate(webElements);
      });
      return webElements;
    }

    public ReadOnlyCollection<IWebElement> FindElements(IWebElement container, string key)
    {
      return FindElements(container, key, DefaulteWaitPredicate);
    }

    public ReadOnlyCollection<IWebElement> FindElements(IWebElement container, string key, Func<ReadOnlyCollection<IWebElement>, bool> waitPredicate)
    {
      ReadOnlyCollection<IWebElement> webElements = null;
      var cMethods = _captureElementsontext.GetCaptureMethods(key);
      _wait.Until(driver =>
      {
        for (int i = 0; i < cMethods.Count; i++)
        {
          var methodDescriptor = cMethods[i];
          try
          {
            webElements = container.FindElements(methodDescriptor.Method(methodDescriptor.Key));
            break;
          }
          catch (NoSuchElementException)
          {
            if (i == cMethods.Count - 1)
            {
              throw;
            }
          }
        }
        return waitPredicate(webElements);
      });
      return webElements;
    }

    private bool DefaulteWaitPredicate(IWebElement webElement) 
    {
      return webElement.Displayed && webElement.Enabled;
    }

    private bool DefaulteWaitPredicate(ReadOnlyCollection<IWebElement> webElements)
    {
      List<IWebElement> listElements = webElements.ToList();
      foreach(IWebElement element in listElements)
      {
        if (!element.Displayed && !element.Enabled)
          return false;
      }
      return true;
    }

    private IWait<IWebDriver> _wait;
    private IWebDriver _driver;
    private IContext _captureElementsontext;
  }
}
