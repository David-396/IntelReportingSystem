using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IntelReportingSystem.DB_Handle;
using IntelReportingSystem.Enums;

namespace IntelReportingSystem.Annalize
{
    public static class AnnalizeIntel
    {
        static string connectionSTR = "server=localhost;" +
            "user=root;" +
            "database=intel_reporting_system;" +
            "port=3306;";

        static CRUD_Functions DB = new CRUD_Functions(connectionSTR);


        public static void ShowDangerousTargetsManager()
        {
            List<Dictionary<string, object>> DangerTargets = DB.FlexibleCommand("`People`.`code_name`, COUNT(`IntelReport`.`target_code_name`) ",
                                                                                "People",
                                                                                "JOIN IntelReport",
                                                                                "ON `IntelReport`.`target_code_name` = `People`.`code_name`",
                                                                                "WHERE `People`.`Type` = 'Target' GROUP BY `People`.`code_name`   HAVING COUNT(`IntelReport`.`target_code_name`) >= 0;");
            if (DangerTargets == null || DangerTargets.Count == 0)
            {
                Console.WriteLine("\nNo dangerous targets found.\n");
                return;
            }


            for (int i=0; i<DangerTargets.Count; i++)
            {
                Console.WriteLine($"Target: {DangerTargets[i]["People.code_name"]} is DANGEROUS ({DangerTargets[i]["COUNT(Report.target_code_name)"]} reports)");
            }
        }



        public static void ShowPotentialRecruitsManager()
        {
            List<Dictionary<string, object>> potentialRecruitments = DB.ReadFromTable("People", "user_name, code_name, Person_ID, Reports_number", "Reports_number >= 10");
            
            if(potentialRecruitments == null || potentialRecruitments.Count == 0)
            {
                Console.WriteLine("\nno potential recruitments\n");
                return;
            }

            Console.WriteLine("\nthe potential recruitments: ");
            foreach(Dictionary<string, object> person in potentialRecruitments)
            {
                Console.WriteLine($"name : {person["user_name"]} , code name : {person["code_name"]} , ID : {person["ID"]} , number of reports : {person["Reports_number"]}");
            }
        }


    }
}
