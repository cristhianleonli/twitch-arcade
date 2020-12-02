using System.Collections.Generic;
using System.Linq;
using Chat;
using Data;
using Data.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

public enum ArcheryState
{
    Lobby,
    Gameplay,
    Results
}

public class ArcheryController : MonoBehaviour, IChatAdapter, UserObserver
{
    [SerializeField] private Archer archerPrefab;
    private readonly List<Archer> _players = new List<Archer>();
    private ArcheryState _currentState = ArcheryState.Lobby;
    public static string SceneName => "ArcheryScene";
    
    private void Awake()
    {
        ChatManager.Instance.adapter = this;
        UserManager.Instance.AddObserver(this);
    }

    public void OnCommandReceived(ChatCommand command)
    {
        
    }

    public bool IsValidCommand(string command, string[] parameters)
    {
        return false;
    }
    
    public void OnUserJoined(List<ChatUser> users, ChatUser user)
    {
        var positionX = Random.Range(-8.1f, 8.1f);
        var positionY = -4.5f;
        
        var archer = Instantiate(archerPrefab, new Vector3(positionX, positionY, 0), Quaternion.identity);
        archer.Init(new ArcherData(user));
        archer.SetState(_currentState);
        
        _players.Add(archer);
    }

    public void OnUserLeft(List<ChatUser> users, ChatUser user)
    {
        var playerToRemove = _players.Find(player => player.Identifier == user.Nickname);
        Destroy(playerToRemove.gameObject);
        _players.RemoveAll(player => player.Identifier == user.Nickname);
    }

    public void OnGameStart()
    {
        _currentState = ArcheryState.Gameplay;
        _players.ForEach(player => player.SetState(ArcheryState.Gameplay));
    }
}
