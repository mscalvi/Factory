using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SQLite;
using System.ComponentModel.Design;

namespace BingoCreator.Services
{
    public static class DataService
    {
        private static readonly string _connectionString;

        // Conexão
        // Método principal de conexão
        static DataService()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string databaseFolder = Path.Combine(baseDir, "Database");

                Directory.CreateDirectory(databaseFolder);

                string databasePath = Path.Combine(databaseFolder, "BingoManager.db");
                _connectionString = $"Data Source={databasePath};Version=3;";

                InitializeDatabase();
            }
            catch (Exception ex)
            {
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
            CREATE TABLE IF NOT EXISTS ElementsTable (
                Id INTEGER PRIMARY KEY NOT NULL UNIQUE,
                Name TEXT NOT NULL,
                CardName TEXT NOT NULL,
                Note1 TEXT,
                Note2 TEXT,
                ImageName TEXT,
                AddTime TEXT NOT NULL
            );",

            @"
            CREATE TABLE IF NOT EXISTS ListsTable (
                Id INTEGER PRIMARY KEY,
                Name TEXT,
                Description TEXT,
                ImageName TEXT
            );",

            @"
            CREATE TABLE IF NOT EXISTS AlocationTable (
                ElementId INTEGER REFERENCES ElementsTable(Id),
                ListId INTEGER REFERENCES ListsTable(Id),
                PRIMARY KEY (ElementId, ListId)
            );",

            @"
            CREATE TABLE IF NOT EXISTS CardsSetsTable (
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
            CREATE TABLE IF NOT EXISTS CardsListTable (
                Id INTEGER PRIMARY KEY,
                SetId INTEGER NOT NULL REFERENCES CardsSetsTable(SetId),
                ListId INTEGER NOT NULL REFERENCES ListsTable(Id),
                CardNumber INTEGER NOT NULL,
                EleB1 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleB2 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleB3 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleB4 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleB5 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleI1 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleI2 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleI3 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleI4 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleI5 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleN1 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleN2 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleN3 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleN4 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleN5 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleG1 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleG2 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleG3 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleG4 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleG5 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleO1 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleO2 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleO3 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleO4 INTEGER NOT NULL REFERENCES ElementsTable(Id),
                EleO5 INTEGER NOT NULL REFERENCES ElementsTable(Id)
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


        // Criação
        // Criar Elemento
        public static int CreateElement(string name, string cardName, string note1, string note2, string imageName, string addTime)
        {
            int elementId;

            using (var connection = GetConnection())
            {
                connection.Open();
                string insertQuery = @"
            INSERT INTO ElementsTable (Name, CardName, Note1, Note2, ImageName, AddTime)
            VALUES (@Name, @CardName, @Note1, @Note2, @ImageName, @AddTime);
            SELECT last_insert_rowid();";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@CardName", cardName);
                    command.Parameters.AddWithValue("@Note1", note1);
                    command.Parameters.AddWithValue("@Note2", note2);
                    command.Parameters.AddWithValue("@ImageName", imageName);
                    command.Parameters.AddWithValue("@AddTime", addTime);

                    elementId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return elementId;
        }

        // Criar Lista
        public static int CreateList(string name, string description, string imagename)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string insertQuery = @"
            INSERT INTO ListsTable (Name, Description, ImageName)
            VALUES (@Name, @Description, @ImageName);
            SELECT last_insert_rowid();";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@ImageName", imagename);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        // Criar Conjunto de Cartelas
        public static int CreateCardList(int listId, string name, string title, string end, int quantity, int cardsSize, string groupB, string groupI, string groupN, string groupG, string groupO, string addTime)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // Query para inserir uma nova linha na tabela CardsSetsTable
                string insertQuery = "INSERT INTO CardsSetsTable (ListId, Name, Title, End, Quantity, CardsSize, GroupB, GroupI, GroupN, GroupG, GroupO, AddTime) VALUES (@ListId, @Name, @Title, @End, @Quantity, @GroupB, @GroupI, @GroupN, @GroupG, @GroupO, @AddTime)";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ListId", listId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@End", end);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@CardsSize", cardsSize);
                    command.Parameters.AddWithValue("@GroupB", groupB);
                    command.Parameters.AddWithValue("@GroupI", groupI);
                    command.Parameters.AddWithValue("@GroupN", groupN);
                    command.Parameters.AddWithValue("@GroupG", groupG);
                    command.Parameters.AddWithValue("@GroupO", groupO);
                    command.Parameters.AddWithValue("@AddTime", addTime);

                    command.ExecuteNonQuery();
                }

