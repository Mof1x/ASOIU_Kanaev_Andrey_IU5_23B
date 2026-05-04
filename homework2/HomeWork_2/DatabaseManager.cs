using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace HomeWork_2
{
    internal class DatabaseManager
    {
        private string _connectionString;

        public DatabaseManager(string dbPath)
        {
            _connectionString = $"Data Source={dbPath}";
        }

        public void InitializeDatabase(string platformsCsvPath, string gamesCsvPath)
        {
            CreateTables();

            Console.WriteLine(platformsCsvPath);
            if (GetAllPlatforms().Count == 0 && File.Exists(platformsCsvPath))
            {
                ImportPlatformsFromCsv(platformsCsvPath);
                Console.WriteLine($"[OK] Загружены платформы из {platformsCsvPath}");
            }

            if (GetAllGames().Count == 0 && File.Exists(gamesCsvPath))
            {
                ImportGamesFromCsv(gamesCsvPath);
                Console.WriteLine($"[OK] Загружены игры из {gamesCsvPath}");
            }
        }

        private void CreateTables()
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS platforms (
                platform_id INTEGER PRIMARY KEY AUTOINCREMENT,
                platform_name TEXT NOT NULL
            );
            CREATE TABLE IF NOT EXISTS games (
                game_id INTEGER PRIMARY KEY AUTOINCREMENT,
                platform_id INTEGER NOT NULL,
                game_name TEXT NOT NULL,
                rating INTEGER NOT NULL,
                FOREIGN KEY (platform_id) REFERENCES platforms(platform_id)
            );";
            cmd.ExecuteNonQuery();
        }

        private void ImportPlatformsFromCsv(string path)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length < 2) continue;
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO platforms (platform_id, platform_name) VALUES (@id, @name)";
                cmd.Parameters.AddWithValue("@id", int.Parse(parts[0]));
                cmd.Parameters.AddWithValue("@name", parts[1]);
                cmd.ExecuteNonQuery();
            }
        }

        private void ImportGamesFromCsv(string path)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length < 4) continue;
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                INSERT INTO games (game_id, platform_id, game_name, rating)
                VALUES (@id, @platformId, @name, @rating)";
                cmd.Parameters.AddWithValue("@id", int.Parse(parts[0]));
                cmd.Parameters.AddWithValue("@platformId", int.Parse(parts[1]));
                cmd.Parameters.AddWithValue("@name", parts[2]);
                cmd.Parameters.AddWithValue("@rating", int.Parse(parts[3]));
                cmd.ExecuteNonQuery();
            }
        }

        public List<Platform> GetAllPlatforms()
        {
            var result = new List<Platform>();
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT platform_id, platform_name FROM platforms ORDER BY platform_id";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Platform(reader.GetInt32(0), reader.GetString(1)));
            }
            return result;
        }

        public List<Game> GetAllGames()
        {
            var result = new List<Game>();
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT game_id, platform_id, game_name, rating FROM games ORDER BY game_id";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Game(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3)));
            }
            return result;
        }


        public Game GetGameById(int id)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT game_id, platform_id, game_name, rating FROM games WHERE game_id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Game(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3));
            }
            return null;
        }

        public void AddGame(Game game)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            INSERT INTO games (platform_id, game_name, rating)
            VALUES (@platformId, @name, @rating)";
            cmd.Parameters.AddWithValue("@platformId", game.PlatformId);
            cmd.Parameters.AddWithValue("@name", game.Name);
            cmd.Parameters.AddWithValue("@rating", game.Rating);
            cmd.ExecuteNonQuery();
        }

        public void UpdateGame(Game game)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            UPDATE games 
            SET platform_id = @platformId, game_name = @name, rating = @rating 
            WHERE game_id = @id";
            cmd.Parameters.AddWithValue("@id", game.Id);
            cmd.Parameters.AddWithValue("@platformId", game.PlatformId);
            cmd.Parameters.AddWithValue("@name", game.Name);
            cmd.Parameters.AddWithValue("@rating", game.Rating);
            cmd.ExecuteNonQuery();
        }

        public void DeleteGame(int id)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM games WHERE game_id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public (string[] columns, List<string[]> rows) ExecuteQuery(string sql)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            using var reader = cmd.ExecuteReader();

            string[] columns = new string[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
                columns[i] = reader.GetName(i);

            var rows = new List<string[]>();
            while (reader.Read())
            {
                string[] row = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    row[i] = reader.GetValue(i)?.ToString() ?? "";
                rows.Add(row);
            }
            return (columns, rows);
        }


        public void ExportToCsv(string platformsPath, string gamesPath)
        {
            var platformLines = new List<string>();
            platformLines.Add("platform_id;platform_name");
            foreach (var platform in GetAllPlatforms())
                platformLines.Add($"{platform.Id};{platform.Name}");
            File.WriteAllLines(platformsPath, platformLines.ToArray());

            var gameLines = new List<string>();
            gameLines.Add("game_id;platform_id;game_name;rating");
            foreach (var game in GetAllGames())
                gameLines.Add($"{game.Id};{game.PlatformId};{game.Name};{game.Rating}");
            File.WriteAllLines(gamesPath, gameLines.ToArray());
        }


        public List<Game> GetGamesByPlatform(int platformId)
        {
            var result = new List<Game>();
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT game_id, platform_id, game_name, rating 
            FROM games WHERE platform_id = @platformId ORDER BY game_name";
            cmd.Parameters.AddWithValue("@platformId", platformId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Game(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3)));
            }
            return result;
        }
    }
}
