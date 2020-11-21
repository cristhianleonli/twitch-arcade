using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatUser
{
    public string Nickname { get; }

    public ChatUser(string nickName)
    {
        Nickname = nickName;
    }
}