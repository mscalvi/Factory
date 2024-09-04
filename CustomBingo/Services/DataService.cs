using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Data.SQLite;


namespace CustomBingo.Services
{
    public static class DataService
    {
        private static readonly string _connectionString;

        // Construtor que define a string de conexão com o banco de dados
        static DataService()
        {
            try
            {
                /*
                // Obtém o caminho da pasta AppData do usuário e cria uma subpasta para seu app
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string databaseFolder = Path.Combine(appDataPath, "CustomBingo");

                // Se a pasta não existir, ela será criada
                if (!Directory.Exists(databaseFolder))
                {
                    Directory.CreateDirectory(databaseFolder);
                }

                // Define o caminho completo para o banco de dados
                string databasePath = Path.Combine(databaseFolder, "CustomBingoDB.db");

                // Inicializa a string de conexão com o caminho do banco de dados
                _connectionString = $"Data Source={databasePath};Version=3;"; */
                string connectionString = @"Data Source=C:\Users\Marcelo Scalvi\Desktop\Factory\CustomBingo\Database\CustomBingoDB.db";
                _connectionString = connectionString;

            }
            catch (Exception ex)
            {
                // Trate qualquer erro que possa ocorrer durante a criação da pasta ou definição do caminho
                Console.WriteLine($"Erro ao inicializar o banco de dados: {ex.Message}");
                throw;
            }
        }

        // Método para abrir uma conexão com o banco de dados
        private static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        // Método para inicializar o banco de dados (criar as tabelas se não existirem)
        public static void InitializeDatabase()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string createTablesQuery = @"
                    CREATE TABLE IF NOT EXISTS CompanyTable (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        CardName TEXT NOT NULL,
                        Email TEXT,
                        Phone TEXT,
                        Logo TEXT,
                        AddTime TEXT
                    );
                    CREATE TABLE IF NOT EXISTS ListsTable (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Description TEXT
                    );
                    CREATE TABLE IF NOT EXISTS AlocacaoTable (
                        CompanyID INTEGER REFERENCES CompanyTable(Id),
                        ListId INTEGER REFERENCES ListsTable(Id),
                        PRIMARY KEY (CompanyID, ListId)
                    );
                ";

                using (var command = new SQLiteCommand(createTablesQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para inserir uma nova empresa
        public static void AddCompany(string name, string cardName, string email, string phone, string logo, string addTime)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string insertQuery = @"
                    INSERT INTO CompanyTable (Name, CardName, Email, Phone, Logo, AddTime)
                    VALUES (@Name, @CardName, @Email, @Phone, @Logo, @AddTime);";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@CardName", cardName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Logo", logo);
                    command.Parameters.AddWithValue("@AddTime", addTime);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para inserir uma nova lista
        public static void AddList(string name, string description)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string insertQuery = @"
                    INSERT INTO ListsTable (Name, Description)
                    VALUES (@Name, @Description);";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Description", description);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para retornar todas as empresas
        public static DataTable GetCompanies()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string selectQuery = "SELECT * FROM CompanyTable;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        // Método para atualizar uma empresa existente
        public static void UpdateCompany(int id, string name, string cardName, string email, string phone, string logo, string addTime)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string updateQuery = @"
                    UPDATE CompanyTable 
                    SET Name = @Name, CardName = @CardName, Email = @Email, Phone = @Phone, Logo = @Logo, AddTime = @AddTime 
                    WHERE Id = @Id;";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@CardName", cardName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Logo", logo);
                    command.Parameters.AddWithValue("@AddTime", addTime);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para deletar uma empresa pelo ID
        public static void DeleteCompany(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string deleteQuery = "DELETE FROM CompanyTable WHERE Id = @Id;";

                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        //Método para Ler Endereço das Imagens
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
