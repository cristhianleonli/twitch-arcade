using System.Collections.Generic;
using System.Linq;
using Data.Entities;

public interface UserObserver
{
    void OnUserJoined(List<ChatUser> users, ChatUser user);
    void OnUserLeft(List<ChatUser> users, ChatUser user);
}

namespace Data
{
    public class UserManager
    {
        public List<ChatUser> OnlineUsers => _users.Values.ToList();

        private readonly Dictionary<string, ChatUser> _users = new Dictionary<string, ChatUser>();
        private readonly PlayerDataService _playerService = new PlayerDataService();
        private readonly List<UserObserver> _observers = new List<UserObserver>();

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

        #region observers
        public void AddObserver(UserObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(UserObserver observer)
        {
            _observers.Remove(observer);
        }
        # endregion

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

            foreach (var observer in _observers)
            {
                observer.OnUserJoined(OnlineUsers, user);
            }

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

            foreach (var observer in _observers)
            {
                observer.OnUserLeft(OnlineUsers, user);
            }

            return user;
        }
    }
}