                // Recupera o último SetId inserido
                using (var command = new SQLiteCommand("SELECT last_insert_rowid();", connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        // Criar Cartelas
        public static void CreateCard(int listId, List<int> elementsIds, int cardNumber, int setId)
        {
            string query = @"INSERT INTO CardsListTable 
                     (ListId, SetId, CardNumber, EleB1, EleB2, EleB3, EleB4, EleB5,
                      EleI1, EleI2, EleI3, EleI4, EleI5,
                      EleN1, EleN2, EleN3, EleN4, EleN5,
                      EleG1, EleG2, EleG3, EleG4, EleG5,
                      EleO1, EleO2, EleO3, EleO4, EleO5) 
                     VALUES 
                     (@ListId, @SetId, @CardNumber, @EleB1, @EleB2, @EleB3, @EleB4, @EleB5,
                      @EleI1, @EleI2, @EleI3, @EleI4, @EleI5,
                      @EleN1, @EleN2, @EleN3, @EleN4, @EleN5,
                      @EleG1, @EleG2, @EleG3, @EleG4, @EleG5,
                      @EleO1, @EleO2, @EleO3, @EleO4, @EleO5)";

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ListId", listId);
                    command.Parameters.AddWithValue("@SetId", setId);
                    command.Parameters.AddWithValue("@CardNumber", cardNumber);

                    for (int i = 0; i < 5; i++)
                    {
                        command.Parameters.AddWithValue($"@EleB{i + 1}", elementsIds[i]);
                        command.Parameters.AddWithValue($"@EleI{i + 1}", elementsIds[i + 5]);
                        command.Parameters.AddWithValue($"@EleN{i + 1}", elementsIds[i + 10]);
                        command.Parameters.AddWithValue($"@EleG{i + 1}", elementsIds[i + 15]);
                        command.Parameters.AddWithValue($"@EleO{i + 1}", elementsIds[i + 20]);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        // Inserir Elementos em uma Lista
        public static void AlocateElements(int listId, List<int> elementsIds)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                foreach (int elementId in elementsIds)
                {
                    string insertQuery = "INSERT INTO AlocationTable (ListId, ElementId) VALUES (@ListId, @ElementId)";

                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ListId", listId);
                        command.Parameters.AddWithValue("@ElementId", elementId);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        // Métodos de Busca
        // Encontrar Elemento pelo ID
        public static DataRow GetElementById(int elementId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM ElementsTable WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", elementId);

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable elementsTable = new DataTable();
                        adapter.Fill(elementsTable);

                        if (elementsTable.Rows.Count > 0)
                        {
                            return elementsTable.Rows[0];
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        // Método para retornar o ID de um Elemento pelo CardName
        public static int GetElementByCardName(string cardName)
        {
            using var connection = GetConnection();
            connection.Open();

            string query = "SELECT Id FROM ElementsTable WHERE CardName = @CardName LIMIT 1";
            using var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@CardName", cardName);

            object result = command.ExecuteScalar();
            if (result != null && int.TryParse(result.ToString(), out int id))
            {
                return id;
            }

            return 0;
        }

        // Conferir se um Elemento já existe em uma Lista
        public static bool ElementExist(string cardName, string listName)
        {
            // Conferir se já existe um elemento em uma lista com o mesmo cardName
            throw new NotImplementedException();
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
        
        // Método para retornar todos os Elementos de uma Lista
        public static List<DataRow> GetElementsInList(int listId)
        {
            List<DataRow> elementsList = new List<DataRow>();

            string query = "SELECT c.Id, c.Name, c.CardName, c.ImageName " +
                           "FROM ElementsTable c " +
                           "INNER JOIN AlocationTable a ON c.Id = a.ElementId " +
                           "WHERE a.ListId = @ListId";

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ListId", listId);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable elementsTable = new DataTable();
                        adapter.Fill(elementsTable);

                        elementsList = elementsTable.AsEnumerable().ToList();
                    }
                }
            }

            return elementsList;
        }


        // Métodos de Edição
        // Método para atualizar um Elemento existente
        public static void UpdateElement(int id, string name, string cardName, string note1, string note2, string imageName, string addTime)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string updateQuery = @"
                    UPDATE ElementsTable 
                    SET Name = @Name, CardName = @CardName, Note1 = @Note1, Note2 = @Note2, ImageName = @ImageName, AddTime = @AddTime 
                    WHERE Id = @Id;";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@CardName", cardName);
                    command.Parameters.AddWithValue("@Note1", note1);
                    command.Parameters.AddWithValue("@Note2", note2);
                    command.Parameters.AddWithValue("@ImageName", imageName);
                    command.Parameters.AddWithValue("@AddTime", addTime);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para remover Elementos de uma Lista
        public static void UnalocateElements(int listId, List<string> elementsIds)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                foreach (string elementId in elementsIds)
                {
                    string deleteQuery = "DELETE FROM AlocationTable WHERE ListId = @ListId AND ElementId = @ElementId";

                    using (var command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ListId", listId);
                        command.Parameters.AddWithValue("@ElementId", elementId);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
