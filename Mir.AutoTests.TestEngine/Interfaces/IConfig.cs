using Mir.AutoTests.TestEngine.Configuration;

namespace Mir.AutoTests.TestEngine.Interfaces
{
    /// <summary>
    /// This interface for work with configuration file
    /// </summary>
    public interface IConfig
    {
        string GetLogin();
        string GetPassword();
        string GetUrl();
        string GetPathToFileKeysForTests();
        BrowserType GetBrowser();
    }
}
