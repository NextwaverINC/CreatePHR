﻿using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using CsvToXml;
using System.Text;

namespace CsvToXml
{
    public class ExportXmlH
    {
        public ExportXmlH()
        {
        }
        public void Export(string csvPath)
		{
			ProgressBar p = new ProgressBar();

            try
            {
                using (StreamReader streamReader = new StreamReader(new FileStream(csvPath, FileMode.Open)))
                {
                    var lines = File.ReadAllLines(csvPath);
                    string[] headers = lines[0].Split(',').Select(x => x.Trim('\"')).ToArray();
                    lines = lines.Skip(1).ToArray();
                    //string xmlPath = "";
                    Console.BackgroundColor = ConsoleColor.Red;
                    //int num = 0;
                    //int q = 0;
                    Console.WriteLine("");
                    Console.WriteLine("Writing XML files...");

                    for (int i = 0; i < lines.Count(); i++)
                    {
                        var t = lines[i].Split(',').Select(x => x.Trim('\"')).ToArray();

                        //if (num < 10)
                        //{
                             string xmlPath = "PHR/" + t[1] + ".xml";
                        //}
                       // else
                        //{
                            // xmlPath = "PHR/PHR"+q+1+"/" + t[1] + ".xml";
                    
                        //}
                        //num++;

                        string z = "";
                        foreach (var str in lines)
                        {
                            var columns = str.Split(',');
                            var a = columns[2];
                            var b = columns[0];
                            if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("PERSON_INFO",
                                                      new XAttribute("HOSPCODE", columns[0]),
                                                      new XAttribute("CID", columns[1]),
                                                      new XAttribute("PID", columns[2]),
                                                      new XAttribute("HID", columns[3]),
                                                      new XAttribute("PRENAME", columns[4]),
                                                      new XAttribute("NAME", columns[5]),
                                                      new XAttribute("LNAME", columns[6]),
                                                      new XAttribute("HN", columns[7]),
                                                      new XAttribute("SEX", columns[8]),
                                                      new XAttribute("BIRTH", columns[9]),
                                                      new XAttribute("MSTATUS", columns[10]),
                                                      new XAttribute("OCCUPATION_OLD", columns[11]),
                                                      new XAttribute("OCCUPATION_NEW", columns[12]),
                                                      new XAttribute("RACE", columns[13]),
                                                      new XAttribute("NATION", columns[14]),
                                                      new XAttribute("RELIGION", columns[15]),
                                                      new XAttribute("EDUCATION", columns[16]),
                                                      new XAttribute("FSTATUS", columns[17]),
                                                      new XAttribute("FATHER", columns[18]),
                                                      new XAttribute("MOTHER", columns[19]),
                                                      new XAttribute("COUPLE", columns[20]),
                                                      new XAttribute("VSTATUS", columns[21]),
                                                      new XAttribute("MOVEIN", columns[22]),
                                                      new XAttribute("DISCHARGE", columns[23]),
                                                      new XAttribute("DDISCHARGE", columns[24]),
                                                      new XAttribute("ABOGROUP", columns[25]),
                                                      new XAttribute("RHGROUP", columns[26]),
                                                      new XAttribute("LABOR", columns[27]),
                                                      new XAttribute("PASSPORT", columns[28]),
                                                      new XAttribute("TYPEAREA", columns[29]),
                                                      new XAttribute("D_UPDATE", columns[30])

                                 );
                                z += "    " + xml + Environment.NewLine;
                            }

                        }

                        var lines1 = File.ReadAllLines("accident.csv");
                        lines1 = lines1.Skip(1).ToArray();
                        string z1 = "";
                        foreach (var str in lines1)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {

                                XElement xml = new XElement("ACCIDENT_INFO",
                                                    new XAttribute("HOSPCODE", columns[0]),
                                                    new XAttribute("PID", columns[1]),
                                                    new XAttribute("SEQ", columns[2]),
                                                    new XAttribute("DATETIME_SERV", columns[3]),
                                                    new XAttribute("DATETIME_AE", columns[4]),
                                                    new XAttribute("AETYPE", columns[5]),
                                                    new XAttribute("AEPLACE", columns[6]),
                                                    new XAttribute("TYPEIN_AE", columns[7]),
                                                    new XAttribute("TRAFFIC", columns[8]),
                                                    new XAttribute("VEHICLE", columns[9]),
                                                    new XAttribute("ALCOHOL", columns[10]),
                                                    new XAttribute("NACROTIC_DRUG", columns[11]),
                                                    new XAttribute("BELT", columns[12]),
                                                    new XAttribute("HELMET", columns[13]),
                                                    new XAttribute("AIRWAY", columns[14]),
                                                    new XAttribute("STOPBLEED", columns[15]),
                                                    new XAttribute("SPLINT", columns[16]),
                                                    new XAttribute("FLUID", columns[17]),
                                                    new XAttribute("URGENCY", columns[18]),
                                                    new XAttribute("COMA_EYE", columns[19]),
                                                    new XAttribute("COMA_SPEAK", columns[20]),
                                                    new XAttribute("COMA_MOVEMENT", columns[21]),
                                                    new XAttribute("D_UPDATE", columns[22])


                              );
                                z1 += "    " + xml + Environment.NewLine;
                            }
						
						}

                        var lines2 = File.ReadAllLines("address.csv");
						string[] headers2 = lines2[0].Split(',').Select(x => x.Trim('\"')).ToArray();
                        lines2 = lines2.Skip(1).ToArray();
                        string z2 = "";
                        foreach (var str in lines2)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("ADDRESS_INFO", 
                                        new XAttribute("HOSPCODE", columns[0]),
                                        new XAttribute("PID", columns[1]),
                                        new XAttribute("ADDRESSTYPE", columns[2]),
                                        new XAttribute("HOUSE_ID", columns[3]),
                                        new XAttribute("HOUSETYPE", columns[4]),
                                        new XAttribute("ROOMNO", columns[5]),
                                        new XAttribute("CONDO", columns[6]),
                                        new XAttribute("HOUSENO", columns[7]),
                                        new XAttribute("SOISUB", columns[8]),
                                        new XAttribute("SOIMAIN", columns[9]),
                                        new XAttribute("ROAD", columns[10]),
                                        new XAttribute("VILLANAME", columns[11]),
                                        new XAttribute("VILLAGE", columns[12]),
                                        new XAttribute("TAMBON", columns[13]),
                                        new XAttribute("AMPUR", columns[14]),
                                        new XAttribute("CHANGWAT", columns[15]),
                                        new XAttribute("TELEPHONE", columns[16]),
                                        new XAttribute("MOBILE", columns[17]),
                                        new XAttribute("D_UPDATE", columns[18])

                               ); z2 += "    " + xml + Environment.NewLine;
                            }
                          
                        }

                        var lines3 = File.ReadAllLines("admission.csv");
                        lines3 = lines3.Skip(1).ToArray();
                        string z3 = "";
                        foreach (var str in lines3)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("ADMISSION_INFO",
                                        new XAttribute("HOSPCODE", columns[0]),
                                        new XAttribute("PID", columns[1]),
                                        new XAttribute("SEQ", columns[2]),
                                        new XAttribute("AN", columns[3]),
                                        new XAttribute("DATETIME_ADMIT", columns[4]),
                                        new XAttribute("WARDADMIT", columns[5]),
                                        new XAttribute("INSTYPE", columns[6]),
                                        new XAttribute("TYPEIN", columns[7]),
                                        new XAttribute("REFERINHOSP", columns[8]),
                                        new XAttribute("CAUSEIN", columns[9]),
                                        new XAttribute("ADMITWEIGHT", columns[10]),
                                        new XAttribute("ADMITHEIGHT", columns[11]),
                                        new XAttribute("DATETIME_DISCH", columns[12]),
                                        new XAttribute("WARDDISCH", columns[13]),
                                        new XAttribute("DISCHSTATUS", columns[14]),
                                        new XAttribute("DISCHTYPE", columns[15]),
                                        new XAttribute("REFEROUTHOSP", columns[16]),
                                        new XAttribute("CAUSEOUT", columns[17]),
                                        new XAttribute("COST", columns[18]),
                                        new XAttribute("PRICE", columns[19]),
                                        new XAttribute("PAYPRICE", columns[20]),
                                        new XAttribute("ACTUALPAY", columns[21]),
                                        new XAttribute("PROVIDER", columns[22]),
                                        new XAttribute("D_UPDATE", columns[23]),
                                        new XAttribute("DRG", columns[24]),
                                        new XAttribute("RW", columns[25]),
                                        new XAttribute("ADJRW", columns[26]),
                                        new XAttribute("ERROR", columns[27]),
                                        new XAttribute("WARNING", columns[28]),
                                        new XAttribute("ACTLOS", columns[29]),
                                        new XAttribute("GROUPER_VERSION", columns[30])

                                                    ); z3 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines4 = File.ReadAllLines("anc.csv");
                        lines4 = lines4.Skip(1).ToArray();
                        string z4 = "";
                        foreach (var str in lines4)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("ANC_INFO",
                                        new XAttribute("HOSPCODE", columns[0]),
                                        new XAttribute("PID", columns[1]),
                                        new XAttribute("SEQ", columns[2]),
                                        new XAttribute("DATE_SERV", columns[3]),
                                        new XAttribute("GRAVIDA", columns[4]),
                                        new XAttribute("ANCNO", columns[5]),
                                        new XAttribute("GA", columns[6]),
                                        new XAttribute("ANCRESULT", columns[7]),
                                        new XAttribute("ANCPLACE", columns[8]),
                                        new XAttribute("PROVIDER", columns[9]),
                                        new XAttribute("D_UPDATE", columns[10])

                                                      ); z4 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines5 = File.ReadAllLines("appointment.csv");
                        lines5 = lines5.Skip(1).ToArray();
                        string z5 = "";
                        foreach (var str in lines5)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("APPOINTMENT_INFO",
                                        new XAttribute("HOSPCODE", columns[0]),
                                        new XAttribute("PID", columns[1]),
                                        new XAttribute("AN", columns[2]),
                                        new XAttribute("SEQ", columns[3]),
                                        new XAttribute("DATE_SERV", columns[4]),
                                        new XAttribute("CLINIC", columns[5]),
                                        new XAttribute("APDATE", columns[6]),
                                        new XAttribute("APTYPE", columns[7]),
                                        new XAttribute("APDIAG", columns[8]),
                                        new XAttribute("PROVIDER", columns[9]),
                                        new XAttribute("D_UPDATE", columns[10])

                                                    ); z5 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines6 = File.ReadAllLines("card.csv");
                        lines6 = lines6.Skip(1).ToArray();
                        string z6 = "";
                        foreach (var str in lines6)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("CARD_INFO",
                                    new XAttribute("HOSPCODE", columns[0]),
                                    new XAttribute("PID", columns[1]),
                                    new XAttribute("INSTYPE_OLD", columns[2]),
                                    new XAttribute("INSTYPE_NEW", columns[3]),
                                    new XAttribute("INSID", columns[4]),
                                    new XAttribute("STARTDATE", columns[5]),
                                    new XAttribute("EXPIREDATE", columns[6]),
                                    new XAttribute("MAIN", columns[7]),
                                    new XAttribute("SUB", columns[8]),
                                    new XAttribute("D_UPDATE", columns[9])

                                                ); z6 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines7 = File.ReadAllLines("care_refer.csv");
                        lines7 = lines7.Skip(1).ToArray();
                        string z7 = "";
                        foreach (var str in lines7)
                        {
                            var columns = str.Split(',');
                            var a = columns[0];
                            if (a == t[0])
                            {
                                XElement xml = new XElement("CARE_REFER_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("REFERID", columns[1]),
                                new XAttribute("REFERID_PROVINCE", columns[2]),
                                new XAttribute("CARETYPE", columns[3]),
                                new XAttribute("D_UPDATE", columns[4])

                                            ); z7 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines8 = File.ReadAllLines("charge_ipd.csv");
                        lines8 = lines8.Skip(1).ToArray();
                        string z8 = "";
                        foreach (var str in lines8)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
                            if (a == t[2])
                            {
                                XElement xml = new XElement("CHARGE_IPD_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("AN", columns[2]),
                                new XAttribute("DATETIME_ADMIT", columns[3]),
                                new XAttribute("WARDSTAY", columns[4]),
                                new XAttribute("CHARGEITEM", columns[5]),
                                new XAttribute("CHARGELIST", columns[6]),
                                new XAttribute("QUANTITY", columns[7]),
                                new XAttribute("INSTYPE", columns[8]),
                                new XAttribute("COST", columns[9]),
                                new XAttribute("PRICE", columns[10]),
                                new XAttribute("PAYPRICE", columns[11]),
                                new XAttribute("D_UPDATE", columns[12])

                                            ); z8 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines9 = File.ReadAllLines("charge_opd.csv");
                        lines9 = lines9.Skip(1).ToArray();
                        string z9 = "";
                        foreach (var str in lines9)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("CHARGE_OPD_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("CLINIC", columns[4]),
                                new XAttribute("CHARGEITEM", columns[5]),
                                new XAttribute("CHARGELIST", columns[6]),
                                new XAttribute("QUANTITY", columns[7]),
                                new XAttribute("INSTYPE", columns[8]),
                                new XAttribute("COST", columns[9]),
                                new XAttribute("PRICE", columns[10]),
                                new XAttribute("PAYPRICE", columns[11]),
                                new XAttribute("D_UPDATE", columns[12])

                                            ); z9 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines10 = File.ReadAllLines("chronic.csv");
                        lines10 = lines10.Skip(1).ToArray();
                        string z10 = "";
                        foreach (var str in lines10)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("CHRONIC_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("DATE_DIAG", columns[2]),
                                new XAttribute("CHRONIC", columns[3]),
                                new XAttribute("HOSP_DX", columns[4]),
                                new XAttribute("HOSP_RX", columns[5]),
                                new XAttribute("DATE_DISCH", columns[6]),
                                new XAttribute("TYPEDISCH", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z10 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines11 = File.ReadAllLines("chronicfu.csv");
                        lines11 = lines11.Skip(1).ToArray();
                        string z11 = "";
                        foreach (var str in lines11)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("CHRONICFU_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("WEIGHT", columns[4]),
                                new XAttribute("HEIGHT", columns[5]),
                                new XAttribute("WAIST_CM", columns[6]),
                                new XAttribute("SBP", columns[7]),
                                new XAttribute("DBP", columns[8]),
                                new XAttribute("FOOT", columns[9]),
                                new XAttribute("RETINA", columns[10]),
                                new XAttribute("PROVIDER", columns[11]),
                                new XAttribute("D_UPDATE", columns[12])

                                            ); z11 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines12 = File.ReadAllLines("clinical_refer.csv");
                        lines12 = lines12.Skip(1).ToArray();
                        string z12 = "";
                        foreach (var str in lines12)
                        {
                            var columns = str.Split(',');
                            var a = columns[0];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("CLINICAL_REFER_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("REFERID", columns[1]),
                                new XAttribute("REFERID_PROVINCE", columns[2]),
                                new XAttribute("DATETIME_ASSESS", columns[3]),
                                new XAttribute("CLINICALCODE", columns[4]),
                                new XAttribute("CLINICALNAME", columns[5]),
                                new XAttribute("CLINICALVAULE", columns[6]),
                                new XAttribute("CLINICALRESULT", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z12 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines13 = File.ReadAllLines("community_activity.csv");
                        lines13 = lines13.Skip(1).ToArray();
                        string z13 = "";
                        foreach (var str in lines13)
                        {
                            var columns = str.Split(',');
                            var a = columns[0];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("COMMUNITY_ACTIVITY_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("VID", columns[1]),
                                new XAttribute("DATE_START", columns[2]),
                                new XAttribute("DATE_FINISH", columns[3]),
                                new XAttribute("COMACTIVITY", columns[4]),
                                new XAttribute("PROVIDER", columns[5]),
                                new XAttribute("D_UPDATE", columns[6])

                                            ); z13 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines14 = File.ReadAllLines("community_service.csv");
                        lines14 = lines14.Skip(1).ToArray();
                        string z14 = "";
                        foreach (var str in lines14)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("COMMUNITY_SERVICE_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("COMSERVICE", columns[4]),
                                new XAttribute("PROVIDER", columns[5]),
                                new XAttribute("D_UPDATE", columns[6])

                                            ); z14 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines15 = File.ReadAllLines("death.csv");
                        lines15 = lines15.Skip(1).ToArray();
                        string z15 = "";
                        string d = "";
                        foreach (var str in lines15)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                d = columns[5];
                                XElement xml = new XElement("DEATH_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("HOSPDEATH", columns[2]),
                                new XAttribute("AN", columns[3]),
                                new XAttribute("SEQ", columns[4]),
                                new XAttribute("DDEATH", columns[5]),
                                new XAttribute("CDEATH_A", columns[6]),
                                new XAttribute("CDEATH_B", columns[7]),
                                new XAttribute("CDEATH_C", columns[8]),
                                new XAttribute("CDEATH_D", columns[9]),
                                new XAttribute("ODISEASE", columns[10]),
                                new XAttribute("CDEATH", columns[11]),
                                new XAttribute("PREGDEATH", columns[12]),
                                new XAttribute("PDEATH", columns[13]),
                                new XAttribute("PROVIDER", columns[14]),
                                new XAttribute("D_UPDATE", columns[15])

                                            ); z15 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines16 = File.ReadAllLines("dental.csv");
                        lines16 = lines16.Skip(1).ToArray();
                        string z16 = "";
                        foreach (var str in lines16)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("DENTAL_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("DENTTYPE", columns[4]),
                                new XAttribute("SERVPLACE", columns[5]),
                                new XAttribute("PTEETH", columns[6]),
                                new XAttribute("PCARIES", columns[7]),
                                new XAttribute("PFILLING", columns[8]),
                                new XAttribute("PEXTRACT", columns[9]),
                                new XAttribute("DTEETH", columns[10]),
                                new XAttribute("DCARIES", columns[11]),
                                new XAttribute("DFILLING", columns[12]),
                                new XAttribute("DEXTRACT", columns[13]),
                                new XAttribute("NEED_FLUORIDE", columns[14]),
                                new XAttribute("NEED_SCALING", columns[15]),
                                new XAttribute("NEED_SEALANT", columns[16]),
                                new XAttribute("NEED_PFILLING", columns[17]),
                                new XAttribute("NEED_DFILLING", columns[18]),
                                new XAttribute("NEED_PEXTRACT", columns[19]),
                                new XAttribute("NEED_DEXTRACT", columns[20]),
                                new XAttribute("NPROSTHESIS", columns[21]),
                                new XAttribute("PERMANENT_PERMANENT", columns[22]),
                                new XAttribute("PERMANENT_PROSTHESIS", columns[23]),
                                new XAttribute("PROSTHESIS_PROSTHESIS", columns[24]),
                                new XAttribute("GUM", columns[25]),
                                new XAttribute("SCHOOLTYPE", columns[26]),
                                new XAttribute("CLASS", columns[27]),
                                new XAttribute("PROVIDER", columns[28]),
                                new XAttribute("D_UPDATE", columns[29])

                                            ); z16 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines17 = File.ReadAllLines("diagnosis_ipd.csv");
                        lines17 = lines17.Skip(1).ToArray();
                        string z17 = "";
                        foreach (var str in lines17)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("DIAGNOSIS_IPD_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("AN", columns[2]),
                                new XAttribute("DATETIME_ADMIT", columns[3]),
                                new XAttribute("WARDDIAG", columns[4]),
                                new XAttribute("DIAGTYPE", columns[5]),
                                new XAttribute("DIAGCODE", columns[6]),
                                new XAttribute("PROVIDER", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z17 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines18 = File.ReadAllLines("diagnosis_opd.csv");
                        lines18 = lines18.Skip(1).ToArray();
                        string z18 = "";
                        foreach (var str in lines18)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("DIAGNOSIS_OPD_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("DIAGTYPE", columns[4]),
                                new XAttribute("DIAGCODE", columns[5]),
                                new XAttribute("CLINIC", columns[6]),
                                new XAttribute("PROVIDER", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z18 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines19 = File.ReadAllLines("disability.csv");
                        lines19 = lines19.Skip(1).ToArray();
                        string z19 = "";
                        foreach (var str in lines19)
                        {
                            var columns = str.Split(',');
                            var a = columns[2];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("DISABILITY_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("DISABID", columns[1]),
                                new XAttribute("PID", columns[2]),
                                new XAttribute("DISABTYPE", columns[3]),
                                new XAttribute("DISABCAUSE", columns[4]),
                                new XAttribute("DIAGCODE", columns[5]),
                                new XAttribute("DATE_DETECT", columns[6]),
                                new XAttribute("DATE_DISAB", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z19 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines20 = File.ReadAllLines("drug_ipd.csv");
                        lines20 = lines20.Skip(1).ToArray();
                        string z20 = "";
                        foreach (var str in lines20)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("DRUG_IPD_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("AN", columns[2]),
                                new XAttribute("DATETIME_ADMIT", columns[3]),
                                new XAttribute("WARDSTAY", columns[4]),
                                new XAttribute("TYPEDRUG", columns[5]),
                                new XAttribute("DIDSTD", columns[6]),
                                new XAttribute("DNAME", columns[7]),
                                new XAttribute("DATESTART", columns[8]),
                                new XAttribute("DATEFINISH", columns[9]),
                                new XAttribute("AMOUNT", columns[10]),
                                new XAttribute("UNIT", columns[11]),
                                new XAttribute("UNIT_PACKING", columns[12]),
                                new XAttribute("DRUGPRICE", columns[13]),
                                new XAttribute("DRUGCOST", columns[14]),
                                new XAttribute("PROVIDER", columns[15]),
                                new XAttribute("D_UPDATE", columns[16])

                                            ); z20 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines21 = File.ReadAllLines("drug_opd.csv");
                        lines21 = lines21.Skip(1).ToArray();
                        string z21 = "";
                        foreach (var str in lines21)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("DRUG_OPD_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("CLINIC", columns[4]),
                                new XAttribute("DIDSTD", columns[5]),
                                new XAttribute("DNAME", columns[6]),
                                new XAttribute("AMOUNT", columns[7]),
                                new XAttribute("UNIT", columns[8]),
                                new XAttribute("UNIT_PACKING", columns[9]),
                                new XAttribute("DRUGPRICE", columns[10]),
                                new XAttribute("DRUGCOST", columns[11]),
                                new XAttribute("PROVIDER", columns[12]),
                                new XAttribute("D_UPDATE", columns[13])

                                            ); z21 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines22 = File.ReadAllLines("drug_refer.csv");
                        lines22 = lines22.Skip(1).ToArray();
                        string z22 = "";
                        foreach (var str in lines22)
                        {
                            var columns = str.Split(',');
                            var a = columns[0];
                            if (a == t[0])
                            {
                                XElement xml = new XElement("DRUG_REFER_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("REFERID", columns[1]),
                                new XAttribute("REFERID_PROVINCE", columns[2]),
                                new XAttribute("DATETIME_DSTART", columns[3]),
                                new XAttribute("DATETIME_DFINISH", columns[4]),
                                new XAttribute("DIDSTD", columns[5]),
                                new XAttribute("DNAME", columns[6]),
                                new XAttribute("DDESCRIPTION", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z22 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines23 = File.ReadAllLines("drugallergy.csv");
                        lines23 = lines23.Skip(1).ToArray();
                        string z23 = "";
                        foreach (var str in lines23)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("DRUGALLERGY_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("DATERECORD", columns[2]),
                                new XAttribute("DRUGALLERGY", columns[3]),
                                new XAttribute("DNAME", columns[4]),
                                new XAttribute("TYPEDX", columns[5]),
                                new XAttribute("ALEVEL", columns[6]),
                                new XAttribute("SYMPTOM", columns[7]),
                                new XAttribute("INFORMANT", columns[8]),
                                new XAttribute("INFORMHOSP", columns[9]),
                                new XAttribute("D_UPDATE", columns[10])

                                            ); z23 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines24 = File.ReadAllLines("epi.csv");
                        lines24 = lines24.Skip(1).ToArray();
                        string z24 = "";
                        foreach (var str in lines24)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("EPI_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("VACCINETYPE", columns[4]),
                                new XAttribute("VACCINEPLACE", columns[5]),
                                new XAttribute("PROVIDER", columns[6]),
                                new XAttribute("D_UPDATE", columns[7])

                                            ); z24 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines25 = File.ReadAllLines("fp.csv");
                        lines25 = lines25.Skip(1).ToArray();
                        string z25 = "";
                        foreach (var str in lines25)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("FP_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("FPTYPE", columns[4]),
                                new XAttribute("FPPLACE", columns[5]),
                                new XAttribute("PROVIDER", columns[6]),
                                new XAttribute("D_UPDATE", columns[7])

                                            ); z25 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines26 = File.ReadAllLines("functional.csv");
                        lines26 = lines26.Skip(1).ToArray();
                        string z26 = "";
                        foreach (var str in lines26)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("FUNCTIONAL_INFO", 
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("FUNCTIONAL_TEST", columns[4]),
                                new XAttribute("TESTRESULT", columns[5]),
                                new XAttribute("DEPENDENT", columns[6]),
                                new XAttribute("PROVIDER", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z26 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines27 = File.ReadAllLines("home.csv");
                        lines27 = lines27.Skip(1).ToArray();
                        string z27 = "";
                        foreach (var str in lines27)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[3] && b == t[0])
                            {
                                XElement xml = new XElement("HOME_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("HID", columns[1]),
                                new XAttribute("HOUSE_ID", columns[2]),
                                new XAttribute("HOUSETYPE", columns[3]),
                                new XAttribute("ROOMNO", columns[4]),
                                new XAttribute("CONDO", columns[5]),
                                new XAttribute("HOUSE", columns[6]),
                                new XAttribute("SOISUB", columns[7]),
                                new XAttribute("SOIMAIN", columns[8]),
                                new XAttribute("ROAD", columns[9]),
                                new XAttribute("VILLANAME", columns[10]),
                                new XAttribute("VILLAGE", columns[11]),
                                new XAttribute("TAMBON", columns[12]),
                                new XAttribute("AMPUR", columns[13]),
                                new XAttribute("CHANGWAT", columns[14]),
                                new XAttribute("TELEPHONE", columns[15]),
                                new XAttribute("LATITUDE", columns[16]),
                                new XAttribute("LONGITUDE", columns[17]),
                                new XAttribute("NFAMILY", columns[18]),
                                new XAttribute("LOCATYPE", columns[19]),
                                new XAttribute("VHVID", columns[20]),
                                new XAttribute("HEADID", columns[21]),
                                new XAttribute("TOILET", columns[22]),
                                new XAttribute("WATER", columns[23]),
                                new XAttribute("WATERTYPE", columns[24]),
                                new XAttribute("GARBAGE", columns[25]),
                                new XAttribute("HOUSING", columns[26]),
                                new XAttribute("DURABILITY", columns[27]),
                                new XAttribute("CLEANLINESS", columns[28]),
                                new XAttribute("VENTILATION", columns[29]),
                                new XAttribute("LIGHT", columns[30]),
                                new XAttribute("WATERTM", columns[31]),
                                new XAttribute("MFOOD", columns[32]),
                                new XAttribute("BCONTROL", columns[33]),
                                new XAttribute("ACONTROL", columns[34]),
                                new XAttribute("CHEMICAL", columns[35]),
                                new XAttribute("OUTDATE", columns[36]),
                                new XAttribute("D_UPDATE", columns[37])

                                            ); z27 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines28 = File.ReadAllLines("icf.csv");
                        lines28 = lines28.Skip(1).ToArray();
                        string z28 = "";
                        foreach (var str in lines28)
                        {
                            var columns = str.Split(',');
                            var a = columns[2];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("ICF_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("DISABID", columns[1]),
                                new XAttribute("PID", columns[2]),
                                new XAttribute("SEQ", columns[3]),
                                new XAttribute("DATE_SERV", columns[4]),
                                new XAttribute("ICF", columns[5]),
                                new XAttribute("QUALIFIER", columns[6]),
                                new XAttribute("PROVIDER", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z28 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines29 = File.ReadAllLines("investigation_refer.csv");
                        lines29 = lines29.Skip(1).ToArray();
                        string z29 = "";
                        foreach (var str in lines29)
                        {
                            var columns = str.Split(',');
                            var a = columns[0];
                            if (a == t[0])
                            {
                                XElement xml = new XElement("INVESTIGATION_REFER_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("REFERID", columns[1]),
                                new XAttribute("REFERID_PROVINCE", columns[2]),
                                new XAttribute("DATETIME_INVEST", columns[3]),
                                new XAttribute("INVESTCODE", columns[4]),
                                new XAttribute("INVESTNAME", columns[5]),
                                new XAttribute("DATETIME_REPORT", columns[6]),
                                new XAttribute("INVESTVALUE", columns[7]),
                                new XAttribute("INVESTRESULT", columns[8]),
                                new XAttribute("D_UPDATE", columns[9])

                                            ); z29 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines30 = File.ReadAllLines("labfu.csv");
                        lines30 = lines30.Skip(1).ToArray();
                        string z30 = "";
                        foreach (var str in lines30)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("LABFU_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("LABTEST", columns[4]),
                                new XAttribute("LABRESULT", columns[5]),
                                new XAttribute("D_UPDATE", columns[6])

                                            ); z30 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines31 = File.ReadAllLines("labor.csv");
                        lines31 = lines31.Skip(1).ToArray();
                        string z31 = "";
                        foreach (var str in lines31)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("LABOR_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("GRAVIDA", columns[2]),
                                new XAttribute("LMP", columns[3]),
                                new XAttribute("EDC", columns[4]),
                                new XAttribute("BDATE", columns[5]),
                                new XAttribute("BRESULT", columns[6]),
                                new XAttribute("BPLACE", columns[7]),
                                new XAttribute("BHOSP", columns[8]),
                                new XAttribute("BTYPE", columns[9]),
                                new XAttribute("BDOCTOR", columns[10]),
                                new XAttribute("LBORN", columns[11]),
                                new XAttribute("SBORN", columns[12]),
                                new XAttribute("D_UPDATE", columns[13])

                                            ); z31 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines32 = File.ReadAllLines("ncdscreen.csv");
                        lines32 = lines32.Skip(1).ToArray();
                        string z32 = "";
                        foreach (var str in lines32)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("NCDSCREEN_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("SERVPLACE", columns[4]),
                                new XAttribute("SMOKE", columns[5]),
                                new XAttribute("ALCOHOL", columns[6]),
                                new XAttribute("DMFAMILY", columns[7]),
                                new XAttribute("HTFAMILY", columns[8]),
                                new XAttribute("WEIGHT", columns[9]),
                                new XAttribute("HEIGHT", columns[10]),
                                new XAttribute("WAIST_CM", columns[11]),
                                new XAttribute("SBP_1", columns[12]),
                                new XAttribute("DBP_1", columns[13]),
                                new XAttribute("SBP_2", columns[14]),
                                new XAttribute("DBP_2", columns[15]),
                                new XAttribute("BSLEVEL", columns[16]),
                                new XAttribute("BSTEST", columns[17]),
                                new XAttribute("SCREENPLACE", columns[18]),
                                new XAttribute("PROVIDER", columns[19]),
                                new XAttribute("D_UPDATE", columns[20])

                                            ); z32 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines33 = File.ReadAllLines("newborn.csv");
                        lines33= lines33.Skip(1).ToArray();
                        string z33 = "";
                        foreach (var str in lines33)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("NEWBORN_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("MPID", columns[2]),
                                new XAttribute("GRAVIDA", columns[3]),
                                new XAttribute("GA", columns[4]),
                                new XAttribute("BDATE", columns[5]),
                                new XAttribute("BTIME", columns[6]),
                                new XAttribute("BPLACE", columns[7]),
                                new XAttribute("BHOSP", columns[8]),
                                new XAttribute("BIRTHNO", columns[9]),
                                new XAttribute("BTYPE", columns[10]),
                                new XAttribute("BDOCTOR", columns[11]),
                                new XAttribute("BWEIGHT", columns[12]),
                                new XAttribute("ASPHYXIA", columns[13]),
                                new XAttribute("VITK", columns[14]),
                                new XAttribute("TSH", columns[15]),
                                new XAttribute("TSHRESULT", columns[16]),
                                new XAttribute("D_UPDATE", columns[17])

                                            ); z33 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines34 = File.ReadAllLines("newborncare.csv");
                        lines34 = lines34.Skip(1).ToArray();
                        string z34 = "";
                        foreach (var str in lines34)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("NEWBORNCARE_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("BDATE", columns[3]),
                                new XAttribute("BCARE", columns[4]),
                                new XAttribute("BCPLACE", columns[5]),
                                new XAttribute("BCARERESULT", columns[6]),
                                new XAttribute("FOOD", columns[7]),
                                new XAttribute("PROVIDER", columns[8]),
                                new XAttribute("D_UPDATE", columns[9])

                                            ); z34 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines35 = File.ReadAllLines("nutrition.csv");
                        lines35 = lines35.Skip(1).ToArray();
                        string z35 = "";
                        foreach (var str in lines35)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("NUTRITION_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("NUTRITIONPLACE", columns[4]),
                                new XAttribute("WEIGHT", columns[5]),
                                new XAttribute("HEIGHT", columns[6]),
                                new XAttribute("HEADCIRCUM", columns[7]),
                                new XAttribute("CHILDDEVELOP", columns[8]),
                                new XAttribute("FOOD", columns[9]),
                                new XAttribute("BOTTLE", columns[10]),
                                new XAttribute("PROVIDER", columns[11]),
                                new XAttribute("D_UPDATE", columns[12])

                                            ); z35 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines36 = File.ReadAllLines("postnatal.csv");
                        lines36 = lines36.Skip(1).ToArray();
                        string z36 = "";
                        foreach (var str in lines36)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("POSTNATAL_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("GRAVIDA", columns[3]),
                                new XAttribute("BDATE", columns[4]),
                                new XAttribute("PPCARE", columns[5]),
                                new XAttribute("PPPLACE", columns[6]),
                                new XAttribute("PPRESULT", columns[7]),
                                new XAttribute("PROVIDER", columns[8]),
                                new XAttribute("D_UPDATE", columns[9])

                                            ); z36 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines37 = File.ReadAllLines("prenatal.csv");
                        lines37 = lines37.Skip(1).ToArray();
                        string z37 = "";
                        foreach (var str in lines)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("PRENATAL_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("GRAVIDA", columns[2]),
                                new XAttribute("LMP", columns[3]),
                                new XAttribute("EDC", columns[4]),
                                new XAttribute("VDRL_RESULT", columns[5]),
                                new XAttribute("HB_RESULT", columns[6]),
                                new XAttribute("HIV_RESULT", columns[7]),
                                new XAttribute("DATE_HCT", columns[8]),
                                new XAttribute("HCT_RESULT", columns[9]),
                                new XAttribute("THALASSEMIA", columns[10]),
                                new XAttribute("D_UPDATE", columns[11])

                                            ); z37 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines38 = File.ReadAllLines("procedure_ipd.csv");
                        lines38 = lines38.Skip(1).ToArray();
                        string z38 = "";
                        foreach (var str in lines38)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("PROCEDURE_IPD_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("AN", columns[2]),
                                new XAttribute("DATETIME_ADMIT", columns[3]),
                                new XAttribute("WARDSTAY", columns[4]),
                                new XAttribute("PROCEDCODE", columns[5]),
                                new XAttribute("TIMESTART", columns[6]),
                                new XAttribute("TIMEFINISH", columns[7]),
                                new XAttribute("SERVICEPRICE", columns[8]),
                                new XAttribute("PROVIDER", columns[9]),
                                new XAttribute("D_UPDATE", columns[10])

                                            ); z38 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines39 = File.ReadAllLines("procedure_opd.csv");
                        lines39 = lines39.Skip(1).ToArray();
                        string z39 = "";
                        foreach (var str in lines39)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("PROCEDURE_OPD_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("CLINIC", columns[4]),
                                new XAttribute("PROCEDCODE", columns[5]),
                                new XAttribute("SERVICEPRICE", columns[6]),
                                new XAttribute("PROVIDER", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z39 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines40 = File.ReadAllLines("procedure_refer.csv");
                        lines40 = lines40.Skip(1).ToArray();
                        string z40 = "";
                        foreach (var str in lines40)
                        {
                            var columns = str.Split(',');
                            var a = columns[0];
                            if (a == t[0])
                            {
                                XElement xml = new XElement("PROCEDURE_REFER_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("REFERID", columns[1]),
                                new XAttribute("REFERID_PROVINCE", columns[2]),
                                new XAttribute("TIMESTART", columns[3]),
                                new XAttribute("TIMEFINISH", columns[4]),
                                new XAttribute("PROCEDURENAME", columns[5]),
                                new XAttribute("PROCEDCODE", columns[6]),
                                new XAttribute("PDESCRIPTION", columns[7]),
                                new XAttribute("PROCEDRESULT", columns[8]),
                                new XAttribute("PROVIDER", columns[9]),
                                new XAttribute("D_UPDATE", columns[10])

                                            ); z40 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines41 = File.ReadAllLines("provider.csv");
                        lines41 = lines41.Skip(1).ToArray();
                        string z41 = "";
                        foreach (var str in lines41)
                        {
                            var columns = str.Split(',');
                            var a = columns[4];
                            if (a == t[1])
                            {
                                XElement xml = new XElement("PROVIDER_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PROVIDER", columns[1]),
                                new XAttribute("REGISTERNO", columns[2]),
                                new XAttribute("COUNCIL", columns[3]),
                                new XAttribute("CID", columns[4]),
                                new XAttribute("PRENAME", columns[5]),
                                new XAttribute("NAME", columns[6]),
                                new XAttribute("LNAME", columns[7]),
                                new XAttribute("SEX", columns[8]),
                                new XAttribute("BIRTH", columns[9]),
                                new XAttribute("PROVIDERTYPE", columns[10]),
                                new XAttribute("STARTDATE", columns[11]),
                                new XAttribute("OUTDATE", columns[12]),
                                new XAttribute("MOVEFROM", columns[13]),
                                new XAttribute("MOVETO", columns[14]),
                                new XAttribute("D_UPDATE", columns[15])

                                            ); z41 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines42 = File.ReadAllLines("refer_history.csv");
                        lines42 = lines42.Skip(1).ToArray();
                        string z42 = "";
                        foreach (var str in lines42)
                        {
                            var columns = str.Split(',');
                            var a = columns[3];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("REFER_HISTORY_INFO", 
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("REFERID", columns[1]),
                                new XAttribute("REFERID_PROVINCE", columns[2]),
                                new XAttribute("PID", columns[3]),
                                new XAttribute("SEQ", columns[4]),
                                new XAttribute("AN", columns[5]),
                                new XAttribute("REFERID_ORIGIN", columns[6]),
                                new XAttribute("HOSPCODE_ORIGIN", columns[7]),
                                new XAttribute("DATETIME_SERV", columns[8]),
                                new XAttribute("DATETIME_ADMIT", columns[9]),
                                new XAttribute("DATETIME_REFER", columns[10]),
                                new XAttribute("CLINIC_REFER", columns[11]),
                                new XAttribute("HOSP_DESTINATION", columns[12]),
                                new XAttribute("CHIEFCOMP", columns[13]),
                                new XAttribute("PHYSICALEXAM", columns[14]),
                                new XAttribute("DIAGFIRST", columns[15]),
                                new XAttribute("DIAGLAST", columns[16]),
                                new XAttribute("PSTATUS", columns[17]),
                                new XAttribute("PTYPE", columns[18]),
                                new XAttribute("EMERGENCY", columns[19]),
                                new XAttribute("PTYPEDIS", columns[20]),
                                new XAttribute("CAUSEOUT", columns[21]),
                                new XAttribute("REQUEST", columns[22]),
                                new XAttribute("PROVIDER", columns[23]),
                                new XAttribute("D_UPDATE", columns[24])

                                            ); z42 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines43 = File.ReadAllLines("refer_result.csv");
                        lines43 = lines43.Skip(1).ToArray();
                        string z43 = "";
                        foreach (var str in lines43)
                        {
                            var columns = str.Split(',');
                            var a = columns[0];
                            if (a == t[0])
                            {
                                XElement xml = new XElement("REFER_RESULT_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("REFERID_SOURCE", columns[1]),
                                new XAttribute("REFERID_PROVINCE", columns[2]),
                                new XAttribute("HOSP_SOURCE", columns[3]),
                                new XAttribute("REFER_RESULT", columns[4]),
                                new XAttribute("DATETIME_IN", columns[5]),
                                new XAttribute("PID_IN", columns[6]),
                                new XAttribute("AN_IN", columns[7]),
                                new XAttribute("REASON", columns[8]),
                                new XAttribute("D_UPDATE", columns[9])

                                            ); z43 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines44 = File.ReadAllLines("rehabilitation.csv");
                        lines44 = lines44.Skip(1).ToArray();
                        string z44 = "";
                        foreach (var str in lines44)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("REHABILITATION_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("AN", columns[3]),
                                new XAttribute("DATE_ADMIT", columns[4]),
                                new XAttribute("DATE_SERV", columns[5]),
                                new XAttribute("DATE_START", columns[6]),
                                new XAttribute("DATE_FINISH", columns[7]),
                                new XAttribute("REHABCODE", columns[8]),
                                new XAttribute("AT_DEVICE", columns[9]),
                                new XAttribute("AT_NO", columns[10]),
                                new XAttribute("REHABPLACE", columns[11]),
                                new XAttribute("PROVIDER", columns[12]),
                                new XAttribute("D_UPDATE", columns[13])

                                            ); z44 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines45 = File.ReadAllLines("service.csv");
                        lines45 = lines45.Skip(1).ToArray();
                        string z45 = "";
                        foreach (var str in lines45)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml =  new XElement("SERVICE_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("HN", columns[2]),
                                new XAttribute("SEQ", columns[3]),
                                new XAttribute("DATE_SERV", columns[4]),
                                new XAttribute("TIME_SERV", columns[5]),
                                new XAttribute("LOCATION", columns[6]),
                                new XAttribute("INTIME", columns[7]),
                                new XAttribute("INSTYPE", columns[8]),
                                new XAttribute("INSID", columns[9]),
                                new XAttribute("MAIN", columns[10]),
                                new XAttribute("TYPEIN", columns[11]),
                                new XAttribute("REFERINHOSP", columns[12]),
                                new XAttribute("CAUSEIN", columns[13]),
                                new XAttribute("CHIEFCOMP", columns[14]),
                                new XAttribute("SERVPLACE", columns[15]),
                                new XAttribute("BTEMP", columns[16]),
                                new XAttribute("SBP", columns[17]),
                                new XAttribute("DBP", columns[18]),
                                new XAttribute("PR", columns[19]),
                                new XAttribute("RR", columns[20]),
                                new XAttribute("TYPEOUT", columns[21]),
                                new XAttribute("REFEROUTHOSP", columns[22]),
                                new XAttribute("CAUSEOUT", columns[23]),
                                new XAttribute("COST", columns[24]),
                                new XAttribute("PRICE", columns[25]),
                                new XAttribute("PAYPRICE", columns[26]),
                                new XAttribute("ACTUALPAY", columns[27]),
                                new XAttribute("D_UPDATE", columns[28])

                                            ); z45 += "    " + xml + Environment.NewLine;
                            }
                        }

                        var lines46 = File.ReadAllLines("specialpp.csv");
                        lines46 = lines46.Skip(1).ToArray();
                        string z46 = "";
                        foreach (var str in lines46)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("SPECIALPP_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("SERVPLACE", columns[4]),
                                new XAttribute("PPSPECIAL", columns[5]),
                                new XAttribute("PPSPLACE", columns[6]),
                                new XAttribute("PROVIDER", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z46 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines47 = File.ReadAllLines("surveillance.csv");
                        lines47 = lines47.Skip(1).ToArray();
                        string z47 = "";
                        foreach (var str in lines47)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("SURVEILLANCE_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("SEQ", columns[2]),
                                new XAttribute("DATE_SERV", columns[3]),
                                new XAttribute("AN", columns[4]),
                                new XAttribute("DATETIME_ADMIT", columns[5]),
                                new XAttribute("SYNDROME", columns[6]),
                                new XAttribute("DIAGCODE", columns[7]),
                                new XAttribute("CODE506", columns[8]),
                                new XAttribute("DIAGCODELAST", columns[9]),
                                new XAttribute("CODE506LAST", columns[10]),
                                new XAttribute("ILLDATE", columns[11]),
                                new XAttribute("ILLHOUSE", columns[12]),
                                new XAttribute("ILLVILLAGE", columns[13]),
                                new XAttribute("ILLTAMBON", columns[14]),
                                new XAttribute("ILLAMPUR", columns[15]),
                                new XAttribute("ILLCHANGWAT", columns[16]),
                                new XAttribute("LATITUDE", columns[17]),
                                new XAttribute("LONGITUDE", columns[18]),
                                new XAttribute("PTSTATUS", columns[19]),
                                new XAttribute("DATE_DEATH", columns[20]),
                                new XAttribute("COMPLICATION", columns[21]),
                                new XAttribute("ORGANISM", columns[22]),
                                new XAttribute("PROVIDER", columns[23]),
                                new XAttribute("D_UPDATE", columns[24])

                                            ); z47 += "    " + xml + Environment.NewLine;
                            }
                        }
                        var lines48 = File.ReadAllLines("village.csv");
                        lines48 = lines48.Skip(1).ToArray();
                        string z48 = "";
                        foreach (var str in lines48)
                        {
                            var columns = str.Split(',');
                            var a = columns[0];
                            if (a == t[0])
                            {
                               
                                    XElement xml = new XElement("VILLAGE_INFO",
                                         new XAttribute("HOSPCODE", columns[0]),
                                         new XAttribute("VID", columns[1]),
                                         new XAttribute("NTRADITIONAL", columns[2]),
                                         new XAttribute("NMONK", columns[3]),
                                         new XAttribute("NRELIGIONLEADER", columns[4]),
                                         new XAttribute("NBROADCAST", columns[5]),
                                         new XAttribute("NRADIO", columns[6]),
                                         new XAttribute("NPCHC", columns[7]),
                                         new XAttribute("NCLINIC", columns[8]),
                                         new XAttribute("NDRUGSTORE", columns[9]),
                                         new XAttribute("NCHILDCENTER", columns[10]),
                                         new XAttribute("NPSCHOOL", columns[11]),
                                         new XAttribute("NSSCHOOL", columns[12]),
                                         new XAttribute("NTEMPLE", columns[13]),
                                         new XAttribute("NRELIGIOUSPLACE", columns[14]),
                                         new XAttribute("NMARKET", columns[15]),
                                         new XAttribute("NSHOP", columns[16]),
                                         new XAttribute("NFOODSHOP", columns[17]),
                                         new XAttribute("NSTALL", columns[18]),
                                         new XAttribute("NRAINTANK", columns[19]),
                                         new XAttribute("NCHICKENFARM", columns[20]),
                                         new XAttribute("NPIGFARM", columns[21]),
                                         new XAttribute("WASTEWATER", columns[22]),
                                         new XAttribute("GARBAGE", columns[23]),
                                         new XAttribute("NFACTORY", columns[24]),
                                         new XAttribute("LATITUDE", columns[25]),
                                         new XAttribute("LONGITUDE", columns[26]),
                                         new XAttribute("OUTDATE", columns[27]),
                                         new XAttribute("NUMACTUALLY", columns[28]),
                                         new XAttribute("RISKTYPE", columns[29]),
                                         new XAttribute("NUMSTATELESS", columns[30]),
                                         new XAttribute("NEXERCISECLUB", columns[31]),
                                         new XAttribute("NOLDERLYCLUB", columns[32]),
                                         new XAttribute("NDISABLECLUB", columns[33]),
                                         new XAttribute("NNUMBERONECLUB", columns[34]),
                                         new XAttribute("D_UPDATE", columns[35])

                                                     );
                                    z48 += xml + Environment.NewLine;
                               
                            }
                        }
                        var lines49 = File.ReadAllLines("women.csv");
                        lines49 = lines49.Skip(1).ToArray();
                        string z49 = "";
                        foreach (var str in lines49)
                        {
                            var columns = str.Split(',');
                            var a = columns[1];
							var b = columns[0];
							if (a == t[2] && b == t[0])
                            {
                                XElement xml = new XElement("WOMEN_INFO",
                                new XAttribute("HOSPCODE", columns[0]),
                                new XAttribute("PID", columns[1]),
                                new XAttribute("FPTYPE", columns[2]),
                                new XAttribute("NOFPCAUSE", columns[3]),
                                new XAttribute("TOTALSON", columns[4]),
                                new XAttribute("NUMBERSON", columns[5]),
                                new XAttribute("ABORTION", columns[6]),
                                new XAttribute("STILLBIRTH", columns[7]),
                                new XAttribute("D_UPDATE", columns[8])

                                            ); z49 += "    " + xml + Environment.NewLine;
                            }
                        }
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("Writing XML files Success...");
                        Console.WriteLine("");
                        Console.WriteLine("");

                        using (StreamWriter streamWriter = new StreamWriter(new FileStream(xmlPath, FileMode.Append)))
                        {
                            //streamWriter.WriteLine("<?xml version=\"1.0\"?>");
                            streamWriter.WriteLine("<PHR_INFO MOPH_ID = \"\" IS_DEAD = \""+d+"\">");
                            streamWriter.WriteLine("<SIGN_LIST>");
                            streamWriter.WriteLine("<SIGN_INFO CID=\"" + t[1] + "\">");
                            streamWriter.WriteLine("<SECTION_LIST>");
                            //streamWriter.Write(xml);
                            string line;

                            //string xmlFilePath = xmlPath;

                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine("");
                            Console.WriteLine("Saving XML files...");

                            line = streamReader.ReadLine();

                            streamWriter.WriteLine("<PERSON_LIST>");
                            streamWriter.Write(z);
                            streamWriter.WriteLine("</PERSON_LIST>");

							streamWriter.WriteLine("<ACCIDENT_LIST>");
							streamWriter.Write(z1);
							streamWriter.WriteLine("</ACCIDENT_LIST>");

							streamWriter.WriteLine("<ADDRESS_LIST>");
							streamWriter.Write(z2);
							streamWriter.WriteLine("</ADDRESS_LIST>");

							streamWriter.WriteLine("<ADMISSION_LIST>");
							streamWriter.Write(z3);
							streamWriter.WriteLine("</ADMISSION_LIST>");

							streamWriter.WriteLine("<ANC_LIST>");
							streamWriter.Write(z4);
							streamWriter.WriteLine("</ANC_LIST>");

							streamWriter.WriteLine("<APPOINTMENT_LIST>");
							streamWriter.Write(z5);
							streamWriter.WriteLine("</APPOINTMENT_LIST>");

							streamWriter.WriteLine("<CARD_LIST>");
							streamWriter.Write(z6);
							streamWriter.WriteLine("</CARD_LIST>");

							streamWriter.WriteLine("<CARE_REFER_LIST>");
							streamWriter.Write(z7);
							streamWriter.WriteLine("</CARE_REFER_LIST>");

							streamWriter.WriteLine("<CHARGE_IPD_LIST>");
							streamWriter.Write(z8);
							streamWriter.WriteLine("</CHARGE_IPD_LIST>");

							streamWriter.WriteLine("<CHARGE_OPD_LIST>");
							streamWriter.Write(z9);
							streamWriter.WriteLine("</CHARGE_OPD_LIST>");

							streamWriter.WriteLine("<CHRONIC_LIST>");
							streamWriter.Write(z10);
							streamWriter.WriteLine("</CHRONIC_LIST>");

							streamWriter.WriteLine("<CHRONICFU_LIST>");
							streamWriter.Write(z11);
							streamWriter.WriteLine("</CHRONICFU_LIST>");

							streamWriter.WriteLine("<CLINICAL_REFER_LIST>");
							streamWriter.Write(z12);
							streamWriter.WriteLine("</CLINICAL_REFER_LIST>");

							streamWriter.WriteLine("<COMMUNITY_ACTIVITY_LIST>");
							streamWriter.Write(z13);
							streamWriter.WriteLine("</COMMUNITY_ACTIVITY_LIST>");

							streamWriter.WriteLine("<COMMUNITY_SERVICE_LIST>");
							streamWriter.Write(z14);
							streamWriter.WriteLine("</COMMUNITY_SERVICE_LIST>");

							streamWriter.WriteLine("<DEATH_LIST>");
							streamWriter.Write(z15);
							streamWriter.WriteLine("</DEATH_LIST>");

							streamWriter.WriteLine("<DENTAL_LIST>");
							streamWriter.Write(z16);
							streamWriter.WriteLine("</DENTAL_LIST>");

							streamWriter.WriteLine("<DIAGNOSIS_IPD_LIST>");
							streamWriter.Write(z17);
							streamWriter.WriteLine("</DIAGNOSIS_IPD_LIST>");

							streamWriter.WriteLine("<DIAGNOSIS_OPD_LIST>");
							streamWriter.Write(z18);
							streamWriter.WriteLine("</DIAGNOSIS_OPD_LIST>");

							streamWriter.WriteLine("<DISABILITY_LIST>");
							streamWriter.Write(z19);
							streamWriter.WriteLine("</DISABILITY_LIST>");

							streamWriter.WriteLine("<DRUG_IPD_LIST>");
							streamWriter.Write(z20);
							streamWriter.WriteLine("</DRUG_IPD_LIST>");

							streamWriter.WriteLine("<DRUG_OPD_LIST>");
							streamWriter.Write(z21);
							streamWriter.WriteLine("</DRUG_OPD_LIST>");

							streamWriter.WriteLine("<DRUG_REFER_LIST>");
							streamWriter.Write(z22);
							streamWriter.WriteLine("</DRUG_REFER_LIST>");

							streamWriter.WriteLine("<DRUGALLERGY_LIST>");
							streamWriter.Write(z23);
							streamWriter.WriteLine("</DRUGALLERGY_LIST>");

							streamWriter.WriteLine("<EPI_LIST>");
							streamWriter.Write(z24);
							streamWriter.WriteLine("</EPI_LIST>");

							streamWriter.WriteLine("<FP_LIST>");
							streamWriter.Write(z25);
							streamWriter.WriteLine("</FP_LIST>");

							streamWriter.WriteLine("<FUNCTIONAL_LIST>");
							streamWriter.Write(z26);
							streamWriter.WriteLine("</FUNCTIONAL_LIST>");

							streamWriter.WriteLine("<HOME_LIST>");
							streamWriter.Write(z27);
							streamWriter.WriteLine("</HOME_LIST>");

							streamWriter.WriteLine("<ICF_LIST>");
							streamWriter.Write(z28);
							streamWriter.WriteLine("</ICF_LIST>");

							streamWriter.WriteLine("<INVESTIGATION_REFER_LIST>");
							streamWriter.Write(z29);
							streamWriter.WriteLine("</INVESTIGATION_REFER_LIST>");

							streamWriter.WriteLine("<LABFU_LIST>");
							streamWriter.Write(z30);
							streamWriter.WriteLine("</LABFU_LIST>");

							streamWriter.WriteLine("<LABOR_LIST>");
							streamWriter.Write(z31);
							streamWriter.WriteLine("</LABOR_LIST>");

							streamWriter.WriteLine("<NCDSCREEN_LIST>");
							streamWriter.Write(z32);
							streamWriter.WriteLine("</NCDSCREEN_LIST>");

							streamWriter.WriteLine("<NEWBORN_LIST>");
							streamWriter.Write(z33);
							streamWriter.WriteLine("</NEWBORN_LIST>");

							streamWriter.WriteLine("<NEWBORNCARE_LIST>");
							streamWriter.Write(z34);
							streamWriter.WriteLine("</NEWBORNCARE_LIST>");

							streamWriter.WriteLine("<NUTRITRION_LIST>");
                            streamWriter.Write(z35);
                            streamWriter.WriteLine("</NUTRITRION_LIST>");

							streamWriter.WriteLine("<POSTNATAL_LIST>");
							streamWriter.Write(z36);
							streamWriter.WriteLine("</POSTNATAL_LIST>");

							streamWriter.WriteLine("<PRENATAL_LIST>");
							streamWriter.Write(z37);
							streamWriter.WriteLine("</PRENATAL_LIST>");

							streamWriter.WriteLine("<PROCEDURE_IPD_LIST>");
							streamWriter.Write(z38);
							streamWriter.WriteLine("</PROCEDURE_IPD_LIST>");

							streamWriter.WriteLine("<PROCEDURE_OPD_LIST>");
							streamWriter.Write(z39);
							streamWriter.WriteLine("</PROCEDURE_OPD_LIST>");

							streamWriter.WriteLine("<PROCEDURE_REFER_LIST>");
							streamWriter.Write(z40);
							streamWriter.WriteLine("</PROCEDURE_REFER_LIST>");

							streamWriter.WriteLine("<PROVIDER_LIST>");
							streamWriter.Write(z41);
							streamWriter.WriteLine("</PROVIDER_LIST>");

							streamWriter.WriteLine("<REFER_HISTORY_LIST>");
							streamWriter.Write(z42);
							streamWriter.WriteLine("</REFER_HISTORY_LIST>");

							streamWriter.WriteLine("<REFER_RESULT_LIST>");
							streamWriter.Write(z43);
							streamWriter.WriteLine("</REFER_RESULT_LIST>");

							streamWriter.WriteLine("<REHABILITATION_LIST>");
							streamWriter.Write(z44);
							streamWriter.WriteLine("</REHABILITATION_LIST>");

							streamWriter.WriteLine("<SERVICE_LIST>");
							streamWriter.Write(z45);
							streamWriter.WriteLine("</SERVICE_LIST>");

							streamWriter.WriteLine("<SPECIALPP_LIST>");
							streamWriter.Write(z46);
							streamWriter.WriteLine("</SPECIALPP_LIST>");

							streamWriter.WriteLine("<SURVEILLANCE_LIST>");
							streamWriter.Write(z47);
							streamWriter.WriteLine("</SURVEILLANCE_LIST>");

							streamWriter.WriteLine("<VILLAGE_LIST>");
							streamWriter.Write(z48);
							streamWriter.WriteLine("</VILLAGE_LIST>");

							streamWriter.WriteLine("<WOMEN_LIST>");
                            streamWriter.Write(z49);
                            streamWriter.WriteLine("</WOMEN_LIST>");
                            //streamWriter.WriteLine(z50);


                            streamWriter.WriteLine("</SECTION_LIST>");
                            streamWriter.WriteLine("</SIGN_INFO>");
                            streamWriter.WriteLine("</SIGN_LIST>");
                            streamWriter.WriteLine("</PHR_INFO>");

                            Console.WriteLine("Saving XML files Success...");
                            Console.WriteLine("");
                            Console.WriteLine("");

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

        private Encoding Skip(int v)
        {
            throw new NotImplementedException();
        }
    }
}
