using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Mir.AutoTests.TestEngine.CustomLogger
{
  public class CustomLoggerConsol : ILogger
  {
    public CustomLoggerConsol()
    {
      //_logLevel = logLevel;
    
    }
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
      if (!IsEnabled(logLevel))
      {
        return;
      }
      TestContext.WriteLine($"{formatter(state, exception)}");
    }

    public bool IsEnabled(LogLevel logLevel)
    {
      return logLevel >= _logLevel;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
      return null;
    }

    private readonly LogLevel _logLevel;
  }
}
