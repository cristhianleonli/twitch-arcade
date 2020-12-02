using System.Collections;
using System.Collections.Generic;
using Chat;
using Data.Entities;
using UnityEngine;

public class MainController : MonoBehaviour, IChatAdapter
{
    private MainCanvas _mainCanvas;

    private void Awake()
    {
        ChatManager.Instance.adapter = this;
    }

    private void Start()
    {
        _mainCanvas = FindObjectOfType<MainCanvas>();
    }

    #region Command adapter
    public bool IsValidCommand(string command, string[] parameters)
    {
        return false;
    }

    public void OnCommandReceived(ChatCommand command)
    {
    }

    public void OnUserJoined(ChatUser user)
    {
        Debug.Log(user.ToString());
    }

    public void OnUserLeft(ChatUser user)
    {
        Debug.Log(user.ToString());
    }
    #endregion
}
