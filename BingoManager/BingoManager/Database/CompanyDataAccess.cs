using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace BingoManager.Database

{
    public class CompanyDataAccess
    {
        public static bool SaveCompany(string name, string cardname, string email, string phonenumber, string logo)
        {

            string connectionString = @"Data Source=C:\WorkPlace\RhysticStudy\C#\BingoManager\BingoManager\Database\BingoManagement.db";

            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();

                // Insert the list details into the Lists table
                string query = "INSERT INTO CompanyTable (Name, CardName, Email, PhoneNumber, Logo) VALUES (@Name, @CardName, @Email, @PhoneNumber, @Logo);";

                using (SqliteCommand cmd = new SqliteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@CardName", cardname ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phonenumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Logo", logo ?? (object)DBNull.Value);

                    if (cmd.ExecuteNonQuery() > 0)
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

        public static DataTable ShowAllCompany()
        {
            string connectionString = @"Data Source=C:\WorkPlace\RhysticStudy\C#\BingoManager\BingoManager\Database\BingoManagement.db";
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();

                string query = "SELECT Name, CardName, Logo FROM CompanyTable ORDER BY Name, CardName";
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

        private static Image LoadImageFromFile(string fileName)
        {
            string directoryPath = Application.StartupPath + @"\Images\";
            string filePath = Path.Combine(directoryPath, fileName);

            if (File.Exists(filePath))
            {
                return Image.FromFile(filePath);
            }
            return null;
        }
    }
}