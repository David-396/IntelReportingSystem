using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.X.XDevAPI.Common;

namespace IntelReportingSystem.DB_Handle
{
    internal class CRUD_Functions
    {
        private string ConnectionString;

        // constructor to get the connection string to connect the DB
        public CRUD_Functions(string connection_string)
        {
            ConnectionString = connection_string;
        }



        // create a new column (and table if needed)
        public bool CreateColumn(string tableName, string columnName, string Column_Types, bool ifCreateTable = false)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                try
                {
                    conn.Open();
                    string query = string.Empty;
                    if (ifCreateTable)
                    {
                        query = $"CREATE TABLE IF NOT EXISTS {tableName} ({columnName} {Column_Types});";
                    }
                    else
                    {
                        query = $"ALTER TABLE {tableName} ADD {columnName} {Column_Types};";

                    }
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            
        }


        // SELECT */specific FROM TABLE
        public List<Dictionary<string, object>>  ReadFromTable(string tableName, string selectedThing = "*", string condition = "1")
        {
            List<Dictionary<string, object>> tableStr = new List<Dictionary<string, object>>();
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                try
                {
                    conn.Open();
                    string query = $"SELECT {selectedThing} FROM `{tableName}` WHERE {condition};";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //cmd.Parameters.AddWithValue("@condition", condition);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    string[] SelectedColumn = selectedThing.Split(',');
                    int i = 0;
                    while (reader.Read())
                    {
                        tableStr.Add(new Dictionary<string, object>());
                        foreach (string column in SelectedColumn)
                        {
                            tableStr[i].Add(column, reader[column]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return tableStr;
        }

        // update a table
        public bool UpdateColumn(string tableName, int id, string column, object value)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                try
                {
                    conn.Open();

                    string query = $"UPDATE `{tableName}` SET `{column}` = @value WHERE ID = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@value", column);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
        }

        // insert record
        public bool InsertRecord(string tableName, Dictionary<string, object> obj)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                try
                {
                    conn.Open();
                    string columns = string.Join(", ", obj.Keys);
                    string paramNames = string.Join(", ", obj.Keys.Select(k => "@" + k));

                    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({paramNames})";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    foreach (var pair in obj)
                    {
                        cmd.Parameters.AddWithValue("@" + pair.Key, pair.Value);
                    }
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("wrong input. check your details again");
                    return false;
                }
        }

        // delete record
        public bool DeleteRecordByID(string tableName, int id)
        {
            
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                try
                {
                    string query = $"DELETE FROM `{tableName}` WHERE `ID` = @id;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
        }





        // extract string from list to string
        public string ExtractFromList(List<string> lst)
        {
            string extractedLST = string.Empty;
            foreach (string str in lst)
            {
                extractedLST += str + " ";
            }
            return extractedLST;
        }

    }
}
