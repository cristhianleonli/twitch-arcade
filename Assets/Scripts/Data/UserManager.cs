using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UserManager
{
    private readonly Dictionary<string, ChatUser> users = new Dictionary<string, ChatUser>();
    public List<ChatUser> OnlineUsers => users.Values.ToList();

    private static UserManager instance;

    public static UserManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UserManager();
            }

            return instance;
        }
    }

    public void AddUser(ChatUser user)
    {
        string username = user.Nickname.ToLower();
        if (HasUser(username)) return;
        users.Add(username, user);
    }

    public void RemoveUser(ChatUser user)
    {
        string username = user.Nickname.ToLower();
        if (HasUser(username) == false) return;
        users.Remove(username);
    }

    public bool HasUser(string username)
    {
        username = username.ToLower();
        return users.ContainsKey(username);
    }

    public ChatUser GetUser(string username)
    {
        if (!HasUser(username)) return null;

        username = username.ToLower();
        return users[username];
    }
}
