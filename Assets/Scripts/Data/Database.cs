using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine;

namespace Data
{
    public class Database
    {
        private static Database _instance;
        private const string DatabaseName = "URI=file:debug.database.db";
        public static Database Instance => _instance ?? (_instance = new Database());

        private Database()
        {
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            using (var connection = new SqliteConnection(DatabaseName))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    const string commandText = "CREATE TABLE IF NOT EXISTS players(" +
                                       "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                       "nickname VARCHAR(255) NOT NULL UNIQUE," +
                                       "score INT DEFAULT 0," +
                                       "created_at TEXT" +
                                       ")";
                    command.CommandText = commandText;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IDataReader ExecuteQuery(string query)
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

        public void ExecuteInsert(string query)
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
