using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelReportingSystem.DB_Handle;
using IntelReportingSystem.Validations;
using IntelReportingSystem.Enums;

namespace IntelReportingSystem.Menu
{
    internal class ReportManager_opt1
    {

        static string connectionSTR = "server=localhost;" +
                                        "user=root;" +
                                        "database=intel_reporting_system;" +
                                        "port=3306;";

        static CRUD_Functions DB_connection = new CRUD_Functions(connectionSTR);
        static string targetCodeName;

        static bool ValidCodeName = false;




        public static void EnterReportManager_opt1(string reporterCodeName)
        {
            PrintEnterTargetCodeName();
            string targetCodeName = Console.ReadLine();
            CheckAndGetCodeName(targetCodeName);
            while (!ValidCodeName)
            {
                PrintEnterTargetCodeName();
                targetCodeName = Console.ReadLine();
                CheckAndGetCodeName(targetCodeName);
            }

            PrintEnterReportText();
            string reportText = Console.ReadLine();

            string[] keys = { "reporter_code_name", "target_code_name", "text" };
            object[] values = { reporterCodeName, targetCodeName, reportText };

            if (DB_connection.InsertRecord("intelreport", keys, values))
            {
                Console.WriteLine("\nthe report has reported\n");
                int valueToUpdate = Convert.ToInt32(DB_connection.ReadFromTable("People", "Reports_number", $"code_name='{targetCodeName}'")[0]["Reports_number"]);
                DB_connection.UpdateColumn("People", targetCodeName, "Reports_number", valueToUpdate + 1);
            }
            else
            {
                Console.WriteLine("\nreport failed\n");
            }
        }

        public static void CheckAndGetCodeName(string codeName)
        {
            if(codeName == null || codeName.Length == 0)
            {
                PrintEnterTargetID();
                string targetID = GetTargetID();

                PrintEnterTargetName();
                string targetName = Console.ReadLine();

                string query = $"SELECT code_name FROM People WHERE person_id = '{targetID}' AND user_name = '{targetID}'";
                List<Dictionary<string, object>> nameIdInDB = DB_connection.FreeQuery("people", query, new string[] { "code_name"});

                if(nameIdInDB == null || nameIdInDB.Count == 0)
                {
                    string new_code_name = Generate.GenerateCodeName();
                    while (ValidateLogin.IfCodeNameExist(new_code_name))
                    {
                        new_code_name = Generate.GenerateCodeName();
                    }

                    string[] keys = { "user_name", "code_name", "ID", "Person_ID", "Type", "Reports_number" };
                    object[] values = { targetName, new_code_name, targetID, PersonType.Target, 0 };
                    
                    ValidCodeName = DB_connection.InsertRecord("People", keys, values);
                    ValidCodeName = true;
                    targetCodeName = new_code_name;
                    return;

                }
                targetCodeName = Convert.ToString(nameIdInDB[0]["code_name"]);
                ValidCodeName = true;
            }


            if (ValidateLogin.IfCodeNameExist(codeName))
            {
                ValidCodeName = true;
                targetCodeName = codeName;
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
