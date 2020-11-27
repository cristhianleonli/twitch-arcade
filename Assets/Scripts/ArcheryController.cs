using System;
using System.Collections.Generic;
using Chat;
using Data;
using Data.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

struct PlayerData
{
    public Player player;
    public ChatUser user;

    public PlayerData(Player player, ChatUser user)
    {
        this.player = player;
        this.user = user;
    }
}

public class ArcheryController : MonoBehaviour, IChatAdapter, UserObserver
{
    public Player playerPrefab;
    private readonly List<PlayerData> _players = new List<PlayerData>();
    
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
        
        var playerData = new PlayerData(player, user);
        _players.Add(playerData);
    }

    public void OnUserLeft(List<ChatUser> users, ChatUser user)
    {
        var player = _players.Find(playerData => playerData.user.Nickname == user.Nickname);
        Destroy(player.player.gameObject);
        _players.RemoveAll(playerData => playerData.user.Nickname == user.Nickname);
    }
}
