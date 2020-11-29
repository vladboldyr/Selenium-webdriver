using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Mir.AutoTests.TestEngine.CustomLogger
{
  public class CustomLoggerProviderConsole: ILoggerProvider
  {
    public ILogger CreateLogger(string categoryName)
    {
      if (null == m_logger)
      {
        m_logger = new CustomLoggerConsol();
      }

      return m_logger;
    }

    #region IDisposable Support

    protected virtual void Dispose(bool disposing)
    {
      if (!m_disposed)
      {
        if (disposing)
        {
          m_logger = null;
        }

        m_disposed = true;
      }
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      Dispose(true);
    }
    #endregion

    ILogger m_logger;
    private bool m_disposed = false; // To detect redundant calls
  }
}
