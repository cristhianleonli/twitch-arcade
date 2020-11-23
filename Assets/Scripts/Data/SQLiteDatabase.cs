using System.Collections.Generic;
using System.Data;
using Data.Entities;
using Mono.Data.SqliteClient;

namespace Data
{
    class SQLiteDatabase : IDatabase
    {
        private static SQLiteDatabase _instance;
        public static SQLiteDatabase Instance => _instance ?? (_instance = new SQLiteDatabase());

        private const string DatabaseName = "URI=file:debug.database.db";
        private SQLiteDatabase()
        {
            SetupDatabase();
        }

        private void SetupDatabase()
        {
            using (var connection = new SqliteConnection(DatabaseName))
            {
                connection.Open();
                foreach (var tableCommand in createTableCommands())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = tableCommand;
                        command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }
    
        private string[] createTableCommands()
        {
            var playersTable = "CREATE TABLE IF NOT EXISTS players(" +
                               "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                               "nickname VARCHAR(255) NOT NULL UNIQUE," +
                               "score INT DEFAULT 0," +
                               "created_at TEXT" +
                               ")";

            return new[] { playersTable };
        }
    
        public ChatUser FetchUser(string nickname)
        {
            var reader = ExecuteQuery("SELECT * FROM players WHERE nickname=\"" + nickname + "\"");
        
            while (reader.Read())
            {
                var id = int.Parse(reader["id"].ToString());
                var nick = reader["nickname"].ToString();
                var score = int.Parse(reader["score"].ToString());
                var createdAt = reader["created_at"].ToString();
                return  new ChatUser(id, nick, score, createdAt);
            }

            return null;
        }

        public List<ChatUser> FetchAllUsers()
        {
            var reader = ExecuteQuery("SELECT * FROM players");
            var users = new List<ChatUser>();
            while (reader.Read())
            {
                var id = int.Parse(reader["id"].ToString());
                var nick = reader["nickname"].ToString();
                var score = int.Parse(reader["score"].ToString());
                var createdAt = reader["created_at"].ToString();
                users.Add(new ChatUser(id, nick, score, createdAt));
            }
        
            reader.Close();
            return users;
        }

        public bool UserExists(string nickname)
        {
            var reader = ExecuteQuery("SELECT COUNT(*) as counter FROM players WHERE nickname=\"" + nickname + "\"");
            while (reader.Read())
            {
                var count = int.Parse(reader["counter"].ToString());
                reader.Close();
                return count == 1;
            }
        
            reader.Close();
            return false;
        }

        public void CreateUser(string nickname, string datetime)
        {
            ExecuteNonQuery("INSERT INTO players (nickname, created_at) VALUES (\"" + nickname + "\", datetime('now'))");
        }
    
        private IDataReader ExecuteQuery(string query)
        {
            using (var connection = new SqliteConnection(DatabaseName))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        connection.Close();
                        return reader;
                    }
                }
            }
        }

        private void ExecuteNonQuery(string query)
        {
            using (var connection = new SqliteConnection(DatabaseName))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
