using System.Collections.Generic;
using Data.Entities;
using Data;
using UnityEngine;
using UnityEngine.UI;

public enum PanelType
{
    GameList,
    Leaderboard,
    Settings,
    Players,
    Leave
}

internal class PanelData
{
    public readonly PanelType panelType;
    public readonly GameObject panel;
    public PanelButton button;

    public PanelData(PanelType panelType, GameObject panel, PanelButton button)
    {
        this.panelType = panelType;
        this.panel = panel;
        this.button = button;
    }
}

public class CanvasManager : MonoBehaviour, UserObserver
{

    public Text usersText;
    private readonly List<PanelData> _panels = new List<PanelData>();

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
        _panels.Add(new PanelData(PanelType.GameList, FindObjectOfType<GameListPanel>().gameObject, null));
        _panels.Add(new PanelData(PanelType.Leaderboard, FindObjectOfType<LeaderboardPanel>().gameObject, null));
        _panels.Add(new PanelData(PanelType.Settings, FindObjectOfType<SettingsPanel>().gameObject, null));

        foreach (var button in FindObjectsOfType<PanelButton>())
        {
            var panel = _panels.Find(item => item.panelType == button.panelType);
            if (panel != null)
            {
                panel.button = button;
            }
        }

        SelectPanel(PanelType.GameList);
        usersText.text = "0";
    }

    private void SelectPanel(PanelType targetPanel)
    {
        foreach (var panel in _panels)
        {
            if(panel.panelType == targetPanel)
            {
                panel.panel.SetActive(true);
                panel.button.SetSelected(true);
            } else
            {
                panel.panel.SetActive(false);
                panel.button.SetSelected(false);
            }
        }
    }

    public void OnButtonClicked(PanelButton button)
    {
        SelectPanel(button.panelType);
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
