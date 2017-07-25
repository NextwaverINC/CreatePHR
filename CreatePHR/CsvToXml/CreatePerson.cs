using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using CsvToXml;
using System.Text;

namespace CsvToXml
{
    public class CreatePerson
    {
        public CreatePerson()
        {
        }
		public void Export()
		{
			try
			{
				string id = "";

				using (FileStream fs = File.Open("person.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bs = new BufferedStream(fs))
				using (StreamReader sr = new StreamReader(bs))
				{
					string line;
					sr.ReadLine().Skip(1);

					while ((line = sr.ReadLine()) != null)
					{
						var person = line.Split(',');

						//Directory.CreateDirectory("PHR/" + address[15]);

						//string xmlPath = "PHR/" + address[15] + "/" + address[0] + address[1] + ".xml";

						id = person[0] + "," + person[1] + "," + person[2] + "\n";


						using (StreamWriter streamWriter = new StreamWriter(new FileStream("PHR/IDPERSON.txt", FileMode.Append)))
						{
							streamWriter.Write(id);
						}

						//using (StreamWriter streamWriter = new StreamWriter(new FileStream(xmlPath, FileMode.Create)))
						//{
						//	streamWriter.Write(xmlPath);
						//}

					}
				}

			}
			catch (Exception excep)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("");
				Console.WriteLine("Error ..." + excep);
				Console.WriteLine("");
			}
		}
    }
}
