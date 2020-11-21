using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChatUser
{
    public string Nickname { get; }

    public int Score = 0;
    public DateTime CreatedAt = DateTime.Now;


    public ChatUser(string nickName)
    {
        Nickname = nickName;
    }

    public ChatUser(string nickName, int score, DateTime createdAt)
    {
        Nickname = nickName;
        Score = score;
        CreatedAt = createdAt;
    }
}