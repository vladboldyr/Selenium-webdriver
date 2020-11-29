using Mir.AutoTests.TestEngine.ReadKeyFromFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mir.AutoTests.Utils.ConstsGenerator
{
  public class Program
  {
    //Аргументы имя_Namespace, имя_класса, путь_к_каталогу_контекста(куда генерить файл), путь от куда брать ключи
    static void Main(string[] args)
    {
      string namSpace = args[0];
      string nameClass = args[1];
      string destDir = args[2];
      string pathDir = args[3];

      ReadFileKeyForTests.ReadingKeysFromCSVFileForWorksheets(pathDir);

      var constsBuilder = new StringBuilder();
      foreach (var k in ReadFileKeyForTests.namesVariables.Keys)
      {
        Dictionary<string, string> coll = ReadFileKeyForTests.namesVariables[k];
        string description = coll["Description"];
        constsBuilder.Append("\t\t/// <summary>");
        constsBuilder.Append(Environment.NewLine);
        constsBuilder.Append("\t\t///");
        constsBuilder.Append(description);
        constsBuilder.Append(Environment.NewLine);
        constsBuilder.Append("\t\t/// </summary>");
        constsBuilder.Append(Environment.NewLine);
        constsBuilder.Append("\t\t");
        constsBuilder.AppendFormat(ConstTemplate, k);
        constsBuilder.Append(Environment.NewLine);
      }
      object[] argsForInsertString = { namSpace, nameClass, constsBuilder.ToString() };
      string res = string.Format(MainTemplate, argsForInsertString);
      File.WriteAllText($"{Path.Combine(destDir, nameClass)}.cs", res);
    }

    private const string ConstTemplate = "public const string {0} = nameof({0});";
    private static readonly string MainTemplate = 
    "namespace {0} " + Environment.NewLine +
     "{{" + Environment.NewLine +
      "\tinternal class {1}" + Environment.NewLine +
      "\t{{" + Environment.NewLine +
      "{2}" + Environment.NewLine +
      "\t}}" + Environment.NewLine +
      "}}";
  }
}
