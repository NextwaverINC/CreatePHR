using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using CsvToXml;
using System.Text;

namespace CsvToXml
{
    public class CreateChangwat
    {
        public CreateChangwat()
        {
        }
		public void Export()
		{
			try
			{
				string id = "";

				using (FileStream fs = File.Open("address.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bs = new BufferedStream(fs))
				using (StreamReader sr = new StreamReader(bs))
				{
					string line;
					sr.ReadLine().Skip(1);

					while ((line = sr.ReadLine()) != null)
					{
						var address = line.Split(',');

						Directory.CreateDirectory("PHR/" + address[15]);

                        string xmlPath = "PHR/" + address[15]+"/"+address[0]+address[1]+".xml";

						id = address[0] + "," + address[1] + "," + address[15] + "\n";


						using (StreamWriter streamWriter = new StreamWriter(new FileStream("PHR/ID.txt", FileMode.Append)))
						{
							streamWriter.Write(id);
						}

                            using (StreamWriter streamWriter = new StreamWriter(new FileStream(xmlPath, FileMode.Create)))
                        {
                            streamWriter.Write(xmlPath);
                        }

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
