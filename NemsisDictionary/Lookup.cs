using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NemsisDictionary
{
  public class Lookup
  {
    public static List<ElementEnumerations> GenerateElementEnumerations()
    {
      var targetFile = $"{ Directory.GetCurrentDirectory() }\\Source\\Combined_ElementEnumerations.txt";
      var enumerationArray = File.ReadAllLines(targetFile);
      var results = new List<ElementEnumerations>();

      foreach (var line in enumerationArray.Skip(1))
      {
        var parsed = ParseLine(line);
        results.Add(parsed);
      }

      return results;
    }

    private static ElementEnumerations ParseLine(string line)
    {
      var fields = line.Trim(new char[] { '|' }).Split(new string[] { "'|'" }, StringSplitOptions.None);

      var enumeration = new ElementEnumerations
      {
        DatasetName = fields.FirstOrDefault(),
        ElementNumber = fields.Skip(1).FirstOrDefault(),
        ElementName = fields.Skip(2).FirstOrDefault(),
        Code = fields.Skip(3).FirstOrDefault(),
        CodeDescription = fields.LastOrDefault().Trim(new char[] { '\'' })
      };
      return enumeration;
    }
  }
}
