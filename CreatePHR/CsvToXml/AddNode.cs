using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;

namespace CsvToXml
{
    public class AddNode
    {
        public AddNode()
        {
        }

		public void addNodePerson()
		{
			XmlDocument doc = new XmlDocument();
			EncodingString encode = new EncodingString();
			try
			{
				int count = 0;
				System.IO.Directory.CreateDirectory("PHR/Logger");
				string logS = DateTime.Now.ToString();
				string logE = "";

				using (FileStream pr = File.Open("person.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
					// srpr.ReadLine();

					for (int i = 0; i < count; i++)
					    srpr.ReadLine();

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');
						char[] str = new char[] { };
						int[] x = new int[12];
						int sum = 0;
						//int mod = 0;
						string sumMod = "";
						//int d = 13;
						try
						{
							str = l[1].ToCharArray(0, 13);
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
						catch
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine(l[1] + " " + "Error");
							logE += l[1].ToString();
							sumMod = "10";
						}


						try
						{

							using (StreamReader sr = new StreamReader(new FileStream("PHR/" + sumMod + "/" + l[1].Replace("/", "e") + ".xml", FileMode.Open)))
							{
								doc.Load(sr);

								XmlNodeList nodes = doc.GetElementsByTagName("PERSON_LIST");

								XmlNode person = doc.CreateElement("PERSON_INFO");

								XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
								hospcode.Value = l[0];
								person.Attributes.Append(hospcode);

								XmlAttribute cid = doc.CreateAttribute("CID");
								cid.Value = l[1];
								person.Attributes.Append(cid);

								XmlAttribute pid = doc.CreateAttribute("PID");
								pid.Value = l[2];
								person.Attributes.Append(pid);

								XmlAttribute hid = doc.CreateAttribute("HID");
								hid.Value = l[3];
								person.Attributes.Append(hid);

								XmlAttribute prename = doc.CreateAttribute("PRENAME");
								prename.Value = l[4];
								person.Attributes.Append(prename);

								XmlAttribute name = doc.CreateAttribute("NAME");
								name.Value = encode.PercentEncode(l[5]);
								person.Attributes.Append(name);

								XmlAttribute lname = doc.CreateAttribute("LNAME");
								lname.Value = encode.PercentEncode(l[6]);
								person.Attributes.Append(lname);

								XmlAttribute hn = doc.CreateAttribute("HN");
								hn.Value = l[7];
								person.Attributes.Append(hn);

								XmlAttribute sex = doc.CreateAttribute("SEX");
								sex.Value = l[8];
								person.Attributes.Append(sex);

								XmlAttribute birth = doc.CreateAttribute("BIRTH");
								birth.Value = l[9];
								person.Attributes.Append(birth);

								XmlAttribute mstatus = doc.CreateAttribute("MSTATUS");
								mstatus.Value = l[10];
								person.Attributes.Append(mstatus);

								XmlAttribute occupation_old = doc.CreateAttribute("OCCUPATION_OLD");
								occupation_old.Value = l[11];
								person.Attributes.Append(occupation_old);

								XmlAttribute occupation_new = doc.CreateAttribute("OCCUPATION_NEW");
								occupation_new.Value = l[12];
								person.Attributes.Append(occupation_new);

								XmlAttribute race = doc.CreateAttribute("RACE");
								race.Value = l[13];
								person.Attributes.Append(race);

								XmlAttribute nation = doc.CreateAttribute("NATION");
								nation.Value = l[14];
								person.Attributes.Append(nation);

								XmlAttribute religion = doc.CreateAttribute("RELIGION");
								religion.Value = l[15];
								person.Attributes.Append(religion);

								XmlAttribute education = doc.CreateAttribute("EDUCATION");
								education.Value = l[16];
								person.Attributes.Append(education);

								XmlAttribute fstatus = doc.CreateAttribute("FSTATUS");
								fstatus.Value = l[17];
								person.Attributes.Append(fstatus);

								XmlAttribute father = doc.CreateAttribute("FATHER");
								father.Value = l[18];
								person.Attributes.Append(father);

								XmlAttribute mother = doc.CreateAttribute("MOTHER");
								mother.Value = l[19];
								person.Attributes.Append(mother);

								XmlAttribute couple = doc.CreateAttribute("COUPLE");
								couple.Value = l[20];
								person.Attributes.Append(couple);

								XmlAttribute vstatus = doc.CreateAttribute("VSTATUS");
								vstatus.Value = l[21];
								person.Attributes.Append(vstatus);

								XmlAttribute movein = doc.CreateAttribute("MOVEIN");
								movein.Value = l[22];
								person.Attributes.Append(movein);

								XmlAttribute discharge = doc.CreateAttribute("DISCHARGE");
								discharge.Value = l[23];
								person.Attributes.Append(discharge);

								XmlAttribute ddischarge = doc.CreateAttribute("DDISCHARGE");
								ddischarge.Value = l[24];
								person.Attributes.Append(ddischarge);

								XmlAttribute abogroup = doc.CreateAttribute("ABOGROUP");
								abogroup.Value = l[25];
								person.Attributes.Append(abogroup);

								XmlAttribute rhgroup = doc.CreateAttribute("RHGROUP");
								rhgroup.Value = l[26];
								person.Attributes.Append(rhgroup);

								XmlAttribute labor = doc.CreateAttribute("LABOR");
								labor.Value = l[27];
								person.Attributes.Append(labor);

								XmlAttribute passport = doc.CreateAttribute("PASSPORT");
								passport.Value = l[28];
								person.Attributes.Append(passport);

								XmlAttribute typearea = doc.CreateAttribute("TYPEAREA");
								typearea.Value = l[29];
								person.Attributes.Append(typearea);

								XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
								d_update.Value = l[30];
								person.Attributes.Append(d_update);

								nodes.Item(0).AppendChild(person);

								using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + sumMod.ToString() + "/" + l[1] + ".xml", FileMode.Create)))
								{
									doc.Save(sw);
									Console.ForegroundColor = ConsoleColor.Green;
									Console.WriteLine(l[1] + " " + "Macth!" + " " + count);
									count++;
								}
							}

						}
						catch
						{
							logE = sum + "/" + l[1].ToString();
							continue;
						}

					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/Logger/Personlog.log", FileMode.Create)))
				{
					sw.WriteLine("Person Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);
					sw.WriteLine("Error : " + logE);

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

        public void addNodeAccident()
        {

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				Regex re = new Regex(@"\w+");
				foreach (string line in File.ReadLines("accident.csv"))
				{
					var l = line.Split(',');

                    foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
                    {
                        var matches = re.Matches(lineid.ToString());
                        foreach (var m in matches)
                        {
                            if (l[1].Contains(m.ToString()))
                            {
                                if (m.ToString() == l[1].ToString())
                                {
                                    try
                                    {

                                        using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
                                        {
                                            doc.Load(sr);

                                            XmlNodeList nodes = doc.GetElementsByTagName("ACCIDENT_LIST");

                                            XmlNode accident = doc.CreateElement("ACCIDENT_INFO");

                                            XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
                                            hospcode.Value = l[0];

                                            XmlAttribute pid = doc.CreateAttribute("PID");
                                            pid.Value = l[1];

                                            XmlAttribute seq = doc.CreateAttribute("SEQ");
                                            seq.Value = l[2];

                                            XmlAttribute datetime_serv = doc.CreateAttribute("DATETIME_SERV");
                                            datetime_serv.Value = l[3];

                                            XmlAttribute datetime_ae = doc.CreateAttribute("DATETIME_AE");
                                            datetime_ae.Value = l[4];

                                            XmlAttribute aetype = doc.CreateAttribute("AETYPE");
                                            aetype.Value = l[5];

                                            XmlAttribute aeplace = doc.CreateAttribute("AEPLACE");
                                            aeplace.Value = l[6];

                                            XmlAttribute typein_ae = doc.CreateAttribute("TYPEIN_AE");
                                            typein_ae.Value = l[7];

                                            XmlAttribute traffic = doc.CreateAttribute("TRAFFIC");
                                            traffic.Value = l[8];

                                            XmlAttribute vehicle = doc.CreateAttribute("VEHICLE");
                                            vehicle.Value = l[9];

                                            XmlAttribute alcohol = doc.CreateAttribute("ALCOHOL");
                                            alcohol.Value = l[10];

                                            XmlAttribute nacrotic_drug = doc.CreateAttribute("NACROTIC_DRUG");
                                            nacrotic_drug.Value = l[11];

                                            XmlAttribute belt = doc.CreateAttribute("BELT");
                                            belt.Value = l[12];

                                            XmlAttribute helmet = doc.CreateAttribute("HELMET");
                                            helmet.Value = l[13];

                                            XmlAttribute airway = doc.CreateAttribute("AIRWAY");
                                            airway.Value = l[14];

                                            XmlAttribute stopbleed = doc.CreateAttribute("STOPBLEED");
                                            stopbleed.Value = l[15];

                                            XmlAttribute splint = doc.CreateAttribute("SPLINT");
                                            splint.Value = l[16];

                                            XmlAttribute fluid = doc.CreateAttribute("FLUID");
                                            fluid.Value = l[17];

                                            XmlAttribute urgency = doc.CreateAttribute("URGENCY");
                                            urgency.Value = l[18];

                                            XmlAttribute coma_eye = doc.CreateAttribute("COMA_EYE");
                                            coma_eye.Value = l[19];

                                            XmlAttribute coma_speak = doc.CreateAttribute("COMA_SPEAK");
                                            coma_speak.Value = l[20];

                                            XmlAttribute coma_movement = doc.CreateAttribute("COMA_MOVEMENT");
                                            coma_movement.Value = l[21];

                                            XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
                                            d_update.Value = l[22];

                                            accident.Attributes.Append(hospcode);
                                            accident.Attributes.Append(pid);
                                            accident.Attributes.Append(seq);
                                            accident.Attributes.Append(datetime_serv);
                                            accident.Attributes.Append(datetime_ae);
                                            accident.Attributes.Append(aetype);
                                            accident.Attributes.Append(aeplace);
                                            accident.Attributes.Append(typein_ae);
                                            accident.Attributes.Append(traffic);
                                            accident.Attributes.Append(vehicle);
                                            accident.Attributes.Append(alcohol);
                                            accident.Attributes.Append(nacrotic_drug);
                                            accident.Attributes.Append(belt);
                                            accident.Attributes.Append(helmet);
                                            accident.Attributes.Append(airway);
                                            accident.Attributes.Append(stopbleed);
                                            accident.Attributes.Append(splint);
                                            accident.Attributes.Append(fluid);
                                            accident.Attributes.Append(urgency);
                                            accident.Attributes.Append(coma_eye);
                                            accident.Attributes.Append(coma_speak);
                                            accident.Attributes.Append(coma_movement);
                                            accident.Attributes.Append(d_update);

                                            nodes.Item(0).AppendChild(accident);

                                            using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
                                            {

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("[ accident ]"+matches[3].ToString() + " " + l[1] + " " + count);
                                                Console.WriteLine("Add Success");
                                                doc.Save(sw);

                                                count++;
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Add Fail!");
                                        count++;
                                        continue;
                                    }

                                }
                            }

                        }

                    }
				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/Logger/AccidentLog.log", FileMode.Create)))
				{
					sw.WriteLine("Accident Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeAddress()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("address.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
                            Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("ADDRESS_LIST");

												XmlNode address = doc.CreateElement("ADDRESS_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												address.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												address.Attributes.Append(pid);
												XmlAttribute addresstype = doc.CreateAttribute("ADDRESSTYPE");
												addresstype.Value = l[2];
												address.Attributes.Append(addresstype);
												XmlAttribute house_id = doc.CreateAttribute("HOUSE_ID");
												house_id.Value = l[3];
												address.Attributes.Append(house_id);
												XmlAttribute housetype = doc.CreateAttribute("HOUSETYPE");
												housetype.Value = l[4];
												address.Attributes.Append(housetype);
												XmlAttribute roomno = doc.CreateAttribute("ROOMNO");
												roomno.Value = l[5];
												address.Attributes.Append(roomno);
												XmlAttribute condo = doc.CreateAttribute("CONDO");
												condo.Value = l[6];
												address.Attributes.Append(condo);
												XmlAttribute houseno = doc.CreateAttribute("HOUSENO");
												houseno.Value = l[7];
												address.Attributes.Append(houseno);
												XmlAttribute soisub = doc.CreateAttribute("SOISUB");
												soisub.Value = l[8];
												address.Attributes.Append(soisub);
												XmlAttribute soimain = doc.CreateAttribute("SOIMAIN");
												soimain.Value = l[9];
												address.Attributes.Append(soimain);
												XmlAttribute road = doc.CreateAttribute("ROAD");
												road.Value = l[10];
												address.Attributes.Append(road);
												XmlAttribute villaname = doc.CreateAttribute("VILLANAME");
												villaname.Value = l[11];
												address.Attributes.Append(villaname);
												XmlAttribute village = doc.CreateAttribute("VILLAGE");
												village.Value = l[12];
												address.Attributes.Append(village);
												XmlAttribute tambon = doc.CreateAttribute("TAMBON");
												tambon.Value = l[13];
												address.Attributes.Append(tambon);
												XmlAttribute ampur = doc.CreateAttribute("AMPUR");
												ampur.Value = l[14];
												address.Attributes.Append(ampur);
												XmlAttribute changwat = doc.CreateAttribute("CHANGWAT");
												changwat.Value = l[15];
												address.Attributes.Append(changwat);
												XmlAttribute telephone = doc.CreateAttribute("TELEPHONE");
												telephone.Value = l[16];
												address.Attributes.Append(telephone);
												XmlAttribute mobile = doc.CreateAttribute("MOBILE");
												mobile.Value = l[17];
												address.Attributes.Append(mobile);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[18];
												address.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(address);

												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ address ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/AddressLog.log", FileMode.Create)))
				{
					sw.WriteLine("Adress Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeAdmission()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("admission.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
				
					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("ADMISSION_LIST");

												XmlNode admission = doc.CreateElement("ADMISSION_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												admission.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												admission.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												admission.Attributes.Append(seq);
												XmlAttribute an = doc.CreateAttribute("AN");
												an.Value = l[3];
												admission.Attributes.Append(an);
												XmlAttribute datetime_admit = doc.CreateAttribute("DATETIME_ADMIT");
												datetime_admit.Value = l[4];
												admission.Attributes.Append(datetime_admit);
												XmlAttribute wardadmit = doc.CreateAttribute("WARDADMIT");
												wardadmit.Value = l[5];
												admission.Attributes.Append(wardadmit);
												XmlAttribute instype = doc.CreateAttribute("INSTYPE");
												instype.Value = l[6];
												admission.Attributes.Append(instype);
												XmlAttribute typein = doc.CreateAttribute("TYPEIN");
												typein.Value = l[7];
												admission.Attributes.Append(typein);
												XmlAttribute referinhosp = doc.CreateAttribute("REFERINHOSP");
												referinhosp.Value = l[8];
												admission.Attributes.Append(referinhosp);
												XmlAttribute causein = doc.CreateAttribute("CAUSEIN");
												causein.Value = l[9];
												admission.Attributes.Append(causein);
												XmlAttribute admitweight = doc.CreateAttribute("ADMITWEIGHT");
												admitweight.Value = l[10];
												admission.Attributes.Append(admitweight);
												XmlAttribute admitheight = doc.CreateAttribute("ADMITHEIGHT");
												admitheight.Value = l[11];
												admission.Attributes.Append(admitheight);
												XmlAttribute datetime_disch = doc.CreateAttribute("DATETIME_DISCH");
												datetime_disch.Value = l[12];
												admission.Attributes.Append(datetime_disch);
												XmlAttribute warddisch = doc.CreateAttribute("WARDDISCH");
												warddisch.Value = l[13];
												admission.Attributes.Append(warddisch);
												XmlAttribute dischstatus = doc.CreateAttribute("DISCHSTATUS");
												dischstatus.Value = l[14];
												admission.Attributes.Append(dischstatus);
												XmlAttribute dischtype = doc.CreateAttribute("DISCHTYPE");
												dischtype.Value = l[15];
												admission.Attributes.Append(dischtype);
												XmlAttribute referouthosp = doc.CreateAttribute("REFEROUTHOSP");
												referouthosp.Value = l[16];
												admission.Attributes.Append(referouthosp);
												XmlAttribute causeout = doc.CreateAttribute("CAUSEOUT");
												causeout.Value = l[17];
												admission.Attributes.Append(causeout);
												XmlAttribute cost = doc.CreateAttribute("COST");
												cost.Value = l[18];
												admission.Attributes.Append(cost);
												XmlAttribute price = doc.CreateAttribute("PRICE");
												price.Value = l[19];
												admission.Attributes.Append(price);
												XmlAttribute payprice = doc.CreateAttribute("PAYPRICE");
												payprice.Value = l[20];
												admission.Attributes.Append(payprice);
												XmlAttribute actualpay = doc.CreateAttribute("ACTUALPAY");
												actualpay.Value = l[21];
												admission.Attributes.Append(actualpay);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[22];
												admission.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[23];
												admission.Attributes.Append(d_update);
												XmlAttribute drg = doc.CreateAttribute("DRG");
												drg.Value = l[24];
												admission.Attributes.Append(drg);
												XmlAttribute rw = doc.CreateAttribute("RW");
												rw.Value = l[25];
												admission.Attributes.Append(rw);
												XmlAttribute adjrw = doc.CreateAttribute("ADJRW");
												adjrw.Value = l[26];
												admission.Attributes.Append(adjrw);
												XmlAttribute error = doc.CreateAttribute("ERROR");
												error.Value = l[27];
												admission.Attributes.Append(error);
												XmlAttribute warning = doc.CreateAttribute("WARNING");
												warning.Value = l[28];
												admission.Attributes.Append(warning);
												XmlAttribute actlos = doc.CreateAttribute("ACTLOS");
												actlos.Value = l[29];
												admission.Attributes.Append(actlos);
												XmlAttribute grouper_version = doc.CreateAttribute("GROUPER_VERSION");
												grouper_version.Value = l[30];
												admission.Attributes.Append(grouper_version);


												nodes.Item(0).AppendChild(admission);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ admission ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/AdmissionLog.log", FileMode.Create)))
				{
					sw.WriteLine("Admission Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeAnc()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("anc.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
					

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("ANC_LIST");

												XmlNode anc = doc.CreateElement("ANC_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												anc.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												anc.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												anc.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												anc.Attributes.Append(date_serv);
												XmlAttribute gravida = doc.CreateAttribute("GRAVIDA");
												gravida.Value = l[4];
												anc.Attributes.Append(gravida);
												XmlAttribute ancno = doc.CreateAttribute("ANCNO");
												ancno.Value = l[5];
												anc.Attributes.Append(ancno);
												XmlAttribute ga = doc.CreateAttribute("GA");
												ga.Value = l[6];
												anc.Attributes.Append(ga);
												XmlAttribute ancresult = doc.CreateAttribute("ANCRESULT");
												ancresult.Value = l[7];
												anc.Attributes.Append(ancresult);
												XmlAttribute ancplace = doc.CreateAttribute("ANCPLACE");
												ancplace.Value = l[8];
												anc.Attributes.Append(ancplace);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[9];
												anc.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[10];
												anc.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(anc);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ anc ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/AncLog.log", FileMode.Create)))
				{
					sw.WriteLine("Anc Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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


		public void addNodeAppointment()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("appointment.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
					

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("APPOINTMENT_LIST");

												XmlNode appointment = doc.CreateElement("APPOINTMENT_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												appointment.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												appointment.Attributes.Append(pid);
												XmlAttribute an = doc.CreateAttribute("AN");
												an.Value = l[2];
												appointment.Attributes.Append(an);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[3];
												appointment.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[4];
												appointment.Attributes.Append(date_serv);
												XmlAttribute clinic = doc.CreateAttribute("CLINIC");
												clinic.Value = l[5];
												appointment.Attributes.Append(clinic);
												XmlAttribute apdate = doc.CreateAttribute("APDATE");
												apdate.Value = l[6];
												appointment.Attributes.Append(apdate);
												XmlAttribute aptype = doc.CreateAttribute("APTYPE");
												aptype.Value = l[7];
												appointment.Attributes.Append(aptype);
												XmlAttribute apdiag = doc.CreateAttribute("APDIAG");
												apdiag.Value = l[8];
												appointment.Attributes.Append(apdiag);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[9];
												appointment.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[10];
												appointment.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(appointment);



												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine(matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("[ appointment ]"+"Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/AppointmentLog.log", FileMode.Create)))
				{
					sw.WriteLine("Appointment Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeCard()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("card.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
				

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("CARD_LIST");

												XmlNode card = doc.CreateElement("CARD_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												card.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												card.Attributes.Append(pid);
												XmlAttribute instype_old = doc.CreateAttribute("INSTYPE_OLD");
												instype_old.Value = l[2];
												card.Attributes.Append(instype_old);
												XmlAttribute instype_new = doc.CreateAttribute("INSTYPE_NEW");
												instype_new.Value = l[3];
												card.Attributes.Append(instype_new);
												XmlAttribute insid = doc.CreateAttribute("INSID");
												insid.Value = l[4];
												card.Attributes.Append(insid);
												XmlAttribute startdate = doc.CreateAttribute("STARTDATE");
												startdate.Value = l[5];
												card.Attributes.Append(startdate);
												XmlAttribute expiredate = doc.CreateAttribute("EXPIREDATE");
												expiredate.Value = l[6];
												card.Attributes.Append(expiredate);
												XmlAttribute main = doc.CreateAttribute("MAIN");
												main.Value = l[7];
												card.Attributes.Append(main);
												XmlAttribute sub = doc.CreateAttribute("SUB");
												sub.Value = l[8];
												card.Attributes.Append(sub);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[9];
												card.Attributes.Append(d_update);



												nodes.Item(0).AppendChild(card);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ card ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/CardLog.log", FileMode.Create)))
				{
					sw.WriteLine("Card Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

	
		public void addNodeCharge_ipd()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("charge_ipd.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
				

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("CHARGE_IPD_LIST");

												XmlNode charge_ipd = doc.CreateElement("CHARGE_IPD_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												charge_ipd.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												charge_ipd.Attributes.Append(pid);
												XmlAttribute an = doc.CreateAttribute("AN");
												an.Value = l[2];
												charge_ipd.Attributes.Append(an);
												XmlAttribute datetime_admit = doc.CreateAttribute("DATETIME_ADMIT");
												datetime_admit.Value = l[3];
												charge_ipd.Attributes.Append(datetime_admit);
												XmlAttribute wardstay = doc.CreateAttribute("WARDSTAY");
												wardstay.Value = l[4];
												charge_ipd.Attributes.Append(wardstay);
												XmlAttribute chargeitem = doc.CreateAttribute("CHARGEITEM");
												chargeitem.Value = l[5];
												charge_ipd.Attributes.Append(chargeitem);
												XmlAttribute chargelist = doc.CreateAttribute("CHARGELIST");
												chargelist.Value = l[6];
												charge_ipd.Attributes.Append(chargelist);
												XmlAttribute quantity = doc.CreateAttribute("QUANTITY");
												quantity.Value = l[7];
												charge_ipd.Attributes.Append(quantity);
												XmlAttribute instype = doc.CreateAttribute("INSTYPE");
												instype.Value = l[8];
												charge_ipd.Attributes.Append(instype);
												XmlAttribute cost = doc.CreateAttribute("COST");
												cost.Value = l[9];
												charge_ipd.Attributes.Append(cost);
												XmlAttribute price = doc.CreateAttribute("PRICE");
												price.Value = l[10];
												charge_ipd.Attributes.Append(price);
												XmlAttribute payprice = doc.CreateAttribute("PAYPRICE");
												payprice.Value = l[11];
												charge_ipd.Attributes.Append(payprice);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[12];
												charge_ipd.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(charge_ipd);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ charge_ipd ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/Charge_ipdLog.log", FileMode.Create)))
				{
					sw.WriteLine("Charge_ipd Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeCharge_opd()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("charge_opd.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
				

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("CHARGE_OPD_LIST");

												XmlNode charge_opd = doc.CreateElement("CHARGE_OPD_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												charge_opd.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												charge_opd.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												charge_opd.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												charge_opd.Attributes.Append(date_serv);
												XmlAttribute clinic = doc.CreateAttribute("CLINIC");
												clinic.Value = l[4];
												charge_opd.Attributes.Append(clinic);
												XmlAttribute chargeitem = doc.CreateAttribute("CHARGEITEM");
												chargeitem.Value = l[5];
												charge_opd.Attributes.Append(chargeitem);
												XmlAttribute chargelist = doc.CreateAttribute("CHARGELIST");
												chargelist.Value = l[6];
												charge_opd.Attributes.Append(chargelist);
												XmlAttribute quantity = doc.CreateAttribute("QUANTITY");
												quantity.Value = l[7];
												charge_opd.Attributes.Append(quantity);
												XmlAttribute instype = doc.CreateAttribute("INSTYPE");
												instype.Value = l[8];
												charge_opd.Attributes.Append(instype);
												XmlAttribute cost = doc.CreateAttribute("COST");
												cost.Value = l[9];
												charge_opd.Attributes.Append(cost);
												XmlAttribute price = doc.CreateAttribute("PRICE");
												price.Value = l[10];
												charge_opd.Attributes.Append(price);
												XmlAttribute payprice = doc.CreateAttribute("PAYPRICE");
												payprice.Value = l[11];
												charge_opd.Attributes.Append(payprice);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[12];
												charge_opd.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(charge_opd);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ charge_opd ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/Charge_opdLog.log", FileMode.Create)))
				{
					sw.WriteLine("Charge_opd Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeChronic()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("chronic.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
				

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("CHRONIC_LIST");

												XmlNode chronic = doc.CreateElement("CHRONIC_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												chronic.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												chronic.Attributes.Append(pid);
												XmlAttribute date_diag = doc.CreateAttribute("DATE_DIAG");
												date_diag.Value = l[2];
												chronic.Attributes.Append(date_diag);
												XmlAttribute chronicA = doc.CreateAttribute("CHRONIC");
												chronic.Value = l[3];
												chronic.Attributes.Append(chronicA);
												XmlAttribute hosp_dx = doc.CreateAttribute("HOSP_DX");
												hosp_dx.Value = l[4];
												chronic.Attributes.Append(hosp_dx);
												XmlAttribute hosp_rx = doc.CreateAttribute("HOSP_RX");
												hosp_rx.Value = l[5];
												chronic.Attributes.Append(hosp_rx);
												XmlAttribute date_disch = doc.CreateAttribute("DATE_DISCH");
												date_disch.Value = l[6];
												chronic.Attributes.Append(date_disch);
												XmlAttribute typedisch = doc.CreateAttribute("TYPEDISCH");
												typedisch.Value = l[7];
												chronic.Attributes.Append(typedisch);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[8];
												chronic.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(chronic);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ chronic ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/ChronicLog.log", FileMode.Create)))
				{
					sw.WriteLine("Chronic Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeChronicfu()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("chronicfu.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
				

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("CHRONICFU_LIST");

												XmlNode chronicfu = doc.CreateElement("CHRONICFU_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												chronicfu.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												chronicfu.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												chronicfu.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												chronicfu.Attributes.Append(date_serv);
												XmlAttribute weight = doc.CreateAttribute("WEIGHT");
												weight.Value = l[4];
												chronicfu.Attributes.Append(weight);
												XmlAttribute height = doc.CreateAttribute("HEIGHT");
												height.Value = l[5];
												chronicfu.Attributes.Append(height);
												XmlAttribute waist_cm = doc.CreateAttribute("WAIST_CM");
												waist_cm.Value = l[6];
												chronicfu.Attributes.Append(waist_cm);
												XmlAttribute sbp = doc.CreateAttribute("SBP");
												sbp.Value = l[7];
												chronicfu.Attributes.Append(sbp);
												XmlAttribute dbp = doc.CreateAttribute("DBP");
												dbp.Value = l[8];
												chronicfu.Attributes.Append(dbp);
												XmlAttribute foot = doc.CreateAttribute("FOOT");
												foot.Value = l[9];
												chronicfu.Attributes.Append(foot);
												XmlAttribute retina = doc.CreateAttribute("RETINA");
												retina.Value = l[10];
												chronicfu.Attributes.Append(retina);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[11];
												chronicfu.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[12];
												chronicfu.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(chronicfu);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ chronicfu ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/ChronicfuLog.log", FileMode.Create)))
				{
					sw.WriteLine("Chronicfu Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeCommunity_service()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("community_service.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
				

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("COMMUNITY_SERVICE_LIST");

												XmlNode community_service = doc.CreateElement("COMMUNITY_SERVICE_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												community_service.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												community_service.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												community_service.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												community_service.Attributes.Append(date_serv);
												XmlAttribute comservice = doc.CreateAttribute("COMSERVICE");
												comservice.Value = l[4];
												community_service.Attributes.Append(comservice);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[5];
												community_service.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[6];
												community_service.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(community_service);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ community_service ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/Community_serviceLog.log", FileMode.Create)))
				{
					sw.WriteLine("Community_service Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeDeath()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("death.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("DEATH_LIST");
												XmlNode death = doc.CreateElement("DEATH_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												death.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												death.Attributes.Append(pid);
												XmlAttribute hospdeath = doc.CreateAttribute("HOSPDEATH");
												hospdeath.Value = l[2];
												death.Attributes.Append(hospdeath);
												XmlAttribute an = doc.CreateAttribute("AN");
												an.Value = l[3];
												death.Attributes.Append(an);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[4];
												death.Attributes.Append(seq);
												XmlAttribute ddeath = doc.CreateAttribute("DDEATH");
												ddeath.Value = l[5];
												death.Attributes.Append(ddeath);
												XmlAttribute cdeath_a = doc.CreateAttribute("CDEATH_A");
												cdeath_a.Value = l[6];
												death.Attributes.Append(cdeath_a);
												XmlAttribute cdeath_b = doc.CreateAttribute("CDEATH_B");
												cdeath_b.Value = l[7];
												death.Attributes.Append(cdeath_b);
												XmlAttribute cdeath_c = doc.CreateAttribute("CDEATH_C");
												cdeath_c.Value = l[8];
												death.Attributes.Append(cdeath_c);
												XmlAttribute cdeath_d = doc.CreateAttribute("CDEATH_D");
												cdeath_d.Value = l[9];
												death.Attributes.Append(cdeath_d);
												XmlAttribute odisease = doc.CreateAttribute("ODISEASE");
												odisease.Value = l[10];
												death.Attributes.Append(odisease);
												XmlAttribute cdeath = doc.CreateAttribute("CDEATH");
												cdeath.Value = l[11];
												death.Attributes.Append(cdeath);
												XmlAttribute pregdeath = doc.CreateAttribute("PREGDEATH");
												pregdeath.Value = l[12];
												death.Attributes.Append(pregdeath);
												XmlAttribute pdeath = doc.CreateAttribute("PDEATH");
												pdeath.Value = l[13];
												death.Attributes.Append(pdeath);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[14];
												death.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[15];
												death.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(death);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ death ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/DeathLog.log", FileMode.Create)))
				{
					sw.WriteLine("Death Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeDental()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("dental.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
				

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("DENTAL_LIST");
												XmlNode dental = doc.CreateElement("DENTAL_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												dental.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												dental.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												dental.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												dental.Attributes.Append(date_serv);
												XmlAttribute denttype = doc.CreateAttribute("DENTTYPE");
												denttype.Value = l[4];
												dental.Attributes.Append(denttype);
												XmlAttribute servplace = doc.CreateAttribute("SERVPLACE");
												servplace.Value = l[5];
												dental.Attributes.Append(servplace);
												XmlAttribute pteeth = doc.CreateAttribute("PTEETH");
												pteeth.Value = l[6];
												dental.Attributes.Append(pteeth);
												XmlAttribute pcaries = doc.CreateAttribute("PCARIES");
												pcaries.Value = l[7];
												dental.Attributes.Append(pcaries);
												XmlAttribute pfilling = doc.CreateAttribute("PFILLING");
												pfilling.Value = l[8];
												dental.Attributes.Append(pfilling);
												XmlAttribute pextract = doc.CreateAttribute("PEXTRACT");
												pextract.Value = l[9];
												dental.Attributes.Append(pextract);
												XmlAttribute dteeth = doc.CreateAttribute("DTEETH");
												dteeth.Value = l[10];
												dental.Attributes.Append(dteeth);
												XmlAttribute dcaries = doc.CreateAttribute("DCARIES");
												dcaries.Value = l[11];
												dental.Attributes.Append(dcaries);
												XmlAttribute dfilling = doc.CreateAttribute("DFILLING");
												dfilling.Value = l[12];
												dental.Attributes.Append(dfilling);
												XmlAttribute dextract = doc.CreateAttribute("DEXTRACT");
												dextract.Value = l[13];
												dental.Attributes.Append(dextract);
												XmlAttribute need_fluoride = doc.CreateAttribute("NEED_FLUORIDE");
												need_fluoride.Value = l[14];
												dental.Attributes.Append(need_fluoride);
												XmlAttribute need_scaling = doc.CreateAttribute("NEED_SCALING");
												need_scaling.Value = l[15];
												dental.Attributes.Append(need_scaling);
												XmlAttribute need_sealant = doc.CreateAttribute("NEED_SEALANT");
												need_sealant.Value = l[16];
												dental.Attributes.Append(need_sealant);
												XmlAttribute need_pfilling = doc.CreateAttribute("NEED_PFILLING");
												need_pfilling.Value = l[17];
												dental.Attributes.Append(need_pfilling);
												XmlAttribute need_dfilling = doc.CreateAttribute("NEED_DFILLING");
												need_dfilling.Value = l[18];
												dental.Attributes.Append(need_dfilling);
												XmlAttribute need_pextract = doc.CreateAttribute("NEED_PEXTRACT");
												need_pextract.Value = l[19];
												dental.Attributes.Append(need_pextract);
												XmlAttribute need_dextract = doc.CreateAttribute("NEED_DEXTRACT");
												need_dextract.Value = l[20];
												dental.Attributes.Append(need_dextract);
												XmlAttribute nprosthesis = doc.CreateAttribute("NPROSTHESIS");
												nprosthesis.Value = l[21];
												dental.Attributes.Append(nprosthesis);
												XmlAttribute permanent_permanent = doc.CreateAttribute("PERMANENT_PERMANENT");
												permanent_permanent.Value = l[22];
												dental.Attributes.Append(permanent_permanent);
												XmlAttribute permanent_prosthesis = doc.CreateAttribute("PERMANENT_PROSTHESIS");
												permanent_prosthesis.Value = l[23];
												dental.Attributes.Append(permanent_prosthesis);
												XmlAttribute prosthesis_prosthesis = doc.CreateAttribute("PROSTHESIS_PROSTHESIS");
												prosthesis_prosthesis.Value = l[24];
												dental.Attributes.Append(prosthesis_prosthesis);
												XmlAttribute gum = doc.CreateAttribute("GUM");
												gum.Value = l[25];
												dental.Attributes.Append(gum);
												XmlAttribute schooltype = doc.CreateAttribute("SCHOOLTYPE");
												schooltype.Value = l[26];
												dental.Attributes.Append(schooltype);
												XmlAttribute classa = doc.CreateAttribute("CLASS");
												classa.Value = l[27];
												dental.Attributes.Append(classa);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[28];
												dental.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[29];
												dental.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(dental);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ dental ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/DentalLog.log", FileMode.Create)))
				{
					sw.WriteLine("Dental Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeDiagnosis_ipd()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("diagnosis_ipd.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("DIAGNOSIS_IPD_LIST");
												XmlNode diagnosis_ipd = doc.CreateElement("DIAGNOSIS_IPD_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												diagnosis_ipd.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												diagnosis_ipd.Attributes.Append(pid);
												XmlAttribute an = doc.CreateAttribute("AN");
												an.Value = l[2];
												diagnosis_ipd.Attributes.Append(an);
												XmlAttribute datetime_admit = doc.CreateAttribute("DATETIME_ADMIT");
												datetime_admit.Value = l[3];
												diagnosis_ipd.Attributes.Append(datetime_admit);
												XmlAttribute warddiag = doc.CreateAttribute("WARDDIAG");
												warddiag.Value = l[4];
												diagnosis_ipd.Attributes.Append(warddiag);
												XmlAttribute diagtype = doc.CreateAttribute("DIAGTYPE");
												diagtype.Value = l[5];
												diagnosis_ipd.Attributes.Append(diagtype);
												XmlAttribute diagcode = doc.CreateAttribute("DIAGCODE");
												diagcode.Value = l[6];
												diagnosis_ipd.Attributes.Append(diagcode);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[7];
												diagnosis_ipd.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[8];
												diagnosis_ipd.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(diagnosis_ipd);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ diagnosis_ipd ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/Diagnosis_ipdLog.log", FileMode.Create)))
				{
					sw.WriteLine("Diagnosis_ipd Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeDiagnosis_opd()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("diagnosis_opd.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("DIAGNOSIS_OPD_LIST");
												XmlNode diagnosis_opd = doc.CreateElement("DIAGNOSIS_OPD_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												diagnosis_opd.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												diagnosis_opd.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												diagnosis_opd.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												diagnosis_opd.Attributes.Append(date_serv);
												XmlAttribute diagtype = doc.CreateAttribute("DIAGTYPE");
												diagtype.Value = l[4];
												diagnosis_opd.Attributes.Append(diagtype);
												XmlAttribute diagcode = doc.CreateAttribute("DIAGCODE");
												diagcode.Value = l[5];
												diagnosis_opd.Attributes.Append(diagcode);
												XmlAttribute clinic = doc.CreateAttribute("CLINIC");
												clinic.Value = l[6];
												diagnosis_opd.Attributes.Append(clinic);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[7];
												diagnosis_opd.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[8];
												diagnosis_opd.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(diagnosis_opd);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ diagnosis_opd ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/Diagnosis_opdLog.log", FileMode.Create)))
				{
					sw.WriteLine("Diagnosis_opd Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeDisability()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("disability.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
				

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("DISABILITY_LIST");
												XmlNode disability = doc.CreateElement("DISABILITY_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												disability.Attributes.Append(hospcode);
												XmlAttribute disabid = doc.CreateAttribute("DISABID");
												disabid.Value = l[1];
												disability.Attributes.Append(disabid);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[2];
												disability.Attributes.Append(pid);
												XmlAttribute disabtype = doc.CreateAttribute("DISABTYPE");
												disabtype.Value = l[3];
												disability.Attributes.Append(disabtype);
												XmlAttribute disabcause = doc.CreateAttribute("DISABCAUSE");
												disabcause.Value = l[4];
												disability.Attributes.Append(disabcause);
												XmlAttribute diagcode = doc.CreateAttribute("DIAGCODE");
												diagcode.Value = l[5];
												disability.Attributes.Append(diagcode);
												XmlAttribute date_detect = doc.CreateAttribute("DATE_DETECT");
												date_detect.Value = l[6];
												disability.Attributes.Append(date_detect);
												XmlAttribute date_disab = doc.CreateAttribute("DATE_DISAB");
												date_disab.Value = l[7];
												disability.Attributes.Append(date_disab);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[8];
												disability.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(disability);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ disability ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/DisabilityLog.log", FileMode.Create)))
				{
					sw.WriteLine("Disability Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeDrug_ipd()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("drug_ipd.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("DRUG_IPD_LIST");
												XmlNode drug_ipd = doc.CreateElement("DRUG_IPD_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												drug_ipd.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												drug_ipd.Attributes.Append(pid);
												XmlAttribute an = doc.CreateAttribute("AN");
												an.Value = l[2];
												drug_ipd.Attributes.Append(an);
												XmlAttribute datetime_admit = doc.CreateAttribute("DATETIME_ADMIT");
												datetime_admit.Value = l[3];
												drug_ipd.Attributes.Append(datetime_admit);
												XmlAttribute wardstay = doc.CreateAttribute("WARDSTAY");
												wardstay.Value = l[4];
												drug_ipd.Attributes.Append(wardstay);
												XmlAttribute typedrug = doc.CreateAttribute("TYPEDRUG");
												typedrug.Value = l[5];
												drug_ipd.Attributes.Append(typedrug);
												XmlAttribute didstd = doc.CreateAttribute("DIDSTD");
												didstd.Value = l[6];
												drug_ipd.Attributes.Append(didstd);
												XmlAttribute dname = doc.CreateAttribute("DNAME");
												dname.Value = l[7];
												drug_ipd.Attributes.Append(dname);
												XmlAttribute datestart = doc.CreateAttribute("DATESTART");
												datestart.Value = l[8];
												drug_ipd.Attributes.Append(datestart);
												XmlAttribute datefinish = doc.CreateAttribute("DATEFINISH");
												datefinish.Value = l[9];
												drug_ipd.Attributes.Append(datefinish);
												XmlAttribute amount = doc.CreateAttribute("AMOUNT");
												amount.Value = l[10];
												drug_ipd.Attributes.Append(amount);
												XmlAttribute unit = doc.CreateAttribute("UNIT");
												unit.Value = l[11];
												drug_ipd.Attributes.Append(unit);
												XmlAttribute unit_packing = doc.CreateAttribute("UNIT_PACKING");
												unit_packing.Value = l[12];
												drug_ipd.Attributes.Append(unit_packing);
												XmlAttribute drugprice = doc.CreateAttribute("DRUGPRICE");
												drugprice.Value = l[13];
												drug_ipd.Attributes.Append(drugprice);
												XmlAttribute drugcost = doc.CreateAttribute("DRUGCOST");
												drugcost.Value = l[14];
												drug_ipd.Attributes.Append(drugcost);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[15];
												drug_ipd.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[16];
												drug_ipd.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(drug_ipd);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ drug_ipd ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/Drug_ipdLog.log", FileMode.Create)))
				{
					sw.WriteLine("Drug_ipd Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeDrug_opd()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("drug_opd.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("DRUG_OPD_LIST");
												XmlNode drug_opd = doc.CreateElement("DRUG_OPD_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												drug_opd.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												drug_opd.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												drug_opd.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												drug_opd.Attributes.Append(date_serv);
												XmlAttribute clinic = doc.CreateAttribute("CLINIC");
												clinic.Value = l[4];
												drug_opd.Attributes.Append(clinic);
												XmlAttribute didstd = doc.CreateAttribute("DIDSTD");
												didstd.Value = l[5];
												drug_opd.Attributes.Append(didstd);
												XmlAttribute dname = doc.CreateAttribute("DNAME");
												dname.Value = l[6];
												drug_opd.Attributes.Append(dname);
												XmlAttribute amount = doc.CreateAttribute("AMOUNT");
												amount.Value = l[7];
												drug_opd.Attributes.Append(amount);
												XmlAttribute unit = doc.CreateAttribute("UNIT");
												unit.Value = l[8];
												drug_opd.Attributes.Append(unit);
												XmlAttribute unit_packing = doc.CreateAttribute("UNIT_PACKING");
												unit_packing.Value = l[9];
												drug_opd.Attributes.Append(unit_packing);
												XmlAttribute drugprice = doc.CreateAttribute("DRUGPRICE");
												drugprice.Value = l[10];
												drug_opd.Attributes.Append(drugprice);
												XmlAttribute drugcost = doc.CreateAttribute("DRUGCOST");
												drugcost.Value = l[11];
												drug_opd.Attributes.Append(drugcost);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[12];
												drug_opd.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[13];
												drug_opd.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(drug_opd);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ drug_opd ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/Drug_opdLog.log", FileMode.Create)))
				{
					sw.WriteLine("Drug_opd Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeDrugallergy()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("drugallergy.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
		

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("DRUGALLERGY_LIST");
												XmlNode drugallergy = doc.CreateElement("DRUGALLERGY_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												drugallergy.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												drugallergy.Attributes.Append(pid);
												XmlAttribute daterecord = doc.CreateAttribute("DATERECORD");
												daterecord.Value = l[2];
												drugallergy.Attributes.Append(daterecord);
												XmlAttribute drugallergya = doc.CreateAttribute("DRUGALLERGY");
												drugallergya.Value = l[3];
												drugallergy.Attributes.Append(drugallergya);
												XmlAttribute dname = doc.CreateAttribute("DNAME");
												dname.Value = l[4];
												drugallergy.Attributes.Append(dname);
												XmlAttribute typedx = doc.CreateAttribute("TYPEDX");
												typedx.Value = l[5];
												drugallergy.Attributes.Append(typedx);
												XmlAttribute alevel = doc.CreateAttribute("ALEVEL");
												alevel.Value = l[6];
												drugallergy.Attributes.Append(alevel);
												XmlAttribute symptom = doc.CreateAttribute("SYMPTOM");
												symptom.Value = l[7];
												drugallergy.Attributes.Append(symptom);
												XmlAttribute informant = doc.CreateAttribute("INFORMANT");
												informant.Value = l[8];
												drugallergy.Attributes.Append(informant);
												XmlAttribute informhosp = doc.CreateAttribute("INFORMHOSP");
												informhosp.Value = l[9];
												drugallergy.Attributes.Append(informhosp);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[10];
												drugallergy.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(drugallergy);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ drugallergy ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/DrugallergyLog.log", FileMode.Create)))
				{
					sw.WriteLine("Drugallergy Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeEpi()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("epi.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("EPI_LIST");
												XmlNode epi = doc.CreateElement("EPI_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												epi.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												epi.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												epi.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												epi.Attributes.Append(date_serv);
												XmlAttribute vaccinetype = doc.CreateAttribute("VACCINETYPE");
												vaccinetype.Value = l[4];
												epi.Attributes.Append(vaccinetype);
												XmlAttribute vaccineplace = doc.CreateAttribute("VACCINEPLACE");
												vaccineplace.Value = l[5];
												epi.Attributes.Append(vaccineplace);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[6];
												epi.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[7];
												epi.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(epi);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ epi ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/EpiLog.log", FileMode.Create)))
				{
					sw.WriteLine("Epi Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeFp()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("fp.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("FP_LIST");
												XmlNode fp = doc.CreateElement("FP_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												fp.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												fp.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												fp.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												fp.Attributes.Append(date_serv);
												XmlAttribute fptype = doc.CreateAttribute("FPTYPE");
												fptype.Value = l[4];
												fp.Attributes.Append(fptype);
												XmlAttribute fpplace = doc.CreateAttribute("FPPLACE");
												fpplace.Value = l[5];
												fp.Attributes.Append(fpplace);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[6];
												fp.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[7];
												fp.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(fp);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ fp ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/FpLog.log", FileMode.Create)))
				{
					sw.WriteLine("Fp Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeFunctional()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("functional.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("FUNCTIONAL_LIST");
												XmlNode functional = doc.CreateElement("FUNCTIONAL_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												functional.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												functional.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												functional.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												functional.Attributes.Append(date_serv);
												XmlAttribute functional_test = doc.CreateAttribute("FUNCTIONAL_TEST");
												functional_test.Value = l[4];
												functional.Attributes.Append(functional_test);
												XmlAttribute testresult = doc.CreateAttribute("TESTRESULT");
												testresult.Value = l[5];
												functional.Attributes.Append(testresult);
												XmlAttribute dependent = doc.CreateAttribute("DEPENDENT");
												dependent.Value = l[6];
												functional.Attributes.Append(dependent);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[7];
												functional.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[8];
												functional.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(functional);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ functional ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/FunctionalLog.log", FileMode.Create)))
				{
					sw.WriteLine("Functional Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeIcf()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("icf.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[2].Contains(m.ToString()))
								{
									if (m.ToString() == l[2].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("ICF_LIST");
												XmlNode icf = doc.CreateElement("ICF_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												icf.Attributes.Append(hospcode);
												XmlAttribute disabid = doc.CreateAttribute("DISABID");
												disabid.Value = l[1];
												icf.Attributes.Append(disabid);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[2];
												icf.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[3];
												icf.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[4];
												icf.Attributes.Append(date_serv);
												XmlAttribute icfa = doc.CreateAttribute("ICF");
												icfa.Value = l[5];
												icf.Attributes.Append(icfa);
												XmlAttribute qualifier = doc.CreateAttribute("QUALIFIER");
												qualifier.Value = l[6];
												icf.Attributes.Append(qualifier);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[7];
												icf.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[8];
												icf.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(icf);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ icf ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/IcfLog.log", FileMode.Create)))
				{
					sw.WriteLine("Icf Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeLabfu()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("labfu.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("LABFU_LIST");
												XmlNode labfu = doc.CreateElement("LABFU_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												labfu.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												labfu.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												labfu.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												labfu.Attributes.Append(date_serv);
												XmlAttribute labtest = doc.CreateAttribute("LABTEST");
												labtest.Value = l[4];
												labfu.Attributes.Append(labtest);
												XmlAttribute labresult = doc.CreateAttribute("LABRESULT");
												labresult.Value = l[5];
												labfu.Attributes.Append(labresult);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[6];
												labfu.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(labfu);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ labfu ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/LabfuLog.log", FileMode.Create)))
				{
					sw.WriteLine("Labfu Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeLabor()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("labor.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);


												XmlNodeList nodes = doc.GetElementsByTagName("LABOR_LIST");
												XmlNode labor = doc.CreateElement("LABOR_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												labor.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												labor.Attributes.Append(pid);
												XmlAttribute gravida = doc.CreateAttribute("GRAVIDA");
												gravida.Value = l[2];
												labor.Attributes.Append(gravida);
												XmlAttribute lmp = doc.CreateAttribute("LMP");
												lmp.Value = l[3];
												labor.Attributes.Append(lmp);
												XmlAttribute edc = doc.CreateAttribute("EDC");
												edc.Value = l[4];
												labor.Attributes.Append(edc);
												XmlAttribute bdate = doc.CreateAttribute("BDATE");
												bdate.Value = l[5];
												labor.Attributes.Append(bdate);
												XmlAttribute bresult = doc.CreateAttribute("BRESULT");
												bresult.Value = l[6];
												labor.Attributes.Append(bresult);
												XmlAttribute bplace = doc.CreateAttribute("BPLACE");
												bplace.Value = l[7];
												labor.Attributes.Append(bplace);
												XmlAttribute bhosp = doc.CreateAttribute("BHOSP");
												bhosp.Value = l[8];
												labor.Attributes.Append(bhosp);
												XmlAttribute btype = doc.CreateAttribute("BTYPE");
												btype.Value = l[9];
												labor.Attributes.Append(btype);
												XmlAttribute bdoctor = doc.CreateAttribute("BDOCTOR");
												bdoctor.Value = l[10];
												labor.Attributes.Append(bdoctor);
												XmlAttribute lborn = doc.CreateAttribute("LBORN");
												lborn.Value = l[11];
												labor.Attributes.Append(lborn);
												XmlAttribute sborn = doc.CreateAttribute("SBORN");
												sborn.Value = l[12];
												labor.Attributes.Append(sborn);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[13];
												labor.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(labor);

												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ labor ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/LaborLog.log", FileMode.Create)))
				{
					sw.WriteLine("Labor Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeNcdscreen()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("ncdscreen.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("NCDSCREEN_LIST");
												XmlNode ncdscreen = doc.CreateElement("NCDSCREEN_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												ncdscreen.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												ncdscreen.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												ncdscreen.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												ncdscreen.Attributes.Append(date_serv);
												XmlAttribute servplace = doc.CreateAttribute("SERVPLACE");
												servplace.Value = l[4];
												ncdscreen.Attributes.Append(servplace);
												XmlAttribute smoke = doc.CreateAttribute("SMOKE");
												smoke.Value = l[5];
												ncdscreen.Attributes.Append(smoke);
												XmlAttribute alcohol = doc.CreateAttribute("ALCOHOL");
												alcohol.Value = l[6];
												ncdscreen.Attributes.Append(alcohol);
												XmlAttribute dmfamily = doc.CreateAttribute("DMFAMILY");
												dmfamily.Value = l[7];
												ncdscreen.Attributes.Append(dmfamily);
												XmlAttribute htfamily = doc.CreateAttribute("HTFAMILY");
												htfamily.Value = l[8];
												ncdscreen.Attributes.Append(htfamily);
												XmlAttribute weight = doc.CreateAttribute("WEIGHT");
												weight.Value = l[9];
												ncdscreen.Attributes.Append(weight);
												XmlAttribute height = doc.CreateAttribute("HEIGHT");
												height.Value = l[10];
												ncdscreen.Attributes.Append(height);
												XmlAttribute waist_cm = doc.CreateAttribute("WAIST_CM");
												waist_cm.Value = l[11];
												ncdscreen.Attributes.Append(waist_cm);
												XmlAttribute sbp_1 = doc.CreateAttribute("SBP_1");
												sbp_1.Value = l[12];
												ncdscreen.Attributes.Append(sbp_1);
												XmlAttribute dbp_1 = doc.CreateAttribute("DBP_1");
												dbp_1.Value = l[13];
												ncdscreen.Attributes.Append(dbp_1);
												XmlAttribute sbp_2 = doc.CreateAttribute("SBP_2");
												sbp_2.Value = l[14];
												ncdscreen.Attributes.Append(sbp_2);
												XmlAttribute dbp_2 = doc.CreateAttribute("DBP_2");
												dbp_2.Value = l[15];
												ncdscreen.Attributes.Append(dbp_2);
												XmlAttribute bslevel = doc.CreateAttribute("BSLEVEL");
												bslevel.Value = l[16];
												ncdscreen.Attributes.Append(bslevel);
												XmlAttribute bstest = doc.CreateAttribute("BSTEST");
												bstest.Value = l[17];
												ncdscreen.Attributes.Append(bstest);
												XmlAttribute screenplace = doc.CreateAttribute("SCREENPLACE");
												screenplace.Value = l[18];
												ncdscreen.Attributes.Append(screenplace);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[19];
												ncdscreen.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[20];
												ncdscreen.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(ncdscreen);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ ncdscreen ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/NcdscreenLog.log", FileMode.Create)))
				{
					sw.WriteLine("Ncdscreen Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeNewborn()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("newborn.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
			

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("NEWBORN_LIST");
												XmlNode newborn = doc.CreateElement("NEWBORN_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												newborn.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												newborn.Attributes.Append(pid);
												XmlAttribute mpid = doc.CreateAttribute("MPID");
												mpid.Value = l[2];
												newborn.Attributes.Append(mpid);
												XmlAttribute gravida = doc.CreateAttribute("GRAVIDA");
												gravida.Value = l[3];
												newborn.Attributes.Append(gravida);
												XmlAttribute ga = doc.CreateAttribute("GA");
												ga.Value = l[4];
												newborn.Attributes.Append(ga);
												XmlAttribute bdate = doc.CreateAttribute("BDATE");
												bdate.Value = l[5];
												newborn.Attributes.Append(bdate);
												XmlAttribute btime = doc.CreateAttribute("BTIME");
												btime.Value = l[6];
												newborn.Attributes.Append(btime);
												XmlAttribute bplace = doc.CreateAttribute("BPLACE");
												bplace.Value = l[7];
												newborn.Attributes.Append(bplace);
												XmlAttribute bhosp = doc.CreateAttribute("BHOSP");
												bhosp.Value = l[8];
												newborn.Attributes.Append(bhosp);
												XmlAttribute birthno = doc.CreateAttribute("BIRTHNO");
												birthno.Value = l[9];
												newborn.Attributes.Append(birthno);
												XmlAttribute btype = doc.CreateAttribute("BTYPE");
												btype.Value = l[10];
												newborn.Attributes.Append(btype);
												XmlAttribute bdoctor = doc.CreateAttribute("BDOCTOR");
												bdoctor.Value = l[11];
												newborn.Attributes.Append(bdoctor);
												XmlAttribute bweight = doc.CreateAttribute("BWEIGHT");
												bweight.Value = l[12];
												newborn.Attributes.Append(bweight);
												XmlAttribute asphyxia = doc.CreateAttribute("ASPHYXIA");
												asphyxia.Value = l[13];
												newborn.Attributes.Append(asphyxia);
												XmlAttribute vitk = doc.CreateAttribute("VITK");
												vitk.Value = l[14];
												newborn.Attributes.Append(vitk);
												XmlAttribute tsh = doc.CreateAttribute("TSH");
												tsh.Value = l[15];
												newborn.Attributes.Append(tsh);
												XmlAttribute tshresult = doc.CreateAttribute("TSHRESULT");
												tshresult.Value = l[16];
												newborn.Attributes.Append(tshresult);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[17];
												newborn.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(newborn);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ newborn ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/NewbornLog.log", FileMode.Create)))
				{
					sw.WriteLine("Newborn Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeNewborncare()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("newborncare.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
		

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("NEWBORNCARE_LIST");
												XmlNode newborncare = doc.CreateElement("NEWBORNCARE_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												newborncare.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												newborncare.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												newborncare.Attributes.Append(seq);
												XmlAttribute bdate = doc.CreateAttribute("BDATE");
												bdate.Value = l[3];
												newborncare.Attributes.Append(bdate);
												XmlAttribute bcare = doc.CreateAttribute("BCARE");
												bcare.Value = l[4];
												newborncare.Attributes.Append(bcare);
												XmlAttribute bcplace = doc.CreateAttribute("BCPLACE");
												bcplace.Value = l[5];
												newborncare.Attributes.Append(bcplace);
												XmlAttribute bcareresult = doc.CreateAttribute("BCARERESULT");
												bcareresult.Value = l[6];
												newborncare.Attributes.Append(bcareresult);
												XmlAttribute food = doc.CreateAttribute("FOOD");
												food.Value = l[7];
												newborncare.Attributes.Append(food);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[8];
												newborncare.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[9];
												newborncare.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(newborncare);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ newborncare ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/NewborncareLog.log", FileMode.Create)))
				{
					sw.WriteLine("Newborncare Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeNutrition()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("nutrition.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
		

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("NUTRITRION_LIST");
												XmlNode nutrition = doc.CreateElement("NUTRITRION_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												nutrition.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												nutrition.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												nutrition.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												nutrition.Attributes.Append(date_serv);
												XmlAttribute nutritionplace = doc.CreateAttribute("NUTRITIONPLACE");
												nutritionplace.Value = l[4];
												nutrition.Attributes.Append(nutritionplace);
												XmlAttribute weight = doc.CreateAttribute("WEIGHT");
												weight.Value = l[5];
												nutrition.Attributes.Append(weight);
												XmlAttribute height = doc.CreateAttribute("HEIGHT");
												height.Value = l[6];
												nutrition.Attributes.Append(height);
												XmlAttribute headcircum = doc.CreateAttribute("HEADCIRCUM");
												headcircum.Value = l[7];
												nutrition.Attributes.Append(headcircum);
												XmlAttribute childdevelop = doc.CreateAttribute("CHILDDEVELOP");
												childdevelop.Value = l[8];
												nutrition.Attributes.Append(childdevelop);
												XmlAttribute food = doc.CreateAttribute("FOOD");
												food.Value = l[9];
												nutrition.Attributes.Append(food);
												XmlAttribute bottle = doc.CreateAttribute("BOTTLE");
												bottle.Value = l[10];
												nutrition.Attributes.Append(bottle);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[11];
												nutrition.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[12];
												nutrition.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(nutrition);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ nutrition ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/NutritionLog.log", FileMode.Create)))
				{
					sw.WriteLine("Nutrition Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodePostnatal()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("postnatal.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
	

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("POSTNATAL_LIST");
												XmlNode postnatal = doc.CreateElement("POSTNATAL_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												postnatal.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												postnatal.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												postnatal.Attributes.Append(seq);
												XmlAttribute gravida = doc.CreateAttribute("GRAVIDA");
												gravida.Value = l[3];
												postnatal.Attributes.Append(gravida);
												XmlAttribute bdate = doc.CreateAttribute("BDATE");
												bdate.Value = l[4];
												postnatal.Attributes.Append(bdate);
												XmlAttribute ppcare = doc.CreateAttribute("PPCARE");
												ppcare.Value = l[5];
												postnatal.Attributes.Append(ppcare);
												XmlAttribute ppplace = doc.CreateAttribute("PPPLACE");
												ppplace.Value = l[6];
												postnatal.Attributes.Append(ppplace);
												XmlAttribute ppresult = doc.CreateAttribute("PPRESULT");
												ppresult.Value = l[7];
												postnatal.Attributes.Append(ppresult);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[8];
												postnatal.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[9];
												postnatal.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(postnatal);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ postnatal ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/PostnatalLog.log", FileMode.Create)))
				{
					sw.WriteLine("Postnatal Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodePrenatal()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("prenatal.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
		

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("PRENATAL_LIST");
												XmlNode prenatal = doc.CreateElement("PRENATAL_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												prenatal.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												prenatal.Attributes.Append(pid);
												XmlAttribute gravida = doc.CreateAttribute("GRAVIDA");
												gravida.Value = l[2];
												prenatal.Attributes.Append(gravida);
												XmlAttribute lmp = doc.CreateAttribute("LMP");
												lmp.Value = l[3];
												prenatal.Attributes.Append(lmp);
												XmlAttribute edc = doc.CreateAttribute("EDC");
												edc.Value = l[4];
												prenatal.Attributes.Append(edc);
												XmlAttribute vdrl_result = doc.CreateAttribute("VDRL_RESULT");
												vdrl_result.Value = l[5];
												prenatal.Attributes.Append(vdrl_result);
												XmlAttribute hb_result = doc.CreateAttribute("HB_RESULT");
												hb_result.Value = l[6];
												prenatal.Attributes.Append(hb_result);
												XmlAttribute hiv_result = doc.CreateAttribute("HIV_RESULT");
												hiv_result.Value = l[7];
												prenatal.Attributes.Append(hiv_result);
												XmlAttribute date_hct = doc.CreateAttribute("DATE_HCT");
												date_hct.Value = l[8];
												prenatal.Attributes.Append(date_hct);
												XmlAttribute hct_result = doc.CreateAttribute("HCT_RESULT");
												hct_result.Value = l[9];
												prenatal.Attributes.Append(hct_result);
												XmlAttribute thalassemia = doc.CreateAttribute("THALASSEMIA");
												thalassemia.Value = l[10];
												prenatal.Attributes.Append(thalassemia);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[11];
												prenatal.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(prenatal);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ prenatal ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/PrenatalLog.log", FileMode.Create)))
				{
					sw.WriteLine("Prenatal Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeProcedure_ipd()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("procedure_ipd.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
		

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("PROCEDURE_IPD_LIST");
												XmlNode procedure_ipd = doc.CreateElement("PROCEDURE_IPD_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												procedure_ipd.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												procedure_ipd.Attributes.Append(pid);
												XmlAttribute an = doc.CreateAttribute("AN");
												an.Value = l[2];
												procedure_ipd.Attributes.Append(an);
												XmlAttribute datetime_admit = doc.CreateAttribute("DATETIME_ADMIT");
												datetime_admit.Value = l[3];
												procedure_ipd.Attributes.Append(datetime_admit);
												XmlAttribute wardstay = doc.CreateAttribute("WARDSTAY");
												wardstay.Value = l[4];
												procedure_ipd.Attributes.Append(wardstay);
												XmlAttribute procedcode = doc.CreateAttribute("PROCEDCODE");
												procedcode.Value = l[5];
												procedure_ipd.Attributes.Append(procedcode);
												XmlAttribute timestart = doc.CreateAttribute("TIMESTART");
												timestart.Value = l[6];
												procedure_ipd.Attributes.Append(timestart);
												XmlAttribute timefinish = doc.CreateAttribute("TIMEFINISH");
												timefinish.Value = l[7];
												procedure_ipd.Attributes.Append(timefinish);
												XmlAttribute serviceprice = doc.CreateAttribute("SERVICEPRICE");
												serviceprice.Value = l[8];
												procedure_ipd.Attributes.Append(serviceprice);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[9];
												procedure_ipd.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[10];
												procedure_ipd.Attributes.Append(d_update);


												nodes.Item(0).AppendChild(procedure_ipd);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ procedure_ipd ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/Procedure_ipdLog.log", FileMode.Create)))
				{
					sw.WriteLine("Procedure_ipd Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeProcedure_opd()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("procedure_opd.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
		

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("PROCEDURE_OPD_LIST");
												XmlNode procedure_opd = doc.CreateElement("PROCEDURE_OPD_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												procedure_opd.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												procedure_opd.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												procedure_opd.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												procedure_opd.Attributes.Append(date_serv);
												XmlAttribute clinic = doc.CreateAttribute("CLINIC");
												clinic.Value = l[4];
												procedure_opd.Attributes.Append(clinic);
												XmlAttribute procedcode = doc.CreateAttribute("PROCEDCODE");
												procedcode.Value = l[5];
												procedure_opd.Attributes.Append(procedcode);
												XmlAttribute serviceprice = doc.CreateAttribute("SERVICEPRICE");
												serviceprice.Value = l[6];
												procedure_opd.Attributes.Append(serviceprice);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[7];
												procedure_opd.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[8];
												procedure_opd.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(procedure_opd);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ procedure_opd ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/Procedure_opdLog.log", FileMode.Create)))
				{
					sw.WriteLine("Procedure_opd Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeProvider()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("provider.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
	

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[4].Contains(m.ToString()))
								{
									if (m.ToString() == l[4].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("PROVIDER_LIST");
												XmlNode provider = doc.CreateElement("PROVIDER_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												provider.Attributes.Append(hospcode);
												XmlAttribute providera = doc.CreateAttribute("PROVIDER");
												providera.Value = l[1];
												provider.Attributes.Append(providera);
												XmlAttribute registerno = doc.CreateAttribute("REGISTERNO");
												registerno.Value = l[2];
												provider.Attributes.Append(registerno);
												XmlAttribute council = doc.CreateAttribute("COUNCIL");
												council.Value = l[3];
												provider.Attributes.Append(council);
												XmlAttribute cid = doc.CreateAttribute("CID");
												cid.Value = l[4];
												provider.Attributes.Append(cid);
												XmlAttribute prename = doc.CreateAttribute("PRENAME");
												prename.Value = l[5];
												provider.Attributes.Append(prename);
												XmlAttribute name = doc.CreateAttribute("NAME");
												name.Value = l[6];
												provider.Attributes.Append(name);
												XmlAttribute lname = doc.CreateAttribute("LNAME");
												lname.Value = l[7];
												provider.Attributes.Append(lname);
												XmlAttribute sex = doc.CreateAttribute("SEX");
												sex.Value = l[8];
												provider.Attributes.Append(sex);
												XmlAttribute birth = doc.CreateAttribute("BIRTH");
												birth.Value = l[9];
												provider.Attributes.Append(birth);
												XmlAttribute providertype = doc.CreateAttribute("PROVIDERTYPE");
												providertype.Value = l[10];
												provider.Attributes.Append(providertype);
												XmlAttribute startdate = doc.CreateAttribute("STARTDATE");
												startdate.Value = l[11];
												provider.Attributes.Append(startdate);
												XmlAttribute outdate = doc.CreateAttribute("OUTDATE");
												outdate.Value = l[12];
												provider.Attributes.Append(outdate);
												XmlAttribute movefrom = doc.CreateAttribute("MOVEFROM");
												movefrom.Value = l[13];
												provider.Attributes.Append(movefrom);
												XmlAttribute moveto = doc.CreateAttribute("MOVETO");
												moveto.Value = l[14];
												provider.Attributes.Append(moveto);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[15];
												provider.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(provider);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ provider ]"+matches[2].ToString() + " " + l[4] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/ProviderLog.log", FileMode.Create)))
				{
					sw.WriteLine("Provider Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeRehabilitation()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("rehabilitation.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
	

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("REHABILITATION_LIST");
												XmlNode rehabilitation = doc.CreateElement("REHABILITATION_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												rehabilitation.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												rehabilitation.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												rehabilitation.Attributes.Append(seq);
												XmlAttribute an = doc.CreateAttribute("AN");
												an.Value = l[3];
												rehabilitation.Attributes.Append(an);
												XmlAttribute date_admit = doc.CreateAttribute("DATE_ADMIT");
												date_admit.Value = l[4];
												rehabilitation.Attributes.Append(date_admit);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[5];
												rehabilitation.Attributes.Append(date_serv);
												XmlAttribute date_start = doc.CreateAttribute("DATE_START");
												date_start.Value = l[6];
												rehabilitation.Attributes.Append(date_start);
												XmlAttribute date_finish = doc.CreateAttribute("DATE_FINISH");
												date_finish.Value = l[7];
												rehabilitation.Attributes.Append(date_finish);
												XmlAttribute rehabcode = doc.CreateAttribute("REHABCODE");
												rehabcode.Value = l[8];
												rehabilitation.Attributes.Append(rehabcode);
												XmlAttribute at_device = doc.CreateAttribute("AT_DEVICE");
												at_device.Value = l[9];
												rehabilitation.Attributes.Append(at_device);
												XmlAttribute at_no = doc.CreateAttribute("AT_NO");
												at_no.Value = l[10];
												rehabilitation.Attributes.Append(at_no);
												XmlAttribute rehabplace = doc.CreateAttribute("REHABPLACE");
												rehabplace.Value = l[11];
												rehabilitation.Attributes.Append(rehabplace);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[12];
												rehabilitation.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[13];
												rehabilitation.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(rehabilitation);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ rehabilitation ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/RehabilitationLog.log", FileMode.Create)))
				{
					sw.WriteLine("Rehabilitation Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeService()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("service.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{


					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("SERVICE_LIST");
												XmlNode service = doc.CreateElement("SERVICE_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												service.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												service.Attributes.Append(pid);
												XmlAttribute hn = doc.CreateAttribute("HN");
												hn.Value = l[2];
												service.Attributes.Append(hn);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[3];
												service.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[4];
												service.Attributes.Append(date_serv);
												XmlAttribute time_serv = doc.CreateAttribute("TIME_SERV");
												time_serv.Value = l[5];
												service.Attributes.Append(time_serv);
												XmlAttribute location = doc.CreateAttribute("LOCATION");
												location.Value = l[6];
												service.Attributes.Append(location);
												XmlAttribute intime = doc.CreateAttribute("INTIME");
												intime.Value = l[7];
												service.Attributes.Append(intime);
												XmlAttribute instype = doc.CreateAttribute("INSTYPE");
												instype.Value = l[8];
												service.Attributes.Append(instype);
												XmlAttribute insid = doc.CreateAttribute("INSID");
												insid.Value = l[9];
												service.Attributes.Append(insid);
												XmlAttribute main = doc.CreateAttribute("MAIN");
												main.Value = l[10];
												service.Attributes.Append(main);
												XmlAttribute typein = doc.CreateAttribute("TYPEIN");
												typein.Value = l[11];
												service.Attributes.Append(typein);
												XmlAttribute referinhosp = doc.CreateAttribute("REFERINHOSP");
												referinhosp.Value = l[12];
												service.Attributes.Append(referinhosp);
												XmlAttribute causein = doc.CreateAttribute("CAUSEIN");
												causein.Value = l[13];
												service.Attributes.Append(causein);
												XmlAttribute chiefcomp = doc.CreateAttribute("CHIEFCOMP");
												chiefcomp.Value = l[14];
												service.Attributes.Append(chiefcomp);
												XmlAttribute servplace = doc.CreateAttribute("SERVPLACE");
												servplace.Value = l[15];
												service.Attributes.Append(servplace);
												XmlAttribute btemp = doc.CreateAttribute("BTEMP");
												btemp.Value = l[16];
												service.Attributes.Append(btemp);
												XmlAttribute sbp = doc.CreateAttribute("SBP");
												sbp.Value = l[17];
												service.Attributes.Append(sbp);
												XmlAttribute dbp = doc.CreateAttribute("DBP");
												dbp.Value = l[18];
												service.Attributes.Append(dbp);
												XmlAttribute pra = doc.CreateAttribute("PR");
												pra.Value = l[19];
												service.Attributes.Append(pra);
												XmlAttribute rr = doc.CreateAttribute("RR");
												rr.Value = l[20];
												service.Attributes.Append(rr);
												XmlAttribute typeout = doc.CreateAttribute("TYPEOUT");
												typeout.Value = l[21];
												service.Attributes.Append(typeout);
												XmlAttribute referouthosp = doc.CreateAttribute("REFEROUTHOSP");
												referouthosp.Value = l[22];
												service.Attributes.Append(referouthosp);
												XmlAttribute causeout = doc.CreateAttribute("CAUSEOUT");
												causeout.Value = l[23];
												service.Attributes.Append(causeout);
												XmlAttribute cost = doc.CreateAttribute("COST");
												cost.Value = l[24];
												service.Attributes.Append(cost);
												XmlAttribute price = doc.CreateAttribute("PRICE");
												price.Value = l[25];
												service.Attributes.Append(price);
												XmlAttribute payprice = doc.CreateAttribute("PAYPRICE");
												payprice.Value = l[26];
												service.Attributes.Append(payprice);
												XmlAttribute actualpay = doc.CreateAttribute("ACTUALPAY");
												actualpay.Value = l[27];
												service.Attributes.Append(actualpay);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[28];
												service.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(service);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ service ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/ServiceLog.log", FileMode.Create)))
				{
					sw.WriteLine("Service Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeSpecialpp()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("specialpp.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
	

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("SPECIALPP_LIST");
												XmlNode specialpp = doc.CreateElement("SPECIALPP_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												specialpp.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												specialpp.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												specialpp.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												specialpp.Attributes.Append(date_serv);
												XmlAttribute servplace = doc.CreateAttribute("SERVPLACE");
												servplace.Value = l[4];
												specialpp.Attributes.Append(servplace);
												XmlAttribute ppspecial = doc.CreateAttribute("PPSPECIAL");
												ppspecial.Value = l[5];
												specialpp.Attributes.Append(ppspecial);
												XmlAttribute ppsplace = doc.CreateAttribute("PPSPLACE");
												ppsplace.Value = l[6];
												specialpp.Attributes.Append(ppsplace);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[7];
												specialpp.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[8];
												specialpp.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(specialpp);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ specialpp ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/SpecialppLog.log", FileMode.Create)))
				{
					sw.WriteLine("Specialpp Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeSurveillance()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("surveillance.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
	

					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("SURVEILLANCE_LIST");
												XmlNode surveillance = doc.CreateElement("SURVEILLANCE_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												surveillance.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												surveillance.Attributes.Append(pid);
												XmlAttribute seq = doc.CreateAttribute("SEQ");
												seq.Value = l[2];
												surveillance.Attributes.Append(seq);
												XmlAttribute date_serv = doc.CreateAttribute("DATE_SERV");
												date_serv.Value = l[3];
												surveillance.Attributes.Append(date_serv);
												XmlAttribute an = doc.CreateAttribute("AN");
												an.Value = l[4];
												surveillance.Attributes.Append(an);
												XmlAttribute datetime_admit = doc.CreateAttribute("DATETIME_ADMIT");
												datetime_admit.Value = l[5];
												surveillance.Attributes.Append(datetime_admit);
												XmlAttribute syndrome = doc.CreateAttribute("SYNDROME");
												syndrome.Value = l[6];
												surveillance.Attributes.Append(syndrome);
												XmlAttribute diagcode = doc.CreateAttribute("DIAGCODE");
												diagcode.Value = l[7];
												surveillance.Attributes.Append(diagcode);
												XmlAttribute code506 = doc.CreateAttribute("CODE506");
												code506.Value = l[8];
												surveillance.Attributes.Append(code506);
												XmlAttribute diagcodelast = doc.CreateAttribute("DIAGCODELAST");
												diagcodelast.Value = l[9];
												surveillance.Attributes.Append(diagcodelast);
												XmlAttribute code506last = doc.CreateAttribute("CODE506LAST");
												code506last.Value = l[10];
												surveillance.Attributes.Append(code506last);
												XmlAttribute illdate = doc.CreateAttribute("ILLDATE");
												illdate.Value = l[11];
												surveillance.Attributes.Append(illdate);
												XmlAttribute illhouse = doc.CreateAttribute("ILLHOUSE");
												illhouse.Value = l[12];
												surveillance.Attributes.Append(illhouse);
												XmlAttribute illvillage = doc.CreateAttribute("ILLVILLAGE");
												illvillage.Value = l[13];
												surveillance.Attributes.Append(illvillage);
												XmlAttribute illtambon = doc.CreateAttribute("ILLTAMBON");
												illtambon.Value = l[14];
												surveillance.Attributes.Append(illtambon);
												XmlAttribute illampur = doc.CreateAttribute("ILLAMPUR");
												illampur.Value = l[15];
												surveillance.Attributes.Append(illampur);
												XmlAttribute illchangwat = doc.CreateAttribute("ILLCHANGWAT");
												illchangwat.Value = l[16];
												surveillance.Attributes.Append(illchangwat);
												XmlAttribute latitude = doc.CreateAttribute("LATITUDE");
												latitude.Value = l[17];
												surveillance.Attributes.Append(latitude);
												XmlAttribute longitude = doc.CreateAttribute("LONGITUDE");
												longitude.Value = l[18];
												surveillance.Attributes.Append(longitude);
												XmlAttribute ptstatus = doc.CreateAttribute("PTSTATUS");
												ptstatus.Value = l[19];
												surveillance.Attributes.Append(ptstatus);
												XmlAttribute date_death = doc.CreateAttribute("DATE_DEATH");
												date_death.Value = l[20];
												surveillance.Attributes.Append(date_death);
												XmlAttribute complication = doc.CreateAttribute("COMPLICATION");
												complication.Value = l[21];
												surveillance.Attributes.Append(complication);
												XmlAttribute organism = doc.CreateAttribute("ORGANISM");
												organism.Value = l[22];
												surveillance.Attributes.Append(organism);
												XmlAttribute provider = doc.CreateAttribute("PROVIDER");
												provider.Value = l[23];
												surveillance.Attributes.Append(provider);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[24];
												surveillance.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(surveillance);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ surveillance ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);

													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/SurveillanceLog.log", FileMode.Create)))
				{
					sw.WriteLine("Surveillance Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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

		public void addNodeWomen()
		{

			XmlDocument doc = new XmlDocument();
			try
			{
				string logS = DateTime.Now.ToString();
				int count = 0;
				using (FileStream pr = File.Open("women.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (BufferedStream bspr = new BufferedStream(pr))
				using (StreamReader srpr = new StreamReader(bspr))
				{
	
					string line;
					while ((line = srpr.ReadLine()) != null)
					{

						var l = line.Split(',');

						foreach (string lineid in System.IO.File.ReadLines("PHR/" + "ID.txt"))
						{
							Regex re = new Regex(@"\w+");
							var matches = re.Matches(lineid.ToString());
							foreach (var m in matches)
							{
								if (l[1].Contains(m.ToString()))
								{
									if (m.ToString() == l[1].ToString())
									{
										try
										{

											using (StreamReader sr = new StreamReader(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Open)))
											{
												doc.Load(sr);

												XmlNodeList nodes = doc.GetElementsByTagName("WOMEN_LIST");
												XmlNode women = doc.CreateElement("WOMEN_INFO");

												XmlAttribute hospcode = doc.CreateAttribute("HOSPCODE");
												hospcode.Value = l[0];
												women.Attributes.Append(hospcode);
												XmlAttribute pid = doc.CreateAttribute("PID");
												pid.Value = l[1];
												women.Attributes.Append(pid);
												XmlAttribute fptype = doc.CreateAttribute("FPTYPE");
												fptype.Value = l[2];
												women.Attributes.Append(fptype);
												XmlAttribute nofpcause = doc.CreateAttribute("NOFPCAUSE");
												nofpcause.Value = l[3];
												women.Attributes.Append(nofpcause);
												XmlAttribute totalson = doc.CreateAttribute("TOTALSON");
												totalson.Value = l[4];
												women.Attributes.Append(totalson);
												XmlAttribute numberson = doc.CreateAttribute("NUMBERSON");
												numberson.Value = l[5];
												women.Attributes.Append(numberson);
												XmlAttribute abortion = doc.CreateAttribute("ABORTION");
												abortion.Value = l[6];
												women.Attributes.Append(abortion);
												XmlAttribute stillbirth = doc.CreateAttribute("STILLBIRTH");
												stillbirth.Value = l[7];
												women.Attributes.Append(stillbirth);
												XmlAttribute d_update = doc.CreateAttribute("D_UPDATE");
												d_update.Value = l[8];
												women.Attributes.Append(d_update);

												nodes.Item(0).AppendChild(women);


												using (StreamWriter sw = new StreamWriter(new FileStream("PHR/" + matches[0].ToString() + "/" + matches[2].ToString() + ".xml", FileMode.Create)))
												{

													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine("[ women ]"+matches[3].ToString() + " " + l[1] + " " + count);
													Console.WriteLine("Add Success");
													doc.Save(sw);
													count++;
												}
											}
										}
										catch
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Add Fail!");
											count++;
											continue;
										}

									}
								}

							}

						}
					}

				}
				using (StreamWriter sw = new StreamWriter(new FileStream("PHR/logger/WomenLog.log", FileMode.Create)))
				{
					sw.WriteLine("Women Successful ");
					sw.WriteLine("Start : " + logS);
					sw.WriteLine("End : " + DateTime.Now);

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
