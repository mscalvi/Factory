using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Data.SQLite;
using System.ComponentModel.Design;


namespace BingoManager.Services
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
                string connectionString = @"Data Source=C:\Users\Marcelo Scalvi\Desktop\Factory\BingoManager\Database\CustomBingoDB.db";
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

        // Método para retornar todas as listas
        public static DataTable GetLists()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string selectQuery = "SELECT * FROM ListsTable;";

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

        //Método para inserir empresas em uma lista
        public static void AddCompaniesToAllocation(int listId, List<string> companyIds)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                foreach (string companyId in companyIds)
                {
                    string insertQuery = "INSERT INTO AlocacaoTable (ListId, CompanyId) VALUES (@ListId, @CompanyId)";

                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ListId", listId);
                        command.Parameters.AddWithValue("@CompanyId", companyId);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        //Método para pegar todas as empresas de uma lista
        public static List<DataRow> GetCompaniesByListId(int listId)
        {
            List<DataRow> companyList = new List<DataRow>();

            // Consulta SQL para buscar apenas as colunas necessárias
            string query = "SELECT c.Id, c.Name, c.CardName, c.Logo " +
                           "FROM CompanyTable c " +
                           "INNER JOIN AlocacaoTable a ON c.Id = a.CompanyId " +
                           "WHERE a.ListId = @ListId";

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SQLiteCommand(query, connection))
                {
                    // Adicionando o parâmetro para a lista
                    command.Parameters.AddWithValue("@ListId", listId);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        // Preenche um DataTable com os resultados da consulta
                        DataTable companiesTable = new DataTable();
                        adapter.Fill(companiesTable);

                        // Converte as linhas do DataTable em uma lista de DataRow
                        companyList = companiesTable.AsEnumerable().ToList();
                    }
                }
            }

            return companyList;
        }

        //Método para adicionar cartela a uma lista de cartelas
        public static void CreateCard(int listId, List<int> companyIds, int cardNumber)
        {
            string query = @"INSERT INTO CardsList 
                     (CardList, CardNumber, CompB1, CompB2, CompB3, CompB4, CompB5,
                      CompI1, CompI2, CompI3, CompI4, CompI5,
                      CompN1, CompN2, CompN3, CompN4, CompN5,
                      CompG1, CompG2, CompG3, CompG4, CompG5,
                      CompO1, CompO2, CompO3, CompO4, CompO5) 
                     VALUES 
                     (@CardList, @CardNumber, @CompB1, @CompB2, @CompB3, @CompB4, @CompB5,
                      @CompI1, @CompI2, @CompI3, @CompI4, @CompI5,
                      @CompN1, @CompN2, @CompN3, @CompN4, @CompN5,
                      @CompG1, @CompG2, @CompG3, @CompG4, @CompG5,
                      @CompO1, @CompO2, @CompO3, @CompO4, @CompO5)";

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SQLiteCommand(query, connection))
                {
                    // Adiciona o valor da lista
                    command.Parameters.AddWithValue("@CardList", listId);
                    command.Parameters.AddWithValue("@CardNumber", cardNumber);

                    // Associa os parâmetros para as empresas nos diferentes grupos
                    for (int i = 0; i < 5; i++)
                    {
                        command.Parameters.AddWithValue($"@CompB{i + 1}", companyIds[i]);
                        command.Parameters.AddWithValue($"@CompI{i + 1}", companyIds[i + 5]);
                        command.Parameters.AddWithValue($"@CompN{i + 1}", companyIds[i + 10]);
                        command.Parameters.AddWithValue($"@CompG{i + 1}", companyIds[i + 15]);
                        command.Parameters.AddWithValue($"@CompO{i + 1}", companyIds[i + 20]);
                    }

                    // Executa a inserção no banco de dados
                    command.ExecuteNonQuery();
                }
            }
        }

        //Método para adicionar uma lista de cartelas
        public static void CreateCardList(int listId, int center, int qnt, string end, string title)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string insertQuery = "INSERT INTO AllCards (ListId, Center, Qnt, End, Title) VALUES (@ListId, @Center, @Qnt, @End, @Title)";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ListId", listId);
                    command.Parameters.AddWithValue("@Center", center);
                    command.Parameters.AddWithValue("@Qnt", qnt);
                    command.Parameters.AddWithValue("@End", end);
                    command.Parameters.AddWithValue("@Title", title);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
