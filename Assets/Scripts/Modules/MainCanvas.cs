using System.Collections;
using System.Collections.Generic;
using Data.Entities;
using Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameType
{
    Archery
}

public class MainCanvas : MonoBehaviour, UserObserver
{
    public Text usersText;
    public SettingsCanvas settingsCanvas;
    public TransitionsCanvas transitionsCanvas;

    public PanelButton archeryButton;
    public PanelButton settingsButton;
    public PanelButton exitButton;

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
        
        settingsButton.SetAction(OpenSettings);
        exitButton.SetAction(CloseApplication);
        
        // buttons
        archeryButton.SetAction(() => OnGameSelected(GameType.Archery));
    }

    private void OnGameSelected(GameType gameType)
    {
        _audioManager.PlayClick();

        // switch (gameType)
        // {
        //     case GameType.Archery:
        //         SceneManager.LoadScene(ArcheryController.SceneName, LoadSceneMode.Single);
        //         break;
        // }
        
        transitionsCanvas.MoveIn(() =>
                SceneManager.LoadScene(ArcheryController.SceneName, LoadSceneMode.Single)
            );
    }

    private void OpenSettings() {
        settingsCanvas.Show();
    }

    private void CloseApplication()
    {
        Application.Quit();
    }
    
    public void OnUserJoined(List<ChatUser> users, ChatUser user)
    {
        usersText.text = $"{users.Count}";
    }

    public void OnUserLeft(List<ChatUser> users, ChatUser user)
    {
        usersText.text = $"{users.Count}";
    }
}
