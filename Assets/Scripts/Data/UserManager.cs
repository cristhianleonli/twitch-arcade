using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager: MonoBehaviour
{
    public static UserManager Instance { get; private set; }
    public List<ChatUser> OnlineUsers { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        OnlineUsers = new List<ChatUser>();
    }

    public void AddUser(ChatUser user)
    {
        OnlineUsers.Add(user);
    }

    public void RemoveUser(ChatUser user)
    {
        OnlineUsers.Remove(user);
    }
}
