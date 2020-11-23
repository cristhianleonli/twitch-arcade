using System;
using Data.Entities;

namespace Data
{
    public class PlayerDataService
    {

        private readonly IDatabase _database;

        public PlayerDataService(IDatabase database = null)
        {
            _database = database ?? SQLiteDatabase.Instance;
        }
        
        public bool Exists(string nickname)
        {
            return _database.UserExists(nickname);
        }

        public void Create(string nickname)
        {
            _database.CreateUser(nickname, DateTime.UtcNow.ToString());
        }

        public ChatUser Find(string nickname)
        {
            return _database.FetchUser(nickname);
        }
    }
}