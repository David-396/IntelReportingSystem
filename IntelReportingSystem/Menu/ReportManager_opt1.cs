using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelReportingSystem.DB_Handle;

namespace IntelReportingSystem.Menu
{
    internal class ReportManager_opt1
    {

        static string connectionSTR = "server=localhost;" +
                                        "user=root;" +
                                        "database=intel_reporting_system;" +
                                        "port=3306;";

        static CRUD_Functions DB_connection = new CRUD_Functions(connectionSTR);

        static Login_SignIn Current_reporter;
        static bool Exit;


        public static void Report() { }


        static void EnterReportManager_opt1()
        {
            PrintEnterTargetCodeName();
            string targetCodeName = Console.ReadLine();


            PrintEnterReportText();
            string reportText = Console.ReadLine();

            string[] keys = { "reporter_code_name", "target_code_name", "text" };
            object[] values = { Current_reporter.CURRENT_codeName, targetCodeName, reportText };

            if (DB_connection.InsertRecord("intelreport", keys, values))
            {
                Console.WriteLine("\nthe report has reported\n");
                int valueToUpdate = Convert.ToInt32(DB_connection.ReadFromTable("People", "Reports_number", $"code_name='{Current_reporter.CURRENT_codeName}'")[0]["Reports_number"]);
                DB_connection.UpdateColumn("People", Current_reporter.CURRENT_codeName, "Reports_number", valueToUpdate + 1);
            }
            else
            {
                Console.WriteLine("\nreport failed\n");
            }
        }

        public static void IfCodeNameKnown(string codeName)
        {
            if(codeName == null || codeName.Length == 0)
            {
                PrintEnterTargetID();
                string targetID = GetTargetID();

                PrintEnterTargetName();
                string targetName = Console.ReadLine();

                //if()
            }
        }


        public static void PrintEnterTargetCodeName()
        {
            Console.WriteLine("enter the target code name. press enter if you don't know ");
        }
        public static void PrintEnterReportText()
        {
            Console.WriteLine("enter the report body: ");
        }
        public static void PrintEnterTargetID()
        {
            Console.WriteLine("enter the target ID: ");
        }
        public static void PrintEnterTargetName()
        {
            Console.WriteLine("enter the target name: ");
        }

        public static string GetTargetID()
        {
            string id;
            do
            {
                Console.WriteLine("enter numbers only. ");
                id = Console.ReadLine();
            } while (!int.TryParse(id, out _));
            return id;
        }
    }
}
