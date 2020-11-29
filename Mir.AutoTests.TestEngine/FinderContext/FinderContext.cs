using Mir.AutoTests.TestEngine.CaptureElements;
using Mir.AutoTests.TestEngine.ReadKeyFromFile;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Mir.AutoTests.TestEngine.FinderContext
{
  /// <summary>
  ///  Структура для ключей элементов
  /// </summary>
  internal struct TypeKey
  {
    public const string Id = nameof(Id);
    public const string CssSelector = nameof(CssSelector);
    public const string LinkText = nameof(LinkText);
    public const string XPath = nameof(XPath);
    public const string TagName = nameof(TagName);
    public const string ClassName = nameof(ClassName);
  };

  public class FinderContext
  {
    public static void InitializationFinderContext(string path, IContext context)
    {
      ReadFileKeyForTests.ReadingKeysFromCSVFileForWorksheets(path);
      FillContext(ReadFileKeyForTests.namesVariables,context);
    }
    private static void FillContext(Dictionary<string, Dictionary<string, string>> namesVariables, IContext context)
    {
      foreach (var nameElement in namesVariables.Keys)
      {
        Dictionary<string, string> coll = namesVariables[nameElement];
        List<CaptureMethod> list = new List<CaptureMethod>();

        foreach (var key in coll.Keys)
        {
          var captureMethod = coll[key];
          switch (key)
          {
            case TypeKey.Id:
              if (captureMethod != null)
                list.Add(new CaptureMethod(By.Id, captureMethod));
              break;
            case TypeKey.CssSelector:
              if (captureMethod != null)
                list.Add(new CaptureMethod(By.CssSelector, captureMethod));
              break;
            case TypeKey.LinkText:
              if (captureMethod != null)
                list.Add(new CaptureMethod(By.LinkText, captureMethod));
              break;
            case TypeKey.XPath:
              if (captureMethod != null)
                list.Add(new CaptureMethod(By.XPath, captureMethod));
              break;
            case TypeKey.TagName:
              if (captureMethod != null)
                list.Add(new CaptureMethod(By.TagName, captureMethod));
              break;
            case TypeKey.ClassName:
              if (captureMethod != null)
                list.Add(new CaptureMethod(By.ClassName, captureMethod));
              break;
          }
        }
        IReadOnlyList<CaptureMethod> captureMethods = list.AsReadOnly();
        context.AddOrUpdateCaptureMethods(nameElement, captureMethods.ToArray());
      }
    }
  }
}
