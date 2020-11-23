using System.Collections;
using System.Collections.Generic;
using Chat;
using Data.Entities;
using UnityEngine;

public class ArcheryController : MonoBehaviour, IChatAdapter
{
    private void Awake()
    {
        ChatManager.Instance.adapter = this;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnCommandReceived(ChatCommand command)
    {
        throw new System.NotImplementedException();
    }

    public bool IsValidCommand(string command, string[] parameters)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserJoined(ChatUser user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserLeft(ChatUser user)
    {
        throw new System.NotImplementedException();
    }
}
