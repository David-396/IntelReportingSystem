using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelReportingSystem.Validations;
using IntelReportingSystem.DB_Handle;

namespace IntelReportingSystem.Menu
{
    internal class MenuManager
    {
        static string connectionSTR = "server=localhost;" +
                                        "user=root;" +
                                        "database=intel_reporting_system;" +
                                        "port=3306;";

        static CRUD_Functions DB_connection = new CRUD_Functions(connectionSTR);

        static Login_SignIn Current_reporter;

        static bool Exit = false;



        static void ExitOpt()
        {
            Console.WriteLine("BYE!");
            Exit = true;
        }

        public static void Run()
        {
            while (!Exit)
            {
                if (ReporterEnterToSystem())
                {
                    OptionsMannager();
                }
            }
        }



        //login / signIn phase
        static bool ReporterEnterToSystem()
        {
            PrintLogin_SignIn();
            string opt = GetOption_from3();
            if (SwitchCaseLogin(opt))
            {
                Console.WriteLine("\nconnection success\n");
                return true;
            }
            else
            {
                Console.WriteLine("\nconnection failed.\n");
                return false;
            }
        }

        static void PrintLogin_SignIn()
        {
            Console.WriteLine("Hello!\n" +
                "enter the option:\n" +
                "\t1. Login\n" +
                "\t2. Sign In\n" +
                "3. EXIT\n");
        }
        static string GetOption_from3()
        {
            string opt = Console.ReadLine();
            while (!ValidateInput.Validate("1", "2", "3", opt))
            {
                Console.WriteLine("wrong input. enter only the option number");
                opt = Console.ReadLine();
            }
            return opt;
        }

        
        static bool SwitchCaseLogin(string opt)
        {
            switch (opt)
            {
                case "1":
                    Current_reporter = Login_SignIn.LogInManager();
                    if(Current_reporter == null) return false;
                    return true;
                case "2":
                    Current_reporter = Login_SignIn.SignInManager();
                    if (Current_reporter == null) return false;
                    return true;
                case "3":
                    ExitOpt();
                    return false;
                default:
                    return false;
            }
        }



        // options in the system
        static void OptionsMannager()
        {
            PrintSystemOptions();
            string opt = GetOption_from6();
            SwitchCaseOption(opt);
        }

        static string GetOption_from6()
        {
            string opt = Console.ReadLine();
            while (!ValidateInput.Validate("1", "2", "3", "4", "5", "6", opt))
            {
                Console.WriteLine("wrong input. enter only the option number");
                opt = Console.ReadLine();
            }
            return opt;
        }
        static void PrintSystemOptions()
        {
            Console.WriteLine("choose option:\n" +
                "\t1. Report\n" +
                "\t2. Upload CSV File\n" +
                "\t3. Show Potential Recruits\n" +
                "\t4. Show Dangerous Targets\n" +
                "\t5. Show All Alerts\n" +
                "6. EXIT");
        }

        static void EnterReportManager_opt1()
        {
            PrintEnterTargetCodeName();
            string targetCodeName = GetTargetCodeName();
            PrintEnterReportText();
            string reportText = GetReportBody();
            if(DB_connection.InsertRecord("intelreport", new Dictionary<string, object> { {"reporter_codename", Current_reporter.CURRENT_codeName},
                                                                                       {"target_codename", targetCodeName },
                                                                                       {"text", reportText },
                                                                                       {"date", DateTime.Now } }))
            {
                Console.WriteLine("the report has reported");
            }
            Console.WriteLine("the has not reported");

        }

        public static void PrintEnterTargetCodeName()
        {
            Console.WriteLine("enter the target code name: ");
        }
        public static string GetTargetCodeName()
        {
            string codeNameTarget = Console.ReadLine();
            return codeNameTarget;
        }
        public static void PrintEnterReportText()
        {
            Console.WriteLine("enter the report body: ");
        }
        public static string GetReportBody()
        {
            string reportBody = Console.ReadLine();
            return reportBody;
        }


        static void UploadCSVFileManager_opt2() { }
        static void ShowPotentialRecruitsManager_opt3() { }
        static void ShowDangerousTargetsManager_opt4() { }
        static void ShowAllAlertsManager_opt5() { }


        static void SwitchCaseOption(string opt)
        {
            switch (opt)
            {
                case "1":
                    EnterReportManager_opt1();
                    break;
                case "2":
                    UploadCSVFileManager_opt2();
                    break;
                case "3":
                    ShowPotentialRecruitsManager_opt3();
                    break;
                case "4":
                    ShowDangerousTargetsManager_opt4();
                    break;
                case "5":
                    ShowAllAlertsManager_opt5();
                    break;
                case "6":
                    ExitOpt();
                    break;
            }
        }
    }
}
