using Mir.AutoTests.TestEngine.CaptureElements;
using Mir.AutoTests.TestEngine.FinderContext;
using System.IO;

namespace SunriseTests.ElementsContext
{
  /// <summary>
  /// Контекст поисковика элементов для ПК Заря
  /// </summary>
  internal class SunriseFinderContext : FinderContextBase
  {
    static SunriseFinderContext() 
    {
      var config = new XmlConfigReader();
      ElementsContext = new ContextBase();
      var pathFile = Path.Combine(Directory.GetCurrentDirectory(),config.GetPathToFileKeysForTests());
      FinderContext.InitializationFinderContext(pathFile, ElementsContext);
    }
    /// <summary>
    /// Контекст поиска элементов
    /// </summary>
    public static IContext ElementsContext { get; }
  }
}
