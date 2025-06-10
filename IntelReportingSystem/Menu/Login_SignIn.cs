using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelReportingSystem.Validations;
using IntelReportingSystem.DB_Handle;

namespace IntelReportingSystem.Menu
{
    public class Login_SignIn
    {
        public string CURRENT_userName;
        public string CURRENT_codeName;

        static string connectionSTR = "server=localhost;" +
            "user=root;" +
            "database=intel_reporting_system;" +
            "port=3306;";

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(this.CURRENT_userName) && string.IsNullOrEmpty(this.CURRENT_codeName);
        }

        // login
        static void PrintEnter_userName()
        {
            Console.WriteLine("enter your user name: ");
        }
        static void PrintEnter_codeName()
        {
            Console.WriteLine("enter your code name: ");
        }
        static void PrintEnter_personId()
        {
            Console.WriteLine("enter your ID: ");
        }


        public static Login_SignIn LogInManager()
        {
            PrintEnter_codeName();
            string code_name = Console.ReadLine();

            if(ValidateLogin.IfReporterExist( code_name))
            {
                Login_SignIn current_person = new Login_SignIn { CURRENT_codeName = code_name };
                return current_person;
            }
            return null;
        }



        // sign in
        public static Login_SignIn SignInManager()
        {
            PrintEnter_userName();
            string user_name = Console.ReadLine();
            PrintEnter_personId();
            string ID = Console.ReadLine();
            int Person_ID; 
            while (!int.TryParse(ID, out Person_ID))
            {
                Console.WriteLine("enter only numbers! ");
                ID = Console.ReadLine();
            }

            string code_name = Generate.GenerateCodeName();
            while (ValidateLogin.IfCodeNameExist(code_name))
            {
                code_name = Generate.GenerateCodeName();
            }

            Console.WriteLine($"your code name is {code_name}. save it for your next entry");
            CRUD_Functions connection = new CRUD_Functions(connectionSTR);

            Dictionary<string, object> parameters = new Dictionary<string, object> { { "user_name", user_name }, { "code_name", code_name }, { "Person_ID", Person_ID } };
            if (connection.InsertRecord("People", parameters))
            {
                Login_SignIn current_person = new Login_SignIn { CURRENT_codeName = code_name, CURRENT_userName = user_name };
                return current_person;
            }
            return null;
        }
    }
}
