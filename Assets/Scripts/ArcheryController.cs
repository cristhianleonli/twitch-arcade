using System;
using System.Collections.Generic;
using Chat;
using Data;
using Data.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

public struct PlayerData
{
    public string Nickname;
    public int Score;
    
    public PlayerData(ChatUser user)
    {
        Nickname = user.Nickname;
        Score = user.Score;
    }
}

public class ArcheryController : MonoBehaviour, IChatAdapter, UserObserver
{
    public Player playerPrefab;
    private readonly List<Player> _players = new List<Player>();
    
    private void Awake()
    {
        ChatManager.Instance.adapter = this;
        UserManager.Instance.AddObserver(this);
    }

    public void OnCommandReceived(ChatCommand command)
    {
        // TODO: 
    }

    public bool IsValidCommand(string command, string[] parameters)
    {
        return false;
    }
    
    public void OnUserJoined(List<ChatUser> users, ChatUser user)
    {
        var positionX = Random.Range(-8.1f, 8.1f);
        var positionY = Random.Range(-3.5f, 3.5f);
        
        var player = Instantiate(playerPrefab, new Vector3(positionX, positionY, 0), Quaternion.identity);
        player.Init(new PlayerData(user));
        
        _players.Add(player);
    }

    public void OnUserLeft(List<ChatUser> users, ChatUser user)
    {
        var playerToRemove = _players.Find(player => player.Identifier == user.Nickname);
        Destroy(playerToRemove.gameObject);
        _players.RemoveAll(player => player.Identifier == user.Nickname);
    }
}
