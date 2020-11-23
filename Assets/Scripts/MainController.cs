using System.Collections;
using System.Collections.Generic;
using Chat;
using Data.Entities;
using UnityEngine;

public class MainController : MonoBehaviour, IChatAdapter
{
    private CanvasManager _canvasManager;

    private void Awake()
    {
        ChatManager.Instance.adapter = this;
    }

    private void Start()
    {
        _canvasManager = FindObjectOfType<CanvasManager>();
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
