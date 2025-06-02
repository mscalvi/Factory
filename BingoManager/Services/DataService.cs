using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;        
using System.IO;
using System.Linq;
using BingoManager.Models;

namespace BingoManager.Services
{
    public static class DataService
    {
        private static readonly string _connectionString;

        // Construtor estático: garante a pasta no AppData e a connection-string
        static DataService()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string databaseFolder = Path.Combine(appDataPath, "BingoManager", "Database");
            Directory.CreateDirectory(databaseFolder);

            string databasePath = Path.Combine(databaseFolder, "CustomBingoDB.db");
            _connectionString = $"Data Source={databasePath};Version=3;";

            // Cria as tabelas caso não existam (opcional, já deveria estar pronto)
            InitializeDatabase();
        }

        private static SQLiteConnection GetConnection() =>
            new SQLiteConnection(_connectionString);

        public static void InitializeDatabase()
        {
            using var connection = GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                cmd.ExecuteNonQuery();

            var createCommands = new List<string>
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
                    Description TEXT,
                    Logo TEXT
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

            foreach (var sql in createCommands)
            {
                using var cmd = new SQLiteCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
        }


        // 1. Lista os conjuntos de cartelas (“jogos”) disponíveis
        public static DataTable GetCards()
        {
            using var connection = GetConnection();
            connection.Open();

            string query = @"
                SELECT SetId, Title, End, Qnt, Name
                FROM CardsSets";
            using var command = new SQLiteCommand(query, connection);
            using var adapter = new SQLiteDataAdapter(command);

            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // 2. Carrega o Set (jogo) e metadados da lista associada
        public static DataRow GetGameInfo(int setId)
        {
            using var connection = GetConnection();
            connection.Open();

            string selectGame = @"
                SELECT Title,
                       Qnt,
                       GroupB,
                       GroupI,
                       GroupN,
                       GroupG,
                       GroupO
                FROM CardsSets
                WHERE SetId = @SetId
                LIMIT 1";
            using var cmdGame = new SQLiteCommand(selectGame, connection);
            cmdGame.Parameters.AddWithValue("@SetId", setId);

            using var adapter = new SQLiteDataAdapter(cmdGame);
            var dtGame = new DataTable();
            adapter.Fill(dtGame);

            if (dtGame.Rows.Count == 0)
                return null; // ou lance exceção, se preferir

            DataRow row = dtGame.Rows[0];
            string title = row["Title"].ToString();
            int quantity = Convert.ToInt32(row["Qnt"]);
            string grpB = row["GroupB"].ToString();
            string grpI = row["GroupI"].ToString();
            string grpN = row["GroupN"].ToString();
            string grpG = row["GroupG"].ToString();
            string grpO = row["GroupO"].ToString();

            // 2) Carrega cada coluna de IDs em List<CompanyModel>
            var listB = GetElementsInfo(grpB);
            var listI = GetElementsInfo(grpI);
            var listN = GetElementsInfo(grpN);
            var listG = GetElementsInfo(grpG);
            var listO = GetElementsInfo(grpO);

            // 3) Monta o GameModel e retorna
            return new GameModel
            {
                GameName = title,
                GameTotal = quantity,
                BElements = listB.Select(c => c.CardName).ToList(),
                IElements = listI.Select(c => c.CardName).ToList(),
                NElements = listN.Select(c => c.CardName).ToList(),
                GElements = listG.Select(c => c.CardName).ToList(),
                OElements = listO.Select(c => c.CardName).ToList()
            };
        }


        // 3. A partir de uma string “1,5,8,12,...”, retorna lista de CompanyModel (ID, Name, CardName, Logo)
        public static List<ElementModel> GetElementsInfo(string companyIds)
        {
            var companies = new List<ElementModel>();
            if (string.IsNullOrWhiteSpace(companyIds))
                return companies;

            var ids = companyIds.Split(',').Select(x => x.Trim()).ToList();
            string query = $"SELECT Id, Name, CardName, Logo FROM CompanyTable WHERE Id IN ({string.Join(",", ids)})";

            using var connection = GetConnection();
            connection.Open();
            using var command = new SQLiteCommand(query, connection);
            using var reader = command.ExecuteReader();

            var dictionary = new Dictionary<int, ElementModel>();
            while (reader.Read())
            {
                var c = new ElementModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    CardName = reader["CardName"].ToString(),
                    Logo = reader["Logo"].ToString()
                };
                dictionary[c.Id] = c;
            }

            // Reconstrói na mesma ordem de 'ids'
            companies = ids.Select(id => dictionary[int.Parse(id)]).ToList();
            return companies;
        }

        // 4. Carrega o logo/imagem de cada empresa (pasta AppData\Local\BingoManager\Images)
        public static Image LoadImageFromFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return null;

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string imageFolderPath = Path.Combine(appDataPath, "BingoManager", "Images");
            string filePath = Path.IsPathRooted(fileName)
                                     ? fileName
                                     : Path.Combine(imageFolderPath, fileName);
            return File.Exists(filePath) ? Image.FromFile(filePath) : null;
        }

