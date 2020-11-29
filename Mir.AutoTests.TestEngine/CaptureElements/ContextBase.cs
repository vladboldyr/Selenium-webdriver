using System;
using System.Collections.Generic;
using System.Text;

namespace Mir.AutoTests.TestEngine.CaptureElements
{
  public class ContextBase : IContext
  {
    public ContextBase()
    {
      _captureMethods = new Dictionary<string, IReadOnlyList<CaptureMethod>>();
    }

    ///<inheritdoc/>
    public void AddOrUpdateCaptureMethods(string key, IReadOnlyList<CaptureMethod> captureMethods)
    {
      _captureMethods[key] = captureMethods;
    }

    ///<inheritdoc/>
    public IReadOnlyList<CaptureMethod> GetCaptureMethods(string key)
    {
      if (_captureMethods.TryGetValue(key, out var captureMethods))
      {
        return captureMethods;
      }

      throw new KeyNotFoundException($"Не найдены методы захвата объекта для ИД='{key}'");
    }

    ///<inheritdoc/>
    public IReadOnlyList<CaptureMethod> RemoveCaptureMethods(string key)
    {
      if (_captureMethods.TryGetValue(key, out var captureMethods))
      {
        if (_captureMethods.Remove(key))
        {
          return captureMethods;
        }
        else 
        {
          throw new Exception($"Сбой при удалении методов захвата объектов ИД='{key}'");
        }
      }

      return null;
    }

    private Dictionary<string, IReadOnlyList<CaptureMethod>> _captureMethods;
  }
}
