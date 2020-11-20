﻿using System.Collections.Generic;
using System.Linq;
using TwitchChatConnect.Data;

namespace TwitchChatConnect.Manager
{
    public static class TwitchUserManager
    {
        private static Dictionary<string, TwitchUser> users = new Dictionary<string, TwitchUser>();

        public static List<TwitchUser> Users => users.Values.ToList();
        
        public static TwitchUser AddUser(string username)
        {
            TwitchUser twitchUser = new TwitchUser(username);
            username = twitchUser.Username.ToUpper();
            if (HasUser(username)) return users[username];
            users.Add(username, twitchUser);
            return twitchUser;
        }

        public static void RemoveUser(string username)
        {
            username = username.ToUpper();
            if (!HasUser(username)) return;
            users.Remove(username);
        }

        public static bool HasUser(string username)
        {
            username = username.ToUpper();
            return users.ContainsKey(username);
        }

        public static TwitchUser GetUser(string username)
        {
            if (!HasUser(username)) return AddUser(username);
            username = username.ToUpper();
            return users[username];
        }
    }
}