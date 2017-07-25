using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using CsvToXml;
using System.Threading.Tasks;
using System.Xml;
using System.Threading;

namespace CsvToXml
{
    class Program
    {

        static void Main(string[] args)
        {
            SortCSV sortCsv = new SortCSV();
			ExportXmlH ex1 = new ExportXmlH();
            ExportXMLAll epA = new ExportXMLAll();
            CreatePHRXml crPhr = new CreatePHRXml();
            AddNode addNode = new AddNode();
            CreateChangwat crCw = new CreateChangwat();
            CreatePerson crPer = new CreatePerson();

            Console.WriteLine("");
            Console.WriteLine("###############################################");
            Console.WriteLine("Select 0 for Sorting PHR : ");
			Console.WriteLine("Select 1 for create PHR XML : ");
            Console.WriteLine("Select 2 for create Person in PID : ");
            Console.WriteLine("Select 3 for Add Node in PHR : ");
            string se = Console.ReadLine();
			Console.WriteLine("###############################################");

            if (se.ToString() == "0")
            {
                sortCsv.Sort("person.csv", 2);
                sortCsv.Sort("accident.csv", 1);
                sortCsv.Sort("address.csv", 1);
                sortCsv.Sort("nutrition.csv", 1);
                sortCsv.Sort("admission.csv", 1);
                sortCsv.Sort("community_service.csv", 1);
                sortCsv.Sort("labor.csv", 1);
                sortCsv.Sort("diagnosis_ipd.csv", 1);
                sortCsv.Sort("charge_ipd.csv", 1);
                sortCsv.Sort("drugallergy.csv", 1);
                sortCsv.Sort("dental.csv", 1);
                sortCsv.Sort("diagnosis_opd.csv", 1);
                sortCsv.Sort("drug_opd.csv", 1);
                sortCsv.Sort("epi.csv", 1);
                sortCsv.Sort("functional.csv", 1);
                sortCsv.Sort("ncdscreen.csv", 1);
                sortCsv.Sort("fp.csv", 1);
                sortCsv.Sort("surveillance.csv", 1);
                sortCsv.Sort("labfu.csv", 1);
                sortCsv.Sort("newborn.csv", 1);
                sortCsv.Sort("death.csv", 1);
                sortCsv.Sort("newborncare.csv", 1);
                sortCsv.Sort("postnatal.csv", 1);
                sortCsv.Sort("anc.csv", 1);
                sortCsv.Sort("prenatal.csv", 1);
                sortCsv.Sort("charge_opd.csv", 1);
                sortCsv.Sort("chronic.csv", 1);
                sortCsv.Sort("procedure_ipd.csv", 1);
                sortCsv.Sort("disability.csv", 2);
                sortCsv.Sort("chronicfu.csv", 1);
                sortCsv.Sort("procedure_opd.csv", 1);
                sortCsv.Sort("appointment.csv", 1);
                sortCsv.Sort("rehabilitation.csv", 1);
                sortCsv.Sort("service.csv", 1);
                sortCsv.Sort("drug_ipd.csv", 1);
                sortCsv.Sort("icf.csv", 2);
                sortCsv.Sort("specialpp.csv", 1);
                sortCsv.Sort("card.csv", 1);
                sortCsv.Sort("women.csv", 1);

            }
            else if (se.ToString() == "1")
            {
                crPhr.addPhr();
                //Thread t0 = new Thread(new ThreadStart(Thread0));
                //t0.Start();

                //Thread t2 = new Thread(new ThreadStart(Thread2));
                //t2.Start();

                //Thread t3 = new Thread(new ThreadStart(Thread3));
                //t3.Start();

                //Thread t4 = new Thread(new ThreadStart(Thread4));
                //t4.Start();

                //Thread t5 = new Thread(new ThreadStart(Thread5));
                //t5.Start();

                //            Thread t6 = new Thread(new ThreadStart(Thread6));
                //            t6.Start();

                //Thread t7 = new Thread(new ThreadStart(Thread7));
                //t7.Start();

                //            Thread t8 = new Thread(new ThreadStart(Thread8));
                //            t8.Start();

                //Thread t9 = new Thread(new ThreadStart(Thread9));
                //t9.Start();


            }
            else if (se.ToString() == "2")
            {
				Thread tPer = new Thread(new ThreadStart(ThreadPer));
				tPer.Start();

			}
            else if (se.ToString() == "3")
            {
               
				Thread tAc = new Thread(new ThreadStart(ThreadAc));
				tAc.Start();

				Thread taddress = new Thread(new ThreadStart(Threadaddress));
				taddress.Start();

				Thread tadmission = new Thread(new ThreadStart(Threadadmission));
				tadmission.Start();

				Thread tanc = new Thread(new ThreadStart(Threadanc));
				tanc.Start();

				Thread tappointment = new Thread(new ThreadStart(Threadappointment));
				tappointment.Start();

				Thread tcard = new Thread(new ThreadStart(Threadcard));
				tcard.Start();

				Thread tcharge_ipd = new Thread(new ThreadStart(Threadcharge_ipd));
				tcharge_ipd.Start();

				Thread tcharge_opd = new Thread(new ThreadStart(Threadcharge_opd));
				tcharge_opd.Start();

				Thread tchronic = new Thread(new ThreadStart(Threadchronic));
				tchronic.Start();

				Thread tchronicfu = new Thread(new ThreadStart(Threadchronicfu));
				tchronicfu.Start();

				Thread tcommunity_service = new Thread(new ThreadStart(Threadcommunity_service));
				tcommunity_service.Start();

				Thread tdeath = new Thread(new ThreadStart(Threaddeath));
				tdeath.Start();

				Thread tdental = new Thread(new ThreadStart(Threaddental));
				tdental.Start();

				Thread tdiagnosis_ipd = new Thread(new ThreadStart(Threaddiagnosis_ipd));
				tdiagnosis_ipd.Start();

				Thread tdiagnosis_opd = new Thread(new ThreadStart(Threaddiagnosis_opd));
				tdiagnosis_opd.Start();

				Thread tdisability = new Thread(new ThreadStart(Threaddisability));
				tdisability.Start();

				Thread tdrug_ipd = new Thread(new ThreadStart(Threaddrug_ipd));
				tdrug_ipd.Start();

				Thread tdrug_opd = new Thread(new ThreadStart(Threaddrug_opd));
				tdrug_opd.Start();

				Thread tdrugallergy = new Thread(new ThreadStart(Threaddrugallergy));
				tdrugallergy.Start();

				Thread tepi = new Thread(new ThreadStart(Threadepi));
				tepi.Start();

				Thread tfp = new Thread(new ThreadStart(Threadfp));
				tfp.Start();

				Thread tfunctional = new Thread(new ThreadStart(Threadfunctional));
				tfunctional.Start();

				Thread ticf = new Thread(new ThreadStart(Threadicf));
				ticf.Start();

				Thread tlabfu = new Thread(new ThreadStart(Threadlabfu));
				tlabfu.Start();

				Thread tlabor = new Thread(new ThreadStart(Threadlabor));
				tlabor.Start();

				Thread tncdscreen = new Thread(new ThreadStart(Threadncdscreen));
				tncdscreen.Start();

				Thread tnewborn = new Thread(new ThreadStart(Threadnewborn));
				tnewborn.Start();

				Thread tnewborncare = new Thread(new ThreadStart(Threadnewborncare));
				tnewborncare.Start();

				Thread tnutrition = new Thread(new ThreadStart(Threadnutrition));
				tnutrition.Start();

				Thread tpostnatal = new Thread(new ThreadStart(Threadpostnatal));
				tpostnatal.Start();

				Thread tprenatal = new Thread(new ThreadStart(Threadprenatal));
				tprenatal.Start();

				Thread tprocedure_ipd = new Thread(new ThreadStart(Threadprocedure_ipd));
				tprocedure_ipd.Start();

				Thread tprocedure_opd = new Thread(new ThreadStart(Threadprocedure_opd));
				tprocedure_opd.Start();

				Thread tprovider = new Thread(new ThreadStart(Threadprovider));
				tprovider.Start();

				Thread trehabilitation = new Thread(new ThreadStart(Threadrehabilitation));
				trehabilitation.Start();

				Thread tservice = new Thread(new ThreadStart(Threadservice));
				tservice.Start();

				Thread tspecialpp = new Thread(new ThreadStart(Threadspecialpp));
				tspecialpp.Start();

				Thread tsurveillance = new Thread(new ThreadStart(Threadsurveillance));
				tsurveillance.Start();

				Thread twomen = new Thread(new ThreadStart(Threadwomen));
				twomen.Start();
			}
            else
            {
                Console.WriteLine("Select Fail!");
            }
           
			
        }
		public static void Thread0()
		{
			CreatePHRXml crPhr = new CreatePHRXml();
			crPhr.addPhr();
			//Thread.Sleep(0);
            Console.WriteLine("Thread 0 Success");
		}

		public static void ThreadPer()
		{
			AddNode addNode = new AddNode();
			addNode.addNodePerson();
			//Thread.Sleep(0);
		}
		public static void ThreadAc()
        {
			AddNode addNode = new AddNode();
            addNode.addNodeAccident();
            //Thread.Sleep(0);
        }
		public static void Threadaddress()
		{
			AddNode addNode = new AddNode();
            addNode.addNodeAddress();
            //Thread.Sleep(10);
		}
		public static void Threadadmission()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeAdmission();
            //Thread.Sleep(20);
		}
		public static void Threadanc()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeAnc();
            //Thread.Sleep(30);
		}
		public static void Threadappointment()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeAppointment();
            //Thread.Sleep(40);
		}
		public static void Threadcard()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeCard();
            //Thread.Sleep(50);
		}
		public static void Threadcharge_ipd()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeCharge_ipd();
           // Thread.Sleep(60);
		}
		public static void Threadcharge_opd()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeCharge_opd();
            //Thread.Sleep(70);
		}
		public static void Threadchronic()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeChronic();
            //Thread.Sleep(80);
		}
		public static void Threadchronicfu()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeChronicfu();
            //Thread.Sleep(90);
		}
		public static void Threadcommunity_service()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeCommunity_service();
            //Thread.Sleep(100);
		}
		public static void Threaddeath()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeDeath();
            //Thread.Sleep(110);
		}
		public static void Threaddental()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeDental();
			//Thread.Sleep(120);
		}
		public static void Threaddiagnosis_ipd()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeDiagnosis_ipd();
			//Thread.Sleep(130);
		}
		public static void Threaddiagnosis_opd()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeDiagnosis_opd();
			//Thread.Sleep(140);
		}
		public static void Threaddisability()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeDisability();
			//Thread.Sleep(150);
		}
		public static void Threaddrug_ipd()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeDrug_ipd();
			//Thread.Sleep(160);
		}
		public static void Threaddrug_opd()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeDrug_opd();
			//Thread.Sleep(170);
		}
		public static void Threaddrugallergy()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeDrugallergy();
			//Thread.Sleep(180);
		}
		public static void Threadepi()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeEpi();
			//Thread.Sleep(190);
		}
		public static void Threadfp()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeFp();
			//Thread.Sleep(200);
		}
		public static void Threadfunctional()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeFunctional();
            //Thread.Sleep(210);
		}
		public static void Threadicf()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeIcf();
            //Thread.Sleep(220);
		}
		public static void Threadlabfu()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeLabfu();
            //Thread.Sleep(230);
		}
		public static void Threadlabor()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeLabor();
            //Thread.Sleep(240);
		}
		public static void Threadncdscreen()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeNcdscreen();
            //Thread.Sleep(250);
		}
		public static void Threadnewborn()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeNewborn();
            //Thread.Sleep(260);
		}
		public static void Threadnewborncare()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeNewborncare();
            //Thread.Sleep(270);
		}
		public static void Threadnutrition()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeNutrition();
            //Thread.Sleep(280);
		}
		public static void Threadpostnatal()
		{
			AddNode addNode = new AddNode();
			addNode.addNodePostnatal();
            //Thread.Sleep(290);
		}
		public static void Threadprenatal()
		{
			AddNode addNode = new AddNode();
			addNode.addNodePrenatal();
           // Thread.Sleep(300);
		}
		public static void Threadprocedure_ipd()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeProcedure_ipd();
            //Thread.Sleep(310);
		}
		public static void Threadprocedure_opd()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeProcedure_opd();
            //Thread.Sleep(320);
		}
		public static void Threadprovider()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeProvider();
            //Thread.Sleep(330);
		}
		public static void Threadrehabilitation()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeRehabilitation();
            //Thread.Sleep(340);
		}
		public static void Threadservice()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeService();
            //Thread.Sleep(350);
		}
		public static void Threadspecialpp()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeSpecialpp();
            //Thread.Sleep(360);
		}
		public static void Threadsurveillance()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeSurveillance();
            //Thread.Sleep(370);
		}
		public static void Threadwomen()
		{
			AddNode addNode = new AddNode();
			addNode.addNodeWomen();
            //Thread.Sleep(380);
		}
		

	}

}
