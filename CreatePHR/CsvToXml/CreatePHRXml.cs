using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using CsvToXml;
using System.Threading.Tasks;
using System.Text;
using System.Xml;


namespace CsvToXml
{
	public class CreatePHRXml
	{
		public CreatePHRXml()
		{
		}
		public void addPhr()
		{
			try
			{
				XmlDocument doc = new XmlDocument();

				System.IO.Directory.CreateDirectory("PHR/Logger");
				string logE = "";
				string logS = DateTime.Now.ToString();
				int count = 0;
				string id = "";

				using (FileStream fs = File.Open("person.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bs = new BufferedStream(fs))
				using (StreamReader sr = new StreamReader(bs))
				{

					// sr.ReadLine();


					string line;

					while (sr.Peek() != -1)
					{
						line = sr.ReadLine();
						var per = line.Split(',');
						char[] str = new char[] { };
						int[] x = new int[12];
						//int sum = 0;
						//int mod = 0;
						string sumMod = "";
						//int d = 13;

						try
						{
							str = per[1].ToCharArray(0, 13);
							sumMod = str[12].ToString();

							//for (int i = 0; i < str.Length; i++)
							//{
							//  Int32.TryParse(str[i].ToString(), out x[i]);

							//  sum += x[i] * d;
							//  d--;

							//}
							//mod = sum % 11;

							//if (mod > 1)
							//{
							//  sumMod = 11 - mod;
							//}
							//else if (mod <= 1)
							//{
							//  sumMod = 1 - mod;
							//}
							//else
							//{
							//  Console.WriteLine("Error");
							//}
						}
						catch (Exception ex)
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine(ex.ToString());
							logE += per[1].ToString();
							sumMod = "10";
						}

						//Console.WriteLine(sum+" = "+mod +" = "+ sumMod.ToString());
						System.IO.Directory.CreateDirectory("PHR/" + sumMod.ToString());

						string xmlPath = "PHR/" + sumMod.ToString() + "/" + per[1].Replace("/", "e") + ".xml";

						id = sumMod + "," + per[0] + "," + per[1] + "," + per[2] + "\n";

						try
						{
							using (StreamWriter sw = new StreamWriter(new FileStream(xmlPath, FileMode.Create)))
							{
								sw.WriteLine("<PHR_INFO MOPH_ID = \"\" IS_DEAD = \"\">");
								sw.WriteLine("<SIGN_LIST>");
								sw.WriteLine("<SIGN_INFO CID=\"" + per[1] + "\">");
								sw.WriteLine("<SECTION_LIST>");
							}

							using (StreamWriter streamWriter = new StreamWriter(new FileStream(xmlPath, FileMode.Append)))
							{


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


							}

							using (StreamWriter sw = new StreamWriter(new FileStream(xmlPath, FileMode.Append)))
							{
								sw.WriteLine("</SECTION_LIST>");
								sw.WriteLine("</SIGN_INFO>");
								sw.WriteLine("</SIGN_LIST>");
								sw.WriteLine("</PHR_INFO>");

							}

							using (StreamWriter streamWriter = new StreamWriter(new FileStream("PHR/ID.txt", FileMode.Append)))
							{
								streamWriter.Write(id);

							}
						}
						catch
						{
							logE = xmlPath.ToString();
						}

						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("Save XML " + per[1] + " files " + count);
						count++;
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/Logger/log.log", FileMode.Create)))
				{
					sw.WriteLine("PHR Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);
					sw.WriteLine("Error : " + logE.ToString());
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
