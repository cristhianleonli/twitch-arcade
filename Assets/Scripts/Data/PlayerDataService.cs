using Data.Entities;

namespace Data
{
    public class PlayerDataService
    {
        public bool Exists(string nickname)
        {
            var reader = Database.Instance.ExecuteQuery("SELECT COUNT(*) as counter FROM players WHERE nickname=\"" + nickname + "\"");
            
            while (reader.Read())
            {
                var count = int.Parse(reader["counter"].ToString());
                reader.Close();
                return count == 1;
            }

            return false;
        }

        public ChatUser Create(string nickname)
        {
            Database.Instance.ExecuteInsert("INSERT INTO players (nickname, created_at) VALUES (\"" + nickname + "\", datetime('now'))");
            return Find(nickname);
        }

        public ChatUser Find(string nickname)
        {
            var reader = Database.Instance.ExecuteQuery("SELECT * FROM players WHERE nickname=\"" + nickname + "\"");

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
    }
}