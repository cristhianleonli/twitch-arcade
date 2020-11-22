using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using UnityEngine;

namespace Data
{
    public class UserManager
    {
        private readonly Dictionary<string, ChatUser> _users = new Dictionary<string, ChatUser>();
        private readonly PlayerDataService _playerService = new PlayerDataService();
        public List<ChatUser> OnlineUsers => _users.Values.ToList();
        
        private static UserManager _instance;
        public static UserManager Instance => _instance ?? (_instance = new UserManager());

        public void AddUser(ChatUser user)
        {
            var nickname = user.Nickname.ToLower();
            if (HasUser(nickname)) return;

            if (!_playerService.Exists(nickname))
            {
                _playerService.Create(nickname);
            }
            
            _users.Add(nickname, user);
        }

        public void RemoveUser(ChatUser user)
        {
            var nickname = user.Nickname.ToLower();
            if (HasUser(nickname) == false) return;
            _users.Remove(nickname);
        }

        private bool HasUser(string nickname)
        {
            return _users.ContainsKey(nickname.ToLower());
        }
    }
}
