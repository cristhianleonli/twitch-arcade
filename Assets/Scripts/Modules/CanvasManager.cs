using System.Collections.Generic;
using Data.Entities;
using Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PanelType
{
    GameList,
    Leaderboard,
    Settings,
    Players,
    Leave
}

public enum GameType
{
    Archery
}

public class CanvasManager : MonoBehaviour, UserObserver
{
    public Text usersText;
    public SettingsCanvas settingsCanvas;

    public PanelButton archeryButton;
    public PanelButton settingsButton;

    private AudioManager _audioManager;

    private void Awake()
    {
        UserManager.Instance.AddObserver(this);
    }

    private void OnDestroy()
    {
        UserManager.Instance.RemoveObserver(this);
    }

    private void Start()
    {
        usersText.text = "0";
        _audioManager = FindObjectOfType<AudioManager>();

        archeryButton.SetAction(() => OnGameSelected(GameType.Archery));
        settingsButton.SetAction(OpenSettings);
        //archeryButton.onClick.AddListener(() => OnGameSelected(GameType.Archery));
        //settingsButton.onClick.AddListener(OpenSettings);
    }

    private void OnGameSelected(GameType gameType)
    {
        _audioManager.PlayClick();

        switch (gameType)
        {
            case GameType.Archery:
                SceneManager.LoadScene(ArcheryController.SceneName, LoadSceneMode.Single);
                break;
        }
    }

    private void OpenSettings() {
        settingsCanvas.Show();
    }

    //public void OnButtonClicked(PanelButton button)
    //{
    //    if (button.panelType == PanelType.Leave)
    //    {
    //        Application.Quit();
    //        return;
    //    }

    //    switch (button.panelType)
    //    {
    //        case PanelType.Leave:
    //            Application.Quit();
    //            break;
    //        case PanelType.Settings:
    //            settingsCanvas.Show();
    //            break;
    //        default:
    //            break;
    //    }
    //}

    public void OnUserJoined(List<ChatUser> users, ChatUser user)
    {
        usersText.text = $"{users.Count}";
    }

    public void OnUserLeft(List<ChatUser> users, ChatUser user)
    {
        usersText.text = $"{users.Count}";
    }
}