        // 5. Para cada cartela, traz todos os 25 IDs de elementos (B, I, N, G, O)
        public static CardModel GetCardDetails(int cardNum, int setId)
        {
            using var connection = GetConnection();
            connection.Open();

            string selectQuery = @"
                SELECT Id, CardNumber,
                       CompB1, CompB2, CompB3, CompB4, CompB5,
                       CompI1, CompI2, CompI3, CompI4, CompI5,
                       CompN1, CompN2, CompN3, CompN4, CompN5,
                       CompG1, CompG2, CompG3, CompG4, CompG5,
                       CompO1, CompO2, CompO3, CompO4, CompO5
                FROM CardsList
                WHERE CardNumber = @CardNum
                  AND SetId     = @SetId";

            using var command = new SQLiteCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@CardNum", cardNum);
            command.Parameters.AddWithValue("@SetId", setId);

            using var reader = command.ExecuteReader();
            if (!reader.Read()) return null;

            var bCompanies = new List<int>();
            var iCompanies = new List<int>();
            var nCompanies = new List<int>();
            var gCompanies = new List<int>();
            var oCompanies = new List<int>();

            for (int i = 2; i <= 6; i++) bCompanies.Add(reader.GetInt32(i));
            for (int i = 7; i <= 11; i++) iCompanies.Add(reader.GetInt32(i));
            for (int i = 12; i <= 16; i++) nCompanies.Add(reader.GetInt32(i));
            for (int i = 17; i <= 21; i++) gCompanies.Add(reader.GetInt32(i));
            for (int i = 22; i <= 26; i++) oCompanies.Add(reader.GetInt32(i));

            var all = new List<int>();
            all.AddRange(bCompanies);
            all.AddRange(iCompanies);
            all.AddRange(nCompanies);
            all.AddRange(gCompanies);
            all.AddRange(oCompanies);

            return new CardModel
            {
                CardId = reader.GetInt32(0),
                CardNumber = reader.GetInt32(1),
                AllCompanies = all,
                BCompanies = bCompanies,
                ICompanies = iCompanies,
                NCompanies = nCompanies,
                GCompanies = gCompanies,
                OCompanies = oCompanies,
                Companies1 = new List<int> { bCompanies[0], iCompanies[0], nCompanies[0], gCompanies[0], oCompanies[0] },
                Companies2 = new List<int> { bCompanies[1], iCompanies[1], nCompanies[1], gCompanies[1], oCompanies[1] },
                Companies3 = new List<int> { bCompanies[2], iCompanies[2], nCompanies[2], gCompanies[2], oCompanies[2] },
                Companies4 = new List<int> { bCompanies[3], iCompanies[3], nCompanies[3], gCompanies[3], oCompanies[3] },
                Companies5 = new List<int> { bCompanies[4], iCompanies[4], nCompanies[4], gCompanies[4], oCompanies[4] }
            };
        }

        // 6. Retorna quais cartelas (e números de cartela) contêm determinada empresa
        public static List<(int CardId, int CardNum)> GetCardsByCompanyId(int companyId, int setId)
        {
            var cards = new List<(int CardId, int CardNum)>();
            using var connection = GetConnection();
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

            using var command = new SQLiteCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@CompanyId", companyId);
            command.Parameters.AddWithValue("@SetId", setId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                cards.Add((reader.GetInt32(0), reader.GetInt32(1)));
            }

            return cards;
        }
    }
}
