using System.Collections;
using System.Collections.Generic;
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

public class CanvasManager : MonoBehaviour
{
    private readonly List<PanelData> _panels = new List<PanelData>();

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
}
