using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelType
{
    GAME_LIST,
    LEADERBOARD,
    PLAYERS,
    SETTINGS,
    STATS
}

class PanelData
{
    public PanelType panelType;
    public GameObject panel;
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
    private List<PanelData> panels = new List<PanelData>();

    void Start()
    {
        panels.Add(new PanelData(PanelType.GAME_LIST, FindObjectOfType<GameListPanel>().gameObject, null));
        panels.Add(new PanelData(PanelType.LEADERBOARD, FindObjectOfType<LeaderboardPanel>().gameObject, null));
        panels.Add(new PanelData(PanelType.PLAYERS, FindObjectOfType<PlayersPanel>().gameObject, null));
        panels.Add(new PanelData(PanelType.SETTINGS, FindObjectOfType<SettingsPanel>().gameObject, null));
        panels.Add(new PanelData(PanelType.STATS, FindObjectOfType<StatsPanel>().gameObject, null));

        foreach (PanelButton button in FindObjectsOfType<PanelButton>())
        {
            panels.Find(item => item.panelType == button.panelType).button = button;
        }

        SelectPanel(PanelType.GAME_LIST);
    }

    private void SelectPanel(PanelType targetPanel)
    {
        foreach (PanelData panel in panels)
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
