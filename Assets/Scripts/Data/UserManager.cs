using System.Collections.Generic;
using System.Linq;
using Data.Entities;

namespace Data
{
    public class UserManager
    {
        private readonly Dictionary<string, ChatUser> _users = new Dictionary<string, ChatUser>();
        private readonly PlayerDataService _playerService = new PlayerDataService();
        public List<ChatUser> OnlineUsers => _users.Values.ToList();

        private static UserManager _instance;
        public static UserManager Instance => _instance ?? (_instance = new UserManager());

        private ChatUser GetUser(string nickname)
        {
            return _users[nickname];
        }

        private bool HasUser(string nickname)
        {
            return _users.ContainsKey(nickname.ToLower());
        }

        public ChatUser UserDidJoin(string nickname) {
            nickname = nickname.ToLower();
            if (HasUser(nickname))
            {
                return GetUser(nickname);
            }

            if (!_playerService.Exists(nickname))
            {
                _playerService.Create(nickname);
            }

            var user = _playerService.Find(nickname);
            _users.Add(nickname, user);
            AudioManager.PlaySound(SoundType.Connected);
            return user;
        }

        public ChatUser UserDidLeave(string nickname)
        {
            nickname = nickname.ToLower();
            if (!HasUser(nickname))
            {
                return null;
            }

            var user = GetUser(nickname);
            _users.Remove(nickname);
            AudioManager.PlaySound(SoundType.Disconnected);
            return user;
        }
    }
}
