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
using System.Drawing;

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
        //Decks
        public static DeckModel NewDeck(string deckName, int formatId)
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

                        // Se o nome for único, insere o novo deck com LastVersion = 0
                        string insertDeckQuery = "INSERT INTO DecksTable (Name, FormatId, LastVersion) VALUES (@Name, @FormatId, 0);";
                        using (var deckCommand = new SQLiteCommand(insertDeckQuery, connection))
                        {
                            deckCommand.Parameters.AddWithValue("@Name", deckName);
                            deckCommand.Parameters.AddWithValue("@FormatId", formatId);
                            deckCommand.ExecuteNonQuery();
                        }

                        // Obtém o ID do último deck inserido
                        string getDeckIdQuery = "SELECT last_insert_rowid()";
                        using (var getIdCommand = new SQLiteCommand(getDeckIdQuery, connection))
                        {
                            long newDeckId = (long)getIdCommand.ExecuteScalar();

                            // Cria e retorna o DeckModel com LastVersion = 0
                            DeckModel newDeck = new DeckModel
                            {
                                Id = (int)newDeckId,
                                Name = deckName,
                                Format = formatId,
                                LastVersion = 0
                            };

                            transaction.Commit();
                            return newDeck;
                        }
                    }
                    catch (ArgumentException ex) // Exceção para nome duplicado ou formato inválido
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        transaction.Rollback(); // Cancela a transação
                        return null; // Retorna null em caso de falha
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

                // Primeira consulta para obter os decks
                string selectQuery = @"
            SELECT DeckId, Name, FormatId, OwnerId, ArchetypeId, ColorId, LastVersion 
            FROM DecksTable;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Lê os dados dos decks
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
                            LastVersion = reader.IsDBNull(6) ? 0 : reader.GetInt32(6)
                        };

                        // Busca o VersionName usando LastVersion do deck
                        string versionNameQuery = @"
                    SELECT VersionName 
                    FROM DeckVersionTable 
                    WHERE DeckId = @DeckId AND VersionId = @VersionId;";

                        using (var versionCommand = new SQLiteCommand(versionNameQuery, connection))
                        {
                            versionCommand.Parameters.AddWithValue("@DeckId", deck.Id);
                            versionCommand.Parameters.AddWithValue("@VersionId", deck.LastVersion);

                            // Executa a consulta e atribui o VersionName ao deck
                            var versionName = versionCommand.ExecuteScalar();
                            deck.VersionName = versionName != null ? versionName.ToString() : "N/A"; // Define como "N/A" caso não exista
                        }

                        // Adiciona o deck à lista
                        decks.Add(deck);
                    }
                }
            }

            return decks;
        }
        public static List<DeckModel> GetSomeDecks(int? formatId = null, int? ownerId = null, int? archetypeId = null, int? colorId = null)
        {
            var decks = new List<DeckModel>();

            using (var connection = GetConnection())
            {
                connection.Open();

                // Começa a construir a query
                var selectQuery = "SELECT DeckId, Name, FormatId, OwnerId, ArchetypeId, ColorId, LastVersion FROM DecksTable WHERE 1=1";

                // Adiciona condições de filtragem com base nos parâmetros
                if (formatId.HasValue)
                {
                    selectQuery += " AND FormatId = @FormatId";
                }
                if (ownerId.HasValue)
                {
                    selectQuery += " AND OwnerId = @OwnerId";
                }
                if (archetypeId.HasValue)
                {
                    selectQuery += " AND ArchetypeId = @ArchetypeId";
                }
                if (colorId.HasValue)
                {
                    selectQuery += " AND ColorId = @ColorId";
                }

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    // Adiciona parâmetros apenas se eles forem fornecidos
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
                    if (colorId.HasValue)
                    {
                        command.Parameters.AddWithValue("@ColorId", colorId.Value);
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
                                LastVersion = reader.IsDBNull(6) ? 0 : reader.GetInt32(6)  // Correção no índice
                            };

                            decks.Add(deck);
                        }
                    }
                }
            }

            return decks;
        }



        //Deck View
        public static int SaveDeckVersion(DeckModel deck)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int newVersionNumber = 1; // Inicia como 1, caso não haja versões anteriores

            using (var connection = GetConnection())
            {
                connection.Open();

                // Consulta para obter o número da última versão do deck
                string getLastVersionQuery = @"
        SELECT COALESCE(MAX(DeckVersionNumber), 0) 
        FROM DeckVersionTable 
        WHERE DeckId = @DeckId";

                using (var getLastVersionCommand = new SQLiteCommand(getLastVersionQuery, connection))
                {
                    getLastVersionCommand.Parameters.AddWithValue("@DeckId", deck.Id);
                    newVersionNumber = Convert.ToInt32(getLastVersionCommand.ExecuteScalar()) + 1;
                }

                // Query para inserir a nova versão do deck
                string insertVersionQuery = @"
        INSERT INTO DeckVersionTable 
        (DeckId, VersionName, FormatId, OwnerId, ArchetypeId, ColorId, SaveTime, DeckVersionNumber) 
        VALUES (@DeckId, @VersionName, @FormatId, @OwnerId, @ArchetypeId, @ColorId, @SaveTime, @DeckVersionNumber);";

                using (var command = new SQLiteCommand(insertVersionQuery, connection))
                {
                    command.Parameters.AddWithValue("@DeckId", deck.Id);
                    if (string.IsNullOrEmpty(deck.VersionName))
                    {
                        command.Parameters.AddWithValue("@VersionName", "Versão Inicial");
                    } else
                    {
                        command.Parameters.AddWithValue("@VersionName", deck.VersionName);
                    }
                    command.Parameters.AddWithValue("@FormatId", deck.Format);
                    command.Parameters.AddWithValue("@OwnerId", deck.Owner);
                    command.Parameters.AddWithValue("@ArchetypeId", deck.Archetype);
                    command.Parameters.AddWithValue("@ColorId", deck.Colors);
                    command.Parameters.AddWithValue("@SaveTime", timestamp);
                    command.Parameters.AddWithValue("@DeckVersionNumber", newVersionNumber);

                    command.ExecuteNonQuery();
                }
            }

            // Retorna o número da versão salva
            return newVersionNumber;
        }
        public static void UpdateDeck(DeckModel deck)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string updateDeckQuery = @"
            UPDATE DecksTable 
            SET 
                Name = @Name, 
                FormatId = @FormatId, 
                OwnerId = @OwnerId, 
                ArchetypeId = @ArchetypeId, 
                ColorId = @ColorId,
                LastVersion = @LastVersion
            WHERE DeckId = @DeckId;";

                using (var command = new SQLiteCommand(updateDeckQuery, connection))
                {
                    command.Parameters.AddWithValue("@DeckId", deck.Id);

                    command.Parameters.AddWithValue("@Name",
                        string.IsNullOrWhiteSpace(deck.Name) ? DBNull.Value : deck.Name);

                    command.Parameters.AddWithValue("@FormatId",
                        deck.Format == 0 ? DBNull.Value : deck.Format);

                    command.Parameters.AddWithValue("@OwnerId",
                        deck.Owner == 0 ? DBNull.Value : deck.Owner);

                    command.Parameters.AddWithValue("@ArchetypeId",
                        deck.Archetype == 0 ? DBNull.Value : deck.Archetype);

                    command.Parameters.AddWithValue("@ColorId",
                        deck.Colors == 0 ? DBNull.Value : deck.Colors);

                    command.Parameters.AddWithValue("@LastVersion", deck.LastVersion);

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void SaveRelations(DeckModel deck)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (var connection = GetConnection())
            {
                connection.Open();

                // Salvando a lista de funções
                if (deck.FunctionsList != null && deck.FunctionsList.Count > 0)
                {
                    int i = 0;
                    foreach (var function in deck.FunctionsList)
                    {
                        i++;

                        // Query para inserir a relação de funções para o deck
                        string insertFunctionQuery = @"
                            INSERT INTO RelationsTable 
                            (DeckId, VersionId, ListType, Position, ItemName, SaveTime) 
                            VALUES (@DeckId, @VersionId, @ListType, @Position, @ItemName, @SaveTime);";

                        using (var command = new SQLiteCommand(insertFunctionQuery, connection))
                        {
                            command.Parameters.AddWithValue("@DeckId", deck.Id);
                            command.Parameters.AddWithValue("@VersionId", deck.LastVersion);
                            command.Parameters.AddWithValue("@ListType", "Functions");
                            command.Parameters.AddWithValue("@Position", i);
                            command.Parameters.AddWithValue("@ItemName", function);
                            command.Parameters.AddWithValue("@SaveTime", timestamp);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                // Salvando a Deck List Real
                if (deck.RealDeckList != null && deck.RealDeckList.Count > 0)
                {
                    int i = 0;
                    foreach (var card in deck.RealDeckList)
                    {
                        i++;

                        // Query para inserir a relação de funções para o deck
                        string insertFunctionQuery = @"
                            INSERT INTO RelationsTable 
                            (DeckId, VersionId, ListType, Position, ItemName, SaveTime) 
                            VALUES (@DeckId, @VersionId, @ListType, @Position, @ItemName, @SaveTime);";

                        using (var command = new SQLiteCommand(insertFunctionQuery, connection))
                        {
                            command.Parameters.AddWithValue("@DeckId", deck.Id);
                            command.Parameters.AddWithValue("@VersionId", deck.LastVersion);
                            command.Parameters.AddWithValue("@ListType", "Real");
                            command.Parameters.AddWithValue("@Position", i);
                            command.Parameters.AddWithValue("@ItemName", card.Name);
                            command.Parameters.AddWithValue("@SaveTime", timestamp);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                // Salvando a Deck List Ideal
                if (deck.IdealDeckList != null && deck.IdealDeckList.Count > 0)
                {
                    int i = 0;
                    foreach (var card in deck.IdealDeckList)
                    {
                        i++;

                        // Query para inserir a relação de funções para o deck
                        string insertFunctionQuery = @"
                            INSERT INTO RelationsTable 
                            (DeckId, VersionId, ListType, Position, ItemName, SaveTime) 
                            VALUES (@DeckId, @VersionId, @ListType, @Position, @ItemName, @SaveTime);";

                        using (var command = new SQLiteCommand(insertFunctionQuery, connection))
                        {
                            command.Parameters.AddWithValue("@DeckId", deck.Id);
                            command.Parameters.AddWithValue("@VersionId", deck.LastVersion);
                            command.Parameters.AddWithValue("@ListType", "Ideal");
                            command.Parameters.AddWithValue("@Position", i);
                            command.Parameters.AddWithValue("@ItemName", card.Name);
                            command.Parameters.AddWithValue("@SaveTime", timestamp);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public static DeckModel GetDeckByName(string deckName)
        {
            DeckModel deck = null;

            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM DecksTable WHERE Name = @Name";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", deckName);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            deck = new DeckModel
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("DeckId")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            };

                            // Preenche outros campos, caso estejam presentes e não nulos
                            if (!reader.IsDBNull(reader.GetOrdinal("FormatId")))
                                deck.Format = reader.GetInt32(reader.GetOrdinal("FormatId"));

                            if (!reader.IsDBNull(reader.GetOrdinal("OwnerId")))
                                deck.Owner = reader.GetInt32(reader.GetOrdinal("OwnerId"));

                            if (!reader.IsDBNull(reader.GetOrdinal("ArchetypeId")))
                                deck.Archetype = reader.GetInt32(reader.GetOrdinal("ArchetypeId"));

                            if (!reader.IsDBNull(reader.GetOrdinal("ColorId")))
                                deck.Colors = reader.GetInt32(reader.GetOrdinal("ColorId"));

                            if (!reader.IsDBNull(reader.GetOrdinal("LastVersion")))
                                deck.LastVersion = reader.GetInt32(reader.GetOrdinal("LastVersion"));
                        }
                    }
                }
            }

            return deck;
        }
        public static DeckModel GetDeckWithDetails(int deckId)
        {
            DeckModel deck = null;

            using (var connection = GetConnection())
            {
                connection.Open();

                // Primeiro, recupera as informações do deck a partir do DecksTable
                string deckQuery = @"SELECT * FROM DecksTable WHERE DeckId = @DeckId";
                using (var deckCommand = new SQLiteCommand(deckQuery, connection))
                {
                    deckCommand.Parameters.AddWithValue("@DeckId", deckId);

                    using (var reader = deckCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            deck = new DeckModel
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("DeckId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                // Define os outros campos se existirem
                                Format = !reader.IsDBNull(reader.GetOrdinal("FormatId")) ? reader.GetInt32(reader.GetOrdinal("FormatId")) : 0,
                                Owner = !reader.IsDBNull(reader.GetOrdinal("OwnerId")) ? reader.GetInt32(reader.GetOrdinal("OwnerId")) : 0,
                                Archetype = !reader.IsDBNull(reader.GetOrdinal("ArchetypeId")) ? reader.GetInt32(reader.GetOrdinal("ArchetypeId")) : 0,
                                Colors = !reader.IsDBNull(reader.GetOrdinal("ColorId")) ? reader.GetInt32(reader.GetOrdinal("ColorId")) : 0,
                                LastVersion = !reader.IsDBNull(reader.GetOrdinal("LastVersion")) ? reader.GetInt32(reader.GetOrdinal("LastVersion")) : 0
                            };
                        }
                    }
                }

                if (deck == null)
                    return null; // Retorna nulo se o deck não foi encontrado

                // Recupera o VersionName da DeckVersionTable usando o DeckId e LastVersion
                string versionQuery = @"SELECT VersionName FROM DeckVersionTable WHERE DeckId = @DeckId AND VersionId = @VersionId";
                using (var versionCommand = new SQLiteCommand(versionQuery, connection))
                {
                    versionCommand.Parameters.AddWithValue("@DeckId", deck.Id);
                    versionCommand.Parameters.AddWithValue("@VersionId", deck.LastVersion);

                    using (var reader = versionCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            deck.VersionName = reader.GetString(reader.GetOrdinal("VersionName"));
                        }
                    }
                }

                // Carrega a lista de funções
                deck.FunctionsList = new List<string>();
                string functionsQuery = @"
        SELECT ItemName 
        FROM RelationsTable 
        WHERE DeckId = @DeckId AND VersionId = @VersionId AND ListType = 'Functions' 
        ORDER BY Position";

                using (var functionCommand = new SQLiteCommand(functionsQuery, connection))
                {
                    functionCommand.Parameters.AddWithValue("@DeckId", deck.Id);
                    functionCommand.Parameters.AddWithValue("@VersionId", deck.LastVersion);

                    using (var reader = functionCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            deck.FunctionsList.Add(reader.GetString(0));
                        }
                    }
                }

                // Carrega a lista de cartas reais
                deck.RealDeckList = new List<CardModel>();
                string realDeckQuery = @"
        SELECT ItemName 
        FROM RelationsTable 
        WHERE DeckId = @DeckId AND VersionId = @VersionId AND ListType = 'Real' 
        ORDER BY Position";

                using (var realCommand = new SQLiteCommand(realDeckQuery, connection))
                {
                    realCommand.Parameters.AddWithValue("@DeckId", deck.Id);
                    realCommand.Parameters.AddWithValue("@VersionId", deck.LastVersion);

                    using (var reader = realCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            deck.RealDeckList.Add(new CardModel { Name = reader.GetString(0) });
                        }
                    }
                }

                // Carrega a lista de cartas ideais
                deck.IdealDeckList = new List<CardModel>();
                string idealDeckQuery = @"
        SELECT ItemName 
        FROM RelationsTable 
        WHERE DeckId = @DeckId AND VersionId = @VersionId AND ListType = 'Ideal' 
        ORDER BY Position";

                using (var idealCommand = new SQLiteCommand(idealDeckQuery, connection))
                {
                    idealCommand.Parameters.AddWithValue("@DeckId", deck.Id);
                    idealCommand.Parameters.AddWithValue("@VersionId", deck.LastVersion);

                    using (var reader = idealCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            deck.IdealDeckList.Add(new CardModel { Name = reader.GetString(0) });
                        }
                    }
                }
            }

            return deck;
        }

    }
}
