using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IntelReportingSystem.DB_Handle;
using IntelReportingSystem.Menu;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionSTR = "server=localhost;" +
            "user=root;" +
            "database=intel_reporting_system;" +
            "port=3306;";
        
        CRUD_Functions DB = new CRUD_Functions(connectionSTR);
        //Console.WriteLine(DB.CreateColumn("People", "user_name", "VARCHAR(50)",true));
        //Console.WriteLine(DB.CreateColumn("People", "code_name", "VARCHAR(50) UNIQUE NOT NULL PRIMARY KEY"));
        //Console.WriteLine(DB.CreateColumn("People", "ID", "INT(255) UNIQUE AUTO_INCREMENT"));
        //Console.WriteLine(DB.CreateColumn("People", "Person_ID", "INT(255) UNIQUE"));

        //Console.WriteLine(DB.CreateColumn("IntelReport", "ID", "INT(255) UNIQUE AUTO_INCREMENT PRIMARY KEY", true));
        //Console.WriteLine(DB.CreateColumn("IntelReport", "reporter_code_name", "VARCHAR(50) UNIQUE NOT NULL"));
        //Console.WriteLine(DB.CreateColumn("IntelReport", "target_code_name", "VARCHAR(50) UNIQUE NOT NULL"));
        //Console.WriteLine(DB.CreateColumn("IntelReport", "text", "VARCHAR(255) NOT NULL"));
        //Console.WriteLine(DB.CreateColumn("IntelReport", "date", "TIMESTAMP NOT NULL"));

        MenuManager.Run();
    }
}