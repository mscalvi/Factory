using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Data.SQLite;
using System.ComponentModel.Design;
using BingoManager.Models;

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
                string databaseFolder = Path.Combine(appDataPath, "Database");

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
                    CREATE TABLE IF NOT EXISTS AllCards (
                        Id INTEGER PRIMARY KEY NOT NULL UNIQUE,
                        ListId INTEGER REFERENCES ListsTable (Id),
                        Title TEXT NOT NULL,
                        End TEXT,
                        Qnt INTEGER NOT NULL,
                        Name TEXT UNIQUE
                    );
                    CREATE TABLE CardsList (
                        Id         INTEGER PRIMARY KEY,
                        CardList   INTEGER REFERENCES ListsTable (Id) 
                                           NOT NULL,
                        CardNumber INTEGER NOT NULL,
                        CompB1     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompB2     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompB3     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompB4     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompB5     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompI1     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompI2     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompI3     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompI4     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompI5     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompN1     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompN2     INTEGER NOT NULL
                                           REFERENCES CompanyTable (Id),
                        CompN3     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompN4     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompN5     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompG1     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompG2     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompG3     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompG4     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompG5     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompO1     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompO2     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompO3     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompO4     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL,
                        CompO5     INTEGER REFERENCES CompanyTable (Id) 
                                           NOT NULL
                    );
                ";

                using (var command = new SQLiteCommand(createTablesQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para criar uma nova empresa e retornar o ID
        public static int AddCompany(string name, string cardName, string email, string phone, string logo, string addTime)
        {
            int companyId;

            using (var connection = GetConnection())
            {
                connection.Open();
                string insertQuery = @"
            INSERT INTO CompanyTable (Name, CardName, Email, Phone, Logo, AddTime)
            VALUES (@Name, @CardName, @Email, @Phone, @Logo, @AddTime);
            SELECT last_insert_rowid();"; 

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@CardName", cardName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Logo", logo);
                    command.Parameters.AddWithValue("@AddTime", addTime);

                    companyId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return companyId;  
        }

        //Método para conferir se uma empresa já existe
        public static bool CompanyExists(string name, string cardName)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"
            SELECT COUNT(*) FROM CompanyTable 
            WHERE Name = @Name OR CardName = @CardName";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@CardName", cardName);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; // Retorna true se existir, false caso contrário
                }
            }
        }

        // Método para criar uma nova lista
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

        //Método para retornar uma única empresa
        public static DataRow GetCompanyById(int companyId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM CompanyTable WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", companyId);

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable companyTable = new DataTable();
                        adapter.Fill(companyTable);

                        if (companyTable.Rows.Count > 0)
                        {
                            return companyTable.Rows[0];
                        }
                        else
                        {
                            return null;
                        }
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

        // Método para deletar uma empresa e todas as dependências (listas, cartelas, etc.)
        public static void DeleteCompany(int companyId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Encontrar todas as listas que usam a empresa na AlocacaoTable
                        string findListsQuery = @"
                            SELECT DISTINCT ListId
                            FROM AlocacaoTable
                            WHERE CompanyId = @CompanyId";

                        List<int> listIds = new List<int>();
                        using (var command = new SQLiteCommand(findListsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CompanyId", companyId);
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    listIds.Add(reader.GetInt32(0));  // Adiciona o ListId à lista de listas que usam a empresa
                                }
                            }
                        }

                        // 2. Encontrar todos os conjuntos de cartelas associados às listas na AllCards
                        if (listIds.Count > 0)
                        {
                            string findCardSetsQuery = "SELECT DISTINCT Id FROM AllCards WHERE ListId IN (" + string.Join(",", listIds) + ")";
                            List<int> cardSetIds = new List<int>();
                            using (var command = new SQLiteCommand(findCardSetsQuery, connection))
                            {
                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        cardSetIds.Add(reader.GetInt32(0));  // Adiciona o CardId à lista de conjuntos de cartelas
                                    }
                                }
                            }

                            // 3. Apagar todas as cartelas dos conjuntos encontrados e os próprios conjuntos
                            if (cardSetIds.Count > 0)
                            {
                                // Apaga as cartelas na CardsListTable associadas a esses conjuntos de cartelas
                                string deleteCardsQuery = "DELETE FROM CardsList WHERE CardList IN (" + string.Join(",", listIds) + ")";
                                using (var command = new SQLiteCommand(deleteCardsQuery, connection))
                                {
                                    command.ExecuteNonQuery();
                                }

                                // Apaga os próprios conjuntos de cartelas na AllCards
                                string deleteCardSetsQuery = "DELETE FROM AllCards WHERE Id IN (" + string.Join(",", cardSetIds) + ")";
                                using (var command = new SQLiteCommand(deleteCardSetsQuery, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }

                            // 4. Apagar todas as listas que usam a empresa na AlocacaoTable
                            string deleteFromAllocationQuery = "DELETE FROM AlocacaoTable WHERE CompanyId = @CompanyId";
                            using (var command = new SQLiteCommand(deleteFromAllocationQuery, connection))
                            {
                                command.Parameters.AddWithValue("@CompanyId", companyId);
                                command.ExecuteNonQuery();
                            }
                        }

                        // 5. Apagar a empresa da CompanyTable
                        string deleteCompanyQuery = "DELETE FROM CompanyTable WHERE Id = @CompanyId";
                        using (var command = new SQLiteCommand(deleteCompanyQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CompanyId", companyId);
                            command.ExecuteNonQuery();
                        }

                        // Commit da transação se tudo deu certo
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback em caso de erro
                        transaction.Rollback();
                    }
                }
            }
        }

        // Método para ler o endereço das imagens, aceitando caminho absoluto ou relativo
        public static Image LoadImageFromFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return null;

            if (!Path.IsPathRooted(filePath))
            {
                string directoryPath = Path.Combine(Application.StartupPath, "Images");
                filePath = Path.Combine(directoryPath, filePath);
            }

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

        // Método para remover empresas de uma lista
        public static void RemoveCompaniesFromAllocation(int listId, List<string> companyIds)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                foreach (string companyId in companyIds)
                {
                    string deleteQuery = "DELETE FROM AlocacaoTable WHERE ListId = @ListId AND CompanyId = @CompanyId";

                    using (var command = new SQLiteCommand(deleteQuery, connection))
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
        public static void CreateCardList(int listId, int qnt, string end, string title, string name, string groupB, string groupI, string groupN, string groupG, string groupO)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string insertQuery = "INSERT INTO AllCards (ListId, Qnt, End, Title, Name, GroupB, GroupI, GroupN, GroupG, GroupO) VALUES (@ListId, @Qnt, @End, @Title, @Name, @GroupB, @GroupI, @GroupN, @GroupG, @GroupO)";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ListId", listId);
                    command.Parameters.AddWithValue("@Qnt", qnt);
                    command.Parameters.AddWithValue("@End", end);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@GroupB", groupB);
                    command.Parameters.AddWithValue("@GroupI", groupI);
                    command.Parameters.AddWithValue("@GroupN", groupN);
                    command.Parameters.AddWithValue("@GroupG", groupG);
                    command.Parameters.AddWithValue("@GroupO", groupO);

                    command.ExecuteNonQuery();
                }
            }
        }

        //Método para deletar uma lista e todas as dependências
        public static void DeleteList(int listId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Encontrar todos os conjuntos de cartelas associados à lista na AllCards
                        string findCardSetsQuery = "SELECT DISTINCT Id FROM AllCards WHERE ListId = @ListId";
                        List<int> cardSetIds = new List<int>();

                        using (var command = new SQLiteCommand(findCardSetsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ListId", listId);
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cardSetIds.Add(reader.GetInt32(0));  // Adiciona o CardId à lista de conjuntos de cartelas
                                }
                            }
                        }

                        // 2. Apagar todas as cartelas associadas na CardsListTable
                        if (cardSetIds.Count > 0)
                        {
                            string deleteCardsQuery = "DELETE FROM CardsList WHERE CardId IN (" + string.Join(",", cardSetIds) + ")";
                            using (var command = new SQLiteCommand(deleteCardsQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }

                            // 3. Apagar os próprios conjuntos de cartelas na AllCards
                            string deleteCardSetsQuery = "DELETE FROM AllCards WHERE Id IN (" + string.Join(",", cardSetIds) + ")";
                            using (var command = new SQLiteCommand(deleteCardSetsQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }

                        // 4. Apagar as associações da lista na AlocacaoTable
                        string deleteFromAllocationQuery = "DELETE FROM AlocacaoTable WHERE ListId = @ListId";
                        using (var command = new SQLiteCommand(deleteFromAllocationQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ListId", listId);
                            command.ExecuteNonQuery();
                        }

                        // 5. Apagar a própria lista da ListsTable
                        string deleteListQuery = "DELETE FROM ListsTable WHERE Id = @ListId";
                        using (var command = new SQLiteCommand(deleteListQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ListId", listId);
                            command.ExecuteNonQuery();
                        }

                        // Commit da transação se tudo deu certo
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback em caso de erro
                        transaction.Rollback();
                    }
                }
            }
        }

        //Método para selecionar todos os Jogos
        public static DataTable GetAllCards()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT Id, Name FROM AllCards"; // Ajuste os campos conforme necessário

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }

}
