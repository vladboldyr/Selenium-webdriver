using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mir.AutoTests.TestEngine.ReadKeyFromFile
{
  public static class ReadFileKeyForTests
  {
    public static Dictionary<string, Dictionary<string,string>> namesVariables = new Dictionary<string, Dictionary<string, string>>();

    public static void ReadingKeysFromCSVFileForWorksheets(string pathDir)
    {
      string pathToDirec = Path.GetFullPath(pathDir);
      List<string> files = Directory.GetFiles(pathToDirec).ToList();
      string[] keyType = { "Id", "CssSelector", "LinkText", "XPath", "TagName", "ClassName", "Description" };
      foreach (string name in files)
      {
        string[] lines = File.ReadAllLines(name);
        lines = lines.Skip(1).ToArray();//Пропускаем первую строку,т.к нет смысла ее читать,там заголовок таблицы
        foreach (string line in lines)
        {
          string[] values = line./*Remove(line.LastIndexOf(';'))*/Split(';');// Строка с названием переменной и ключами
          //КОСТЫЛЬ!!!!!!!!!!!
          int len = values[values.Length-1] == "" ? values.Length - 1 : values.Length;
          string nameElement = values[0];
          var key = new Dictionary<string, string>();
          int indexKeyType = 0;
          for (int index = 1; index < len; ++index)
          {
            key.Add(keyType[indexKeyType], values[index]);
            ++indexKeyType;
          }
          namesVariables.Add(nameElement, key);
        }
      }
    }
  }
}
