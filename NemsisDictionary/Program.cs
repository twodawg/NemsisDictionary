using System;
using System.Linq;

namespace NemsisDictionary
{
  class Program
  {
    static void Main(string[] args)
    {
      var elementEnumerations = Lookup.GenerateElementEnumerations();

      // ePatient.14 2514009
      var lookup = elementEnumerations.FirstOrDefault(q => q.Code == "2514009" && 
        q.ElementNumber == "ePatient.14");

      Console.WriteLine($"ePatient.14 with code 2514009 is: { lookup?.CodeDescription }");

      while (true)
      {
        Console.Write("Enter a code: ");
        var input = Console.ReadLine();
        var variousLookup = elementEnumerations.FirstOrDefault(q => q.Code == input);

        Console.WriteLine($"code { input } is: { variousLookup?.CodeDescription }");
      }
    }    
  }
}