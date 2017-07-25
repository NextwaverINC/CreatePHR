using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CsvToXml
{
    public class SortCSV
    {
        public void Sort(string filePath,int sort)
        {
			try
			{
				var lines = File.ReadAllLines(filePath, Encoding.UTF8).Skip(1);
				var sorted = lines.Select(line => new
				{
					SortKey = Int64.Parse(line.Split(',')[sort]),
					Line = line

				}
		   ).OrderBy(x => x.SortKey).Select(x => x.Line);
				File.WriteAllLines(filePath, lines.Take(1).Concat(sorted), Encoding.UTF8);

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(filePath.ToString() + " Done.");
			}
			catch
			{
			    Console.ForegroundColor = ConsoleColor.Red;
			    Console.WriteLine(filePath.ToString() + " Error.");
			}
		
        }
    }
}
