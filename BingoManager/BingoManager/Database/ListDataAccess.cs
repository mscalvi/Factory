using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;

namespace BingoManager.Database
{
    public class ListDataAccess
    {
        public static bool SaveList(string name, string description)
        {
        
            string connectionString = @"Data Source=C:\WorkPlace\RhysticStudy\C#\BingoManager\BingoManager\Database\BingoManagement.db";

            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();

                // Insert the list details into the Lists table
                string query = "INSERT INTO ListsTable (Name, Description) VALUES (@Name, @Description);";

                using (SqliteCommand cmd = new SqliteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);

                    if( cmd.ExecuteNonQuery() > 0)
                    {
                        con.Close();
                        return true;
                    }
                    else
                    {
                        con.Close();
                        return false; 
                    }
                }
            }
        }

        public static DataTable ShowAllLists()
        {
            string connectionString = @"Data Source=C:\WorkPlace\RhysticStudy\C#\BingoManager\BingoManager\Database\BingoManagement.db";
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();

                string query = "SELECT Name FROM ListsTable ORDER BY Name";
                using (SqliteCommand cmd = new SqliteCommand(query, con))
                {
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        return dt;
                    }
                }
            }
        }

        public static DataTable ShowListContent()
        {
            string connectionString = @"Data Source=C:\WorkPlace\RhysticStudy\C#\BingoManager\BingoManager\Banco\BingoManagement.db";
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();

                string query = "SELECT Name FROM ListsTable ORDER BY Name";
                using (SqliteCommand cmd = new SqliteCommand(query, con))
                {
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        return dt;
                    }
                }
            }
        }
    }
}