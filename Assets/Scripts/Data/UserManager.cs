using System.Collections.Generic;
using System.Linq;
using Data.Entities;

namespace Data
{
    public class UserManager
    {

        private static UserManager _instance;
        private readonly Dictionary<string, ChatUser> _users = new Dictionary<string, ChatUser>();
        private readonly DataManager _dataManager = DataManager.Instance;

        public List<ChatUser> OnlineUsers => _users.Values.ToList();
        public static UserManager Instance => _instance ?? (_instance = new UserManager());

        public void AddUser(ChatUser user)
        {
            var username = user.Nickname.ToLower();
            if (HasUser(username)) return;

            if (_dataManager.UserExists(username) == false)
            {
                _dataManager.CreateUser(username);
            }

            _users.Add(username, user);
        }

        public void RemoveUser(ChatUser user)
        {
            var username = user.Nickname.ToLower();
            if (HasUser(username) == false) return;
            _users.Remove(username);
        }

        public bool HasUser(string username)
        {
            username = username.ToLower();
            return _users.ContainsKey(username);
        }

        public ChatUser GetUser(string username)
        {
            if (!HasUser(username)) return null;
            username = username.ToLower();
            return _users[username];
        }
    }
}
