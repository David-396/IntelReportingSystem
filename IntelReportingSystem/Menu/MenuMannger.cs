using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelReportingSystem.Validations;
using IntelReportingSystem.DB_Handle;
using IntelReportingSystem.Annalize;

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
                    while (!Exit)
                    {
                        OptionsMannager();
                    }
                }
            }
        }



        //logIn / signIn phase
        static bool ReporterEnterToSystem()
        {
            PrintLogin_SignIn();
            string opt = GetOption_from3();
            if (SwitchCaseLogin(opt))
            {
                return true;
            }
            else
            {
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
        static void PrintConnectionSuccess()
        {
            Console.WriteLine("\nconnection success\n");
        }
        static void PrintConnectionFailed()
        {
            Console.WriteLine("\nconnection failed\n");
        }

        
        static bool SwitchCaseLogin(string opt)
        {
            switch (opt)
            {
                case "1":
                    Current_reporter = Login_SignIn.LogInManager();
                    if (Current_reporter == null)
                    {
                        PrintConnectionFailed();
                        return false;
                    }
                    PrintConnectionSuccess();
                    return true;
                case "2":
                    Current_reporter = Login_SignIn.SignInManager();
                    if (Current_reporter == null)
                    {
                        PrintConnectionFailed();
                        return false;
                    }
                    PrintConnectionSuccess();
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


        // option 2 - upload a csv file
        static void UploadCSVFileManager_opt2() { }



        // option 5 - show all the potential recruitments
        static void ShowAllAlertsManager_opt5() { }


        static void SwitchCaseOption(string opt)
        {
            switch (opt)
            {
                case "1":
                    ReportManager_opt1.Report();
                    break;
                case "2":
                    UploadCSVFileManager_opt2();
                    break;
                case "3":
                    AnnalizeIntel.ShowPotentialRecruitsManager();
                    break;
                case "4":
                    AnnalizeIntel.ShowDangerousTargetsManager();
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
