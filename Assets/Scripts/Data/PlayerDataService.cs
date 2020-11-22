using UnityEngine;

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

        public void Create(string nickname)
        {
            Database.Instance.ExecuteInsert("insert into players (nickname) values (\"" + nickname + "\")");
        }
    }
}