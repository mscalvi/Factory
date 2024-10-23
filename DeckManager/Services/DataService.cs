using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.VisualBasic.Logging;
using System.Xml.Linq;
using DeckManager.Models;
using System.Security.AccessControl;
using DeckManager.Enums;

namespace DeckManager.Services
{
    public static class DataService
    {
        private static readonly string _connectionString;

        static DataService()
        {
            try
            {
                // Obtém o caminho da pasta AppData do usuário e cria uma subpasta para seu app
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string databaseFolder = Path.Combine(appDataPath, "DeckManager", "Database");

                // Se a pasta não existir, ela será criada
                if (!Directory.Exists(databaseFolder))
                {
                    Directory.CreateDirectory(databaseFolder);
                }

                // Define o caminho completo para o banco de dados
                string databasePath = Path.Combine(databaseFolder, "DeckManagerDB.db");

                // Inicializa a string de conexão com o caminho do banco de dados
                _connectionString = $"Data Source={databasePath};Version=3;";

                // Verifica se o banco de dados já existe
                if (!File.Exists(databasePath))
                {
                    InitializeDatabase(); // Cria o banco de dados apenas se não existir
                }
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
            CREATE TABLE IF NOT EXISTS CategoryTable (
                CatId INTEGER PRIMARY KEY NOT NULL UNIQUE,
                Name TEXT NOT NULL
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

        //Filters
        public static List<FormatModel> GetFormats()
        {
            var categories = new List<FormatModel>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT FormatId, Name FROM FormatsTable;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Lê os dados da consulta
                    while (reader.Read())
                    {
                        var category = new FormatModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1) 
                        };

                        categories.Add(category);
                    }
                }
            }

