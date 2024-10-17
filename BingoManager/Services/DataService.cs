﻿using System;
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
                // Obtém o caminho da pasta AppData do usuário e cria uma subpasta para seu app
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string databaseFolder = Path.Combine(appDataPath, "BingoManager", "Database");

                // Se a pasta não existir, ela será criada
                if (!Directory.Exists(databaseFolder))
                {
                    Directory.CreateDirectory(databaseFolder);
                }

                // Define o caminho completo para o banco de dados
                string databasePath = Path.Combine(databaseFolder, "CustomBingoDB.db");

                // Inicializa a string de conexão com o caminho do banco de dados
                _connectionString = $"Data Source={databasePath};Version=3;";

                InitializeDatabase();
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
                using (var command = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    command.ExecuteNonQuery();
                }
                // Lista de comandos SQL para criar as tabelas
                var createTableCommands = new List<string>
        {
            @"
            CREATE TABLE IF NOT EXISTS CompanyTable (
                Id INTEGER PRIMARY KEY NOT NULL UNIQUE,
                Name TEXT NOT NULL,
                CardName TEXT NOT NULL,
                Email TEXT,
                Phone TEXT,
                Logo TEXT NOT NULL,
                AddTime TEXT NOT NULL
            );",

            @"
            CREATE TABLE IF NOT EXISTS ListsTable (
                Id INTEGER PRIMARY KEY,
                Name TEXT,
                Description TEXT
            );",

            @"
            CREATE TABLE IF NOT EXISTS AlocacaoTable (
                CompanyID INTEGER REFERENCES CompanyTable(Id),
                ListId INTEGER REFERENCES ListsTable(Id),
                PRIMARY KEY (CompanyID, ListId)
            );",

            @"
            CREATE TABLE IF NOT EXISTS CardsSets (
                SetId INTEGER PRIMARY KEY NOT NULL UNIQUE,
                ListId INTEGER REFERENCES ListsTable(Id),
                Title TEXT NOT NULL,
                End TEXT,
                Qnt INTEGER NOT NULL,
                Name TEXT UNIQUE,
                GroupB TEXT,
                GroupI TEXT,
                GroupN TEXT,
                GroupG TEXT,
                GroupO TEXT
            );",

            @"
            CREATE TABLE IF NOT EXISTS CardsList (
                Id INTEGER PRIMARY KEY,
                SetId INTEGER NOT NULL REFERENCES CardsSets(SetId),
                ListId INTEGER NOT NULL REFERENCES ListsTable(Id),
                CardNumber INTEGER NOT NULL,
                CompB1 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompB2 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompB3 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompB4 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompB5 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompI1 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompI2 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompI3 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompI4 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompI5 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompN1 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompN2 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompN3 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompN4 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompN5 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompG1 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompG2 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompG3 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompG4 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompG5 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompO1 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompO2 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompO3 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompO4 INTEGER NOT NULL REFERENCES CompanyTable(Id),
                CompO5 INTEGER NOT NULL REFERENCES CompanyTable(Id)
            );"
        };

                // Executa cada comando para criar as tabelas
                foreach (var commandText in createTableCommands)
                {
                    using (var command = new SQLiteCommand(commandText, connection))
                    {
                        command.ExecuteNonQuery();
                    }
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

        //Método para retornar uma única empresa pelo Id
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

        //Método para retornar uma única empresa pelo Nome
        public static DataRow GetCompanyByName(string companyName)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM CompanyTable WHERE Name = @Name";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", companyName);

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

        //Método para retornar todas as listas que uma empresa pertence
        public static List<string> GetCompanyLists(int companyId)
        {
            List<string> lists = new List<string>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string selectQuery = @"
            SELECT l.Name 
            FROM AlocacaoTable a
            JOIN ListsTable l ON a.ListId = l.Id
            WHERE a.CompanyID = @CompanyId;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", companyId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lists.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            return lists;
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
        public static void CreateCard(int listId, List<int> companyIds, int cardNumber, int setId)
        {
            string query = @"INSERT INTO CardsList 
                     (ListId, SetId, CardNumber, CompB1, CompB2, CompB3, CompB4, CompB5,
                      CompI1, CompI2, CompI3, CompI4, CompI5,
                      CompN1, CompN2, CompN3, CompN4, CompN5,
                      CompG1, CompG2, CompG3, CompG4, CompG5,
                      CompO1, CompO2, CompO3, CompO4, CompO5) 
                     VALUES 
                     (@ListId, @SetId, @CardNumber, @CompB1, @CompB2, @CompB3, @CompB4, @CompB5,
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
                    command.Parameters.AddWithValue("@ListId", listId);
                    command.Parameters.AddWithValue("@SetId", setId);
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
        public static int CreateCardList(int listId, int qnt, string end, string title, string name, string groupB, string groupI, string groupN, string groupG, string groupO)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // Query para inserir uma nova linha na tabela CardsSets
                string insertQuery = "INSERT INTO CardsSets (ListId, Qnt, End, Title, Name, GroupB, GroupI, GroupN, GroupG, GroupO) VALUES (@ListId, @Qnt, @End, @Title, @Name, @GroupB, @GroupI, @GroupN, @GroupG, @GroupO)";

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

                // Recupera o último SetId inserido
                using (var command = new SQLiteCommand("SELECT last_insert_rowid();", connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
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
                        // 1. Encontrar todos os conjuntos de cartelas associados à lista na CardsSets
                        string findCardSetsQuery = "SELECT SetId FROM CardsSets WHERE ListId = @ListId";
                        List<int> cardSetIds = new List<int>();

                        using (var command = new SQLiteCommand(findCardSetsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ListId", listId);
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int cardSetId = reader.GetInt32(0); // Adiciona o Id do card à lista de conjuntos de cartelas
                                    cardSetIds.Add(cardSetId); // Adiciona o ID à lista
                                }
                            }
                        }

                        // 2. Apagar todas as cartelas associadas na CardsListTable usando os SetIds encontrados
                        if (cardSetIds.Count > 0)
                        {
                            string deleteCardsQuery = "DELETE FROM CardsList WHERE SetId IN (" + string.Join(",", cardSetIds) + ")";
                            using (var command = new SQLiteCommand(deleteCardsQuery, connection))
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("Cartelas associadas foram excluídas da CardsList.");
                            }

                            // 3. Apagar os próprios conjuntos de cartelas na CardsSets usando os SetIds encontrados
                            string deleteCardSetsQuery = "DELETE FROM CardsSets WHERE SetId IN (" + string.Join(",", cardSetIds) + ")";
                            using (var command = new SQLiteCommand(deleteCardSetsQuery, connection))
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("Conjuntos de cartelas foram excluídos da CardsSets.");
                            }
                        }

                        // 3. Apagar as associações da lista na AlocacaoTable
                        string deleteFromAllocationQuery = "DELETE FROM AlocacaoTable WHERE ListId = @ListId";
                        using (var command = new SQLiteCommand(deleteFromAllocationQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ListId", listId);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Alocações Excluídas.");
                        }

                        // 4. Apagar a própria lista da ListsTable
                        string deleteListQuery = "DELETE FROM ListsTable WHERE Id = @ListId";
                        using (var command = new SQLiteCommand(deleteListQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ListId", listId);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Lista excluída.");
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
                string query = "SELECT SetId, Name FROM CardsSets"; // Ajuste os campos conforme necessário

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
        
        //Método para selecionar as empresas de um jogo
        public static GameData GetGameCompanies(int gameId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT GroupB, GroupI, GroupN, GroupG, GroupO FROM CardsSets WHERE SetId = @GameId";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@GameId", gameId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string groupBIds = reader["GroupB"].ToString();
                            string groupIIds = reader["GroupI"].ToString();
                            string groupNIds = reader["GroupN"].ToString();
                            string groupGIds = reader["GroupG"].ToString();
                            string groupOIds = reader["GroupO"].ToString();

                            var groupB = GetCompaniesInfoGame(groupBIds);
                            var groupI = GetCompaniesInfoGame(groupIIds);
                            var groupN = GetCompaniesInfoGame(groupNIds);
                            var groupG = GetCompaniesInfoGame(groupGIds);
                            var groupO = GetCompaniesInfoGame(groupOIds);

                            return new GameData
                            {
                                GroupB = groupB,
                                GroupI = groupI,
                                GroupN = groupN,
                                GroupG = groupG,
                                GroupO = groupO
                            };
                        }
                    }
                }
            }

            return null;
        }

        //Método para buscar as informações das empresas de um jogo
        public static List<CompanyModel> GetCompaniesInfoGame(string companyIds)
        {
            List<CompanyModel> companies = new List<CompanyModel>();

            if (string.IsNullOrWhiteSpace(companyIds))
            {
                return companies; // Retorna lista vazia se não houver IDs
            }

            // Separa os IDs e faz uma consulta mantendo a ordem
            var ids = companyIds.Split(',').Select(id => id.Trim()).ToList();
            string query = $"SELECT Id, Name, CardName, Logo FROM CompanyTable WHERE Id IN ({string.Join(",", ids)})";

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        // Cria um dicionário para mapear as IDs à suas informações
                        var companyDictionary = new Dictionary<int, CompanyModel>();

                        while (reader.Read())
                        {
                            CompanyModel company = new CompanyModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                CardName = reader["CardName"].ToString(),
                                Logo = reader["Logo"].ToString()
                            };

                            // Adiciona ao dicionário
                            companyDictionary[company.Id] = company;
                        }

                        // Monta a lista na ordem original dos IDs
                        companies = ids.Select(id => companyDictionary[int.Parse(id)]).ToList();
                    }
                }
            }

            return companies;
        }

        // Método para verificar quais cartelas têm uma empresa em um jogo específico
        public static List<(int CardId, int CardNum)> GetCardsByCompanyId(int companyId, int setId)
        {
            List<(int CardId, int CardNum)> cards = new List<(int, int)>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = @"
            SELECT Id, CardNumber 
            FROM CardsList 
            WHERE 
                (CompB1 = @CompanyId OR CompB2 = @CompanyId OR CompB3 = @CompanyId OR CompB4 = @CompanyId OR CompB5 = @CompanyId OR
                 CompI1 = @CompanyId OR CompI2 = @CompanyId OR CompI3 = @CompanyId OR CompI4 = @CompanyId OR CompI5 = @CompanyId OR
                 CompN1 = @CompanyId OR CompN2 = @CompanyId OR CompN3 = @CompanyId OR CompN4 = @CompanyId OR CompN5 = @CompanyId OR
                 CompG1 = @CompanyId OR CompG2 = @CompanyId OR CompG3 = @CompanyId OR CompG4 = @CompanyId OR CompG5 = @CompanyId OR
                 CompO1 = @CompanyId OR CompO2 = @CompanyId OR CompO3 = @CompanyId OR CompO4 = @CompanyId OR CompO5 = @CompanyId)
                AND SetId = @SetId"; 

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", companyId);
                    command.Parameters.AddWithValue("@SetId", setId); 

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int cardId = reader.GetInt32(0); 
                            int cardNum = reader.GetInt32(1); 
                            cards.Add((cardId, cardNum));
                        }
                    }
                }
            }

            return cards;
        }

        // Método para retornar todas as empresas de uma Cartela
        public static CardModel GetCardDetails(int cardNum, int setId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string selectQuery = @"
            SELECT Id, CardNumber, 
                   CompB1, CompB2, CompB3, CompB4, CompB5,
                   CompI1, CompI2, CompI3, CompI4, CompI5,
                   CompN1, CompN2, CompN3, CompN4, CompN5,
                   CompG1, CompG2, CompG3, CompG4, CompG5,
                   CompO1, CompO2, CompO3, CompO4, CompO5
            FROM CardsList 
            WHERE CardNumber = @CardNum AND SetId = @SetId";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@CardNum", cardNum);
                    command.Parameters.AddWithValue("@SetId", setId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Ler os dados da cartela
                            int cardId = reader.GetInt32(0);
                            int cardNumber = reader.GetInt32(1);

                            // Inicializa listas para as empresas
                            var bCompanies = new List<int>();
                            var iCompanies = new List<int>();
                            var nCompanies = new List<int>();
                            var gCompanies = new List<int>();
                            var oCompanies = new List<int>();

                            // Lê as empresas da coluna B
                            for (int i = 2; i <= 6; i++)
                            {
                                bCompanies.Add(reader.GetInt32(i)); // CompB1 a CompB5
                            }

                            // Lê as empresas da coluna I
                            for (int i = 7; i <= 11; i++)
                            {
                                iCompanies.Add(reader.GetInt32(i)); // CompI1 a CompI5
                            }

                            // Lê as empresas da coluna N
                            for (int i = 12; i <= 16; i++)
                            {
                                nCompanies.Add(reader.GetInt32(i)); // CompN1 a CompN5
                            }

                            // Lê as empresas da coluna G
                            for (int i = 17; i <= 21; i++)
                            {
                                gCompanies.Add(reader.GetInt32(i)); // CompG1 a CompG5
                            }

                            // Lê as empresas da coluna O
                            for (int i = 22; i <= 26; i++)
                            {
                                oCompanies.Add(reader.GetInt32(i)); // CompO1 a CompO5
                            }

                            // Monta a lista de empresas por linha
                            var companies1 = new List<int> { bCompanies[0], iCompanies[0], nCompanies[0], gCompanies[0], oCompanies[0] };
                            var companies2 = new List<int> { bCompanies[1], iCompanies[1], nCompanies[1], gCompanies[1], oCompanies[1] };
                            var companies3 = new List<int> { bCompanies[2], iCompanies[2], nCompanies[2], gCompanies[2], oCompanies[2] };
                            var companies4 = new List<int> { bCompanies[3], iCompanies[3], nCompanies[3], gCompanies[3], oCompanies[3] };
                            var companies5 = new List<int> { bCompanies[4], iCompanies[4], nCompanies[4], gCompanies[4], oCompanies[4] };

                            return new CardModel
                            {
                                CardId = cardId,
                                CardNumber = cardNumber,
                                AllCompanies = bCompanies.Concat(iCompanies).Concat(nCompanies).Concat(gCompanies).Concat(oCompanies).ToList(),
                                BCompanies = bCompanies,
                                ICompanies = iCompanies,
                                NCompanies = nCompanies,
                                GCompanies = gCompanies,
                                OCompanies = oCompanies,
                                Companies1 = companies1,
                                Companies2 = companies2,
                                Companies3 = companies3,
                                Companies4 = companies4,
                                Companies5 = companies5
                            };
                        }
                    }
                }
            }

            return null;
        }

    }
}
