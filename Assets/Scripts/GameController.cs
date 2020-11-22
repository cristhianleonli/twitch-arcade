using Chat;
using Data;
using Data.Entities;
using UnityEngine;

public class GameController : MonoBehaviour, IChatAdapter
{

    private CanvasManager canvasManager;

    private void Awake()
    {
        ChatManager.Instance.adapter = this;
    }

    private void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
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
        // FIXME: Replace this logic with players text or something
        string text = "";
        foreach (ChatUser chatUser in UserManager.Instance.OnlineUsers) {
            text += chatUser.Nickname + "\n";
        }
        canvasManager.SetPlayersTitle(text);
    }

    public void OnUserLeft(ChatUser user)
    {
        // FIXME: Replace this logic with players text or something
        string text = "";
        foreach (ChatUser chatUser in UserManager.Instance.OnlineUsers) {
            text += chatUser.Nickname + "\n";
        }
        canvasManager.SetPlayersTitle(text);
    }
    #endregion
}
