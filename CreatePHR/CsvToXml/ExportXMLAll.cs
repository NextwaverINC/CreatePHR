using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using CsvToXml;
using System.Text;

namespace CsvToXml
{
    public class ExportXMLAll
    {
        public ExportXMLAll()
        {
        }
        public void Export(string csvPath)
        {
            try
            {
                int n = 0;
                string id = "";
				
				using (FileStream fs = File.Open(csvPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bs = new BufferedStream(fs))
				using (StreamReader sr = new StreamReader(bs))
				{
					string line;
                    sr.ReadLine().Skip(1);

                    while ((line = sr.ReadLine())!= null)
					{
						var per = line.Split(',');

						Directory.CreateDirectory("PHR/" + per[0]);

						string xmlPath = "PHR/" + per[0] + "/" + per[1].Replace("/","e") + ".xml";

						id = per[1] + "," + per[0] + "," + per[2] + "\n";
						
						using (StreamWriter sw = new StreamWriter(new FileStream(xmlPath, FileMode.Create)))
						{
							sw.WriteLine("<PHR_INFO MOPH_ID = \"\" IS_DEAD = \"\">");
							sw.WriteLine("<SIGN_LIST>");
							sw.WriteLine("<SIGN_INFO CID=\"" + per[1] + "\">");
							sw.WriteLine("<SECTION_LIST>");
						}

						using (StreamWriter streamWriter = new StreamWriter(new FileStream(xmlPath, FileMode.Append)))
						{
							Console.BackgroundColor = ConsoleColor.Red;
							Console.WriteLine("");
							Console.WriteLine("Saving XML files...");

							streamWriter.WriteLine("<PERSON_LIST>");
							streamWriter.WriteLine("</PERSON_LIST>");

							streamWriter.WriteLine("<ACCIDENT_LIST>");
							streamWriter.WriteLine("</ACCIDENT_LIST>");

							streamWriter.WriteLine("<ADDRESS_LIST>");
							streamWriter.WriteLine("</ADDRESS_LIST>");

							streamWriter.WriteLine("<ADMISSION_LIST>");
							streamWriter.WriteLine("</ADMISSION_LIST>");

							streamWriter.WriteLine("<ANC_LIST>");
							streamWriter.WriteLine("</ANC_LIST>");

							streamWriter.WriteLine("<APPOINTMENT_LIST>");
							streamWriter.WriteLine("</APPOINTMENT_LIST>");

							streamWriter.WriteLine("<CARD_LIST>");
							streamWriter.WriteLine("</CARD_LIST>");

							streamWriter.WriteLine("<CARE_REFER_LIST>");
							streamWriter.WriteLine("</CARE_REFER_LIST>");

							streamWriter.WriteLine("<CHARGE_IPD_LIST>");
							streamWriter.WriteLine("</CHARGE_IPD_LIST>");

							streamWriter.WriteLine("<CHARGE_OPD_LIST>");
							streamWriter.WriteLine("</CHARGE_OPD_LIST>");

							streamWriter.WriteLine("<CHRONIC_LIST>");
							streamWriter.WriteLine("</CHRONIC_LIST>");

							streamWriter.WriteLine("<CHRONICFU_LIST>");
							streamWriter.WriteLine("</CHRONICFU_LIST>");

							streamWriter.WriteLine("<CLINICAL_REFER_LIST>");
							streamWriter.WriteLine("</CLINICAL_REFER_LIST>");

							streamWriter.WriteLine("<COMMUNITY_ACTIVITY_LIST>");
							streamWriter.WriteLine("</COMMUNITY_ACTIVITY_LIST>");

							streamWriter.WriteLine("<COMMUNITY_SERVICE_LIST>");
							streamWriter.WriteLine("</COMMUNITY_SERVICE_LIST>");

							streamWriter.WriteLine("<DEATH_LIST>");
							streamWriter.WriteLine("</DEATH_LIST>");

							streamWriter.WriteLine("<DENTAL_LIST>");
							streamWriter.WriteLine("</DENTAL_LIST>");

							streamWriter.WriteLine("<DIAGNOSIS_IPD_LIST>");
							streamWriter.WriteLine("</DIAGNOSIS_IPD_LIST>");

							streamWriter.WriteLine("<DIAGNOSIS_OPD_LIST>");
							streamWriter.WriteLine("</DIAGNOSIS_OPD_LIST>");

							streamWriter.WriteLine("<DISABILITY_LIST>");
							streamWriter.WriteLine("</DISABILITY_LIST>");

							streamWriter.WriteLine("<DRUG_IPD_LIST>");
							streamWriter.WriteLine("</DRUG_IPD_LIST>");

							streamWriter.WriteLine("<DRUG_OPD_LIST>");
							streamWriter.WriteLine("</DRUG_OPD_LIST>");

							streamWriter.WriteLine("<DRUG_REFER_LIST>");
							streamWriter.WriteLine("</DRUG_REFER_LIST>");

							streamWriter.WriteLine("<DRUGALLERGY_LIST>");
							streamWriter.WriteLine("</DRUGALLERGY_LIST>");

							streamWriter.WriteLine("<EPI_LIST>");
							streamWriter.WriteLine("</EPI_LIST>");

							streamWriter.WriteLine("<FP_LIST>");
							streamWriter.WriteLine("</FP_LIST>");

							streamWriter.WriteLine("<FUNCTIONAL_LIST>");
							streamWriter.WriteLine("</FUNCTIONAL_LIST>");

							streamWriter.WriteLine("<HOME_LIST>");
							streamWriter.WriteLine("</HOME_LIST>");

							streamWriter.WriteLine("<ICF_LIST>");
							streamWriter.WriteLine("</ICF_LIST>");

							streamWriter.WriteLine("<INVESTIGATION_REFER_LIST>");
							streamWriter.WriteLine("</INVESTIGATION_REFER_LIST>");

							streamWriter.WriteLine("<LABFU_LIST>");
							streamWriter.WriteLine("</LABFU_LIST>");

							streamWriter.WriteLine("<LABOR_LIST>");
							streamWriter.WriteLine("</LABOR_LIST>");

							streamWriter.WriteLine("<NCDSCREEN_LIST>");
							streamWriter.WriteLine("</NCDSCREEN_LIST>");

							streamWriter.WriteLine("<NEWBORN_LIST>");
							streamWriter.WriteLine("</NEWBORN_LIST>");

							streamWriter.WriteLine("<NEWBORNCARE_LIST>");
							streamWriter.WriteLine("</NEWBORNCARE_LIST>");

							streamWriter.WriteLine("<NUTRITRION_LIST>");
							streamWriter.WriteLine("</NUTRITRION_LIST>");

							streamWriter.WriteLine("<POSTNATAL_LIST>");
							streamWriter.WriteLine("</POSTNATAL_LIST>");

							streamWriter.WriteLine("<PRENATAL_LIST>");
							streamWriter.WriteLine("</PRENATAL_LIST>");

							streamWriter.WriteLine("<PROCEDURE_IPD_LIST>");
							streamWriter.WriteLine("</PROCEDURE_IPD_LIST>");

							streamWriter.WriteLine("<PROCEDURE_OPD_LIST>");
							streamWriter.WriteLine("</PROCEDURE_OPD_LIST>");

							streamWriter.WriteLine("<PROCEDURE_REFER_LIST>");
							streamWriter.WriteLine("</PROCEDURE_REFER_LIST>");

							streamWriter.WriteLine("<PROVIDER_LIST>");
							streamWriter.WriteLine("</PROVIDER_LIST>");

							streamWriter.WriteLine("<REFER_HISTORY_LIST>");
							streamWriter.WriteLine("</REFER_HISTORY_LIST>");

							streamWriter.WriteLine("<REFER_RESULT_LIST>");
							streamWriter.WriteLine("</REFER_RESULT_LIST>");

							streamWriter.WriteLine("<REHABILITATION_LIST>");
							streamWriter.WriteLine("</REHABILITATION_LIST>");

							streamWriter.WriteLine("<SERVICE_LIST>");
							streamWriter.WriteLine("</SERVICE_LIST>");

							streamWriter.WriteLine("<SPECIALPP_LIST>");
							streamWriter.WriteLine("</SPECIALPP_LIST>");

							streamWriter.WriteLine("<SURVEILLANCE_LIST>");
							streamWriter.WriteLine("</SURVEILLANCE_LIST>");

							streamWriter.WriteLine("<VILLAGE_LIST>");
							streamWriter.WriteLine("</VILLAGE_LIST>");

							streamWriter.WriteLine("<WOMEN_LIST>");
							streamWriter.WriteLine("</WOMEN_LIST>");

							Console.BackgroundColor = ConsoleColor.Green;
							n++;

							Console.WriteLine("Save XML " + per[1] + " files " + n);
						}

						using (StreamWriter sw = new StreamWriter(new FileStream(xmlPath, FileMode.Append)))
						{
							sw.WriteLine("</SECTION_LIST>");
							sw.WriteLine("</SIGN_INFO>");
							sw.WriteLine("</SIGN_LIST>");
							sw.WriteLine("</PHR_INFO>");

						}
						using (StreamWriter streamWriter = new StreamWriter(new FileStream("PHR/" + per[0] + "/" + "/ID.txt", FileMode.Append)))
						{
							streamWriter.Write(id);
						}

					}
				}
           
            }
			catch (Exception excep)
			{
				Console.BackgroundColor = ConsoleColor.Red;
				Console.WriteLine("");
				Console.WriteLine("Error ..." + excep);
				Console.WriteLine("");
			}
        }
    }
}
