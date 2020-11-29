using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;

namespace Mir.Utils.GeneratorCSVFile
{
  class Program
  {
    static void Main(string[] args)
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
      FileInfo file = new FileInfo(@"D:\Work\AutoTests\Scada3Tests\KeyForTests.xlsx");
      List<Worksheet> worksheet = new List<Worksheet>();
      Dictionary<string, Dictionary<string, string>> namesVariables = new Dictionary<string, Dictionary<string, string>>();
      using (_package = new ExcelPackage(file))
      {
        ExcelWorksheets worksheets = _package.Workbook.Worksheets;
        foreach (ExcelWorksheet workST in worksheets)
        {

          var cols = workST?.Dimension?.End?.Column;
          var rows = workST?.Dimension?.End?.Row;
          var name = workST?.Name;
          object[,] cells = (object[,])workST?.Cells?.Value;
          if (cols != null && rows != null && cells[0, 0] != null)
            worksheet.Add(new Worksheet((int)cols, (int)rows, name, cells));
        }
      }
      string path = @"D:\Work\AutoTests\Scada3Tests\KeyForTests\";

      foreach (Worksheet sheet in worksheet)
      {
        string csvData = "";
        for (int row = 0; row < sheet.rows; row++)
        {

          for (int col = 0; col < sheet.cols; col++)
          {
            csvData += sheet.cells[row, col]?.ToString() + ";";
          }
          csvData += "\n";
        }

        string output = path + sheet.nameWorksheet + ".csv";
        StreamWriter csv = new StreamWriter(@output, false, Encoding.UTF8);
        csv.Write(csvData);
        csv.Close();
      }
    }

    
    private static ExcelPackage _package;
  }
  class Worksheet
  {
    public Worksheet(int _cols, int _rows, string name, object[,] _cells)
    {
      cols = _cols;
      rows = _rows;
      nameWorksheet = name;
      cells = _cells;
    }

    public int cols;
    public int rows;
    public string nameWorksheet;
    public object[,] cells;
  }
}
