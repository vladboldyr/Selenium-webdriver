using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Mir.AutoTests.TestEngine.CaptureElements
{
  /// <summary>
  /// Описатель метода захвата элемента
  /// </summary>
  public readonly struct CaptureMethod
  {
    public CaptureMethod(Func<string, By> method, string key)
    {
      Method = method ?? throw new ArgumentNullException(nameof(method));
      Key = key ?? throw new ArgumentNullException(nameof(key));
    }

    /// <summary>
    /// Метод захвата элемента
    /// </summary>
    public Func<string, By> Method { get; }
    /// <summary>
    /// Ключ, по которому будет производиться захват элемента
    /// </summary>
    public string Key { get; }
  }
}
