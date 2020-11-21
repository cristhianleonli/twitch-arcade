using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IChatAdapter
{

    private void Awake()
    {
        ChatManager.Instance.adapter = this;
    }

    #region Command adapter
    public bool IsValidCommand(string command, string[] parameters)
    {
        throw new System.NotImplementedException();
    }

    public void OnCommandReceived(ChatCommand command)
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
    #endregion
}
