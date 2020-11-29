using Mir.AutoTests.TestEngine.CaptureElements;
using Mir.AutoTests.TestEngine.FinderContext;
using System.IO;

namespace Scada3Tests.ElementsContext
{
  /// <summary>
  /// Контекст поисковика элементов для ПК Скада
  /// </summary>
  internal class Scada3FinderContext : FinderContextBase
  {
    static Scada3FinderContext() 
    {
      var config = new XmlConfigReader();
      ElementsContext = new ContextBase();
      var pathFile = Path.Combine(Directory.GetCurrentDirectory(), config.GetPathToFileKeysForTests());
      FinderContext.InitializationFinderContext(pathFile, ElementsContext);
    }
  
    /// <summary>
    /// Контекст поиска элементов
    /// </summary>
    public static IContext ElementsContext { get; }
  }
}
