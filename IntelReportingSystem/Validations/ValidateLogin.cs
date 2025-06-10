using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using IntelReportingSystem.DB_Handle;

namespace IntelReportingSystem.Validations
{
    public static class ValidateLogin
    {
        static string connectionSTR = "server=localhost;" +
            "user=root;" +
            "database=intel_reporting_system;" +
            "port=3306;";

        public static bool IfReporterExist(string code_name)
        {
            CRUD_Functions DB = new CRUD_Functions(connectionSTR);
            List<Dictionary<string, object>> SelectedTable = DB.ReadFromTable("People", "code_name", $"code_name = '{code_name}'");

            if (SelectedTable.Count > 0) { return true; } 
            return false;
        }

        public static bool IfCodeNameExist(string code_name)
        {
            CRUD_Functions DB = new CRUD_Functions(connectionSTR);
            List<Dictionary<string, object>> SelectedTable = DB.ReadFromTable("People", "code_name", $"code_name = '{code_name}'");

            if (SelectedTable.Count > 0) return true;
            return false;
        }

    }
}
