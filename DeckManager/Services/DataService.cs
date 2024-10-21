using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.VisualBasic.Logging;
using System.Xml.Linq;

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

        //Categories
        public static List<CategoryModel> GetCategories()
        {
            var categories = new List<CategoryModel>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT CatId, Name FROM CategoryTable;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Lê os dados da consulta
                    while (reader.Read())
                    {
                        var category = new CategoryModel
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

        public static void NewCategory(string name)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM CategoryTable WHERE Name = @Name;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    long count = (long)command.ExecuteScalar(); 

                    if (count > 0)
                    {
                        throw new ArgumentException("Uma categoria com este nome já existe.");
                    }
                }

                // Se não existir, insere a nova categoria
                string insertQuery = "INSERT INTO CategoryTable (Name) VALUES (@Name);";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCategory(int catId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteFromAllocationQuery = "DELETE FROM AlocationTable WHERE CatId = @CatId";
                        using (var command = new SQLiteCommand(deleteFromAllocationQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CatId", catId);
                            command.ExecuteNonQuery();
                        }

                        string deleteListQuery = "DELETE FROM CategoryTable WHERE Id = @CatId";
                        using (var command = new SQLiteCommand(deleteListQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CatId", catId);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

    }
}