            return categories;
        }
        public static string GetFormatName(int formatId)
        {
            string formatName = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT Name FROM FormatsTable WHERE FormatId = @formatId;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@formatId", formatId);

                    using (var reader = command.ExecuteReader())
                    {
                        // Verifica se há um resultado
                        if (reader.Read())
                        {
                            formatName = reader.GetString(0);
                        }
                    }
                }
            }

            return formatName;
        }
        public static List<OwnerModel> GetOwners()
        {
            var owners = new List<OwnerModel>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT OwnerId, Name FROM OwnersTable;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Lê os dados da consulta
                    while (reader.Read())
                    {
                        var owner = new OwnerModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };

                        owners.Add(owner);
                    }
                }
            }

            return owners;
        }
        public static string GetOwnerName(int ownerId)
        {
            string ownerName = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT Name FROM OwnersTable WHERE OwnerId = @ownerId;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ownerId", ownerId);

                    using (var reader = command.ExecuteReader())
                    {
                        // Verifica se há um resultado
                        if (reader.Read())
                        {
                            ownerName = reader.GetString(0);
                        }
                    }
                }
            }

            return ownerName;
        }
        public static List<ArchetypeModel> GetArchetypes()
        {
            var archetypes = new List<ArchetypeModel>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT ArchetypeId, Name FROM ArchetypesTable;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Lê os dados da consulta
                    while (reader.Read())
                    {
                        var archetype = new ArchetypeModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };

                        archetypes.Add(archetype);
                    }
                }
            }

            return archetypes;
        }
        public static string GetArchetypeName(int archetypeId)
        {
            string archetypeName = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT Name FROM ArchetypesTable WHERE ArchetypeId = @archetypeId;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@archetypeId", archetypeId);

                    using (var reader = command.ExecuteReader())
                    {
                        // Verifica se há um resultado
                        if (reader.Read())
                        {
                            archetypeName = reader.GetString(0);
                        }
                    }
                }
            }

            return archetypeName;
        }
        public static List<ColorModel> GetColors()
        {
            var colors = new List<ColorModel>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT ColorId, Name FROM ColorsTable;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Lê os dados da consulta
                    while (reader.Read())
                    {
                        var color = new ColorModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };

                        colors.Add(color);
                    }
                }
            }

            return colors;
        }
        public static string GetColorName(int colorId)
        {
            string colorName = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT Name FROM ColorsTable WHERE ColorId = @colorId;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@colorId", colorId);

                    using (var reader = command.ExecuteReader())
                    {
                        // Verifica se há um resultado
                        if (reader.Read())
                        {
                            colorName = reader.GetString(0);
                        }
                    }
                }
            }

            return colorName;
        }
        public static void CreateFilter(string name, FilterType filterType)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertQuery = string.Empty;

                        // Determine a tabela e a coluna com base no tipo de filtro
                        switch (filterType)
                        {
                            case FilterType.Format:
                                insertQuery = "INSERT INTO FormatsTable (Name) VALUES (@Name);";
                                break;
                            case FilterType.Owner:
                                insertQuery = "INSERT INTO OwnersTable (Name) VALUES (@Name);";
                                break;
                            case FilterType.Archetype:
                                insertQuery = "INSERT INTO ArchetypesTable (Name) VALUES (@Name);";
                                break;
                            case FilterType.Color:
                                insertQuery = "INSERT INTO ColorsTable (Name) VALUES (@Name);";
                                break;
                            default:
                                throw new ArgumentException("Tipo de filtro inválido.");
                        }

                        using (var command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Name", name);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao criar o filtro: " + ex.Message);
                    }
                }
            }
        }
        public static void DeleteFilter(string name, FilterType filterType)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteQuery = string.Empty;

                        // Determine a tabela com base no tipo de filtro
                        switch (filterType)
                        {
                            case FilterType.Format:
                                deleteQuery = "DELETE FROM FormatsTable WHERE Name = @Name;";
                                break;
                            case FilterType.Owner:
                                deleteQuery = "DELETE FROM OwnersTable WHERE Name = @Name;";
                                break;
                            case FilterType.Archetype:
                                deleteQuery = "DELETE FROM ArchetypesTable WHERE Name = @Name;";
                                break;
                            case FilterType.Color:
                                deleteQuery = "DELETE FROM ColorsTable WHERE Name = @Name;";
                                break;
                            default:
                                throw new ArgumentException("Tipo de filtro inválido.");
                        }

                        using (var command = new SQLiteCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Name", name);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao deletar o filtro: " + ex.Message);
                    }
                }
            }
        }



        //Decks
        public static void NewDeck(string deckName, int formatId)
        {
            if (string.IsNullOrWhiteSpace(deckName))
            {
                throw new ArgumentException("O nome do deck não pode estar vazio.");
            }

            if (formatId <= 0) // Verifica se o formato é válido (por exemplo, maior que zero)
            {
                throw new ArgumentException("Um formato válido deve ser selecionado.");
            }

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Verifica se já existe um deck com o mesmo nome
                        string checkDeckNameQuery = "SELECT COUNT(*) FROM DecksTable WHERE Name = @Name";
                        using (var checkCommand = new SQLiteCommand(checkDeckNameQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Name", deckName);
                            long count = (long)checkCommand.ExecuteScalar(); // Verifica a quantidade de decks com o nome

                            if (count > 0) // Se já existe um deck com o mesmo nome
                            {
                                // Cancela a operação e avisa o usuário
                                throw new ArgumentException("Já existe um deck com esse nome.");
                            }
                        }

                        // Se o nome for único, insere o novo deck
                        string insertDeckQuery = "INSERT INTO DecksTable (Name, FormatId) VALUES (@Name, @FormatId);";
                        using (var deckCommand = new SQLiteCommand(insertDeckQuery, connection))
                        {
                            deckCommand.Parameters.AddWithValue("@Name", deckName);
                            deckCommand.Parameters.AddWithValue("@FormatId", formatId);
                            deckCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (ArgumentException ex) // Exceção para nome duplicado ou formato inválido
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        transaction.Rollback(); // Cancela a transação
                    }
                    catch (Exception ex) // Outras exceções
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao criar o deck: " + ex.Message);
                    }
                }
            }
        }
        public static List<DeckModel> GetAllDecks()
        {
            var decks = new List<DeckModel>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT * FROM DecksTable;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Lê os dados da consulta
                    while (reader.Read())
                    {
                        var deck = new DeckModel
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            Format = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            Owner = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            Archetype = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                            Colors = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                        };

                        decks.Add(deck);
                    }
                }
            }

            return decks;
        }
        public static List<DeckModel> GetSomeDecks(int? formatId = null, int? ownerId = null, int? archetypeId = null, int? colorsId = null)
        {
            var decks = new List<DeckModel>();

            using (var connection = GetConnection())
            {
                connection.Open();

                // Começa a construir a query
                var selectQuery = "SELECT DeckId, Name, FormatId, OwnerId, ArchetypeId, ColorsId FROM DecksTable WHERE 1=1";

                // Adiciona condições de filtragem com base nos parâmetros
                if (formatId.HasValue)
                {
                    selectQuery += " AND FormatId = @FormatId";
                }
                if (ownerId.HasValue)
                {
                    selectQuery += " AND OwnerId = @OwnerId"; // Supondo que você tenha uma coluna Owner
                }
                if (archetypeId.HasValue)
                {
                    selectQuery += " AND ArchetypeId = @ArchetypeId"; // Supondo que você tenha uma coluna Archetype
                }
                if (colorsId.HasValue)
                {
                    selectQuery += " AND ColorsId = @ColorsId"; // Supondo que você tenha uma coluna Colors
                }

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    // Adiciona parâmetros apenas se eles forem diferentes de 0
                    if (formatId.HasValue)
                    {
                        command.Parameters.AddWithValue("@FormatId", formatId.Value);
                    }
                    if (ownerId.HasValue)
                    {
                        command.Parameters.AddWithValue("@OwnerId", ownerId.Value);
                    }
                    if (archetypeId.HasValue)
                    {
                        command.Parameters.AddWithValue("@ArchetypeId", archetypeId.Value);
                    }
                    if (colorsId.HasValue)
                    {
                        command.Parameters.AddWithValue("@ColorsId", colorsId.Value);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        // Lê os dados da consulta
                        while (reader.Read())
                        {
                            var deck = new DeckModel
                            {
                                Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                Format = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                                Owner = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                                Archetype = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                Colors = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                            };

                            decks.Add(deck);
                        }
                    }
                }
            }

            return decks;
        }



    }
}
