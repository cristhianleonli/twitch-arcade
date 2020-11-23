using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{

    public PanelType panelType;

    private CanvasManager canvasManager;
    private Image image;
    private Button button;
    private Text title;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
        button = GetComponentInChildren<Button>();
        title = GetComponentInChildren<Text>();

        canvasManager = FindObjectOfType<CanvasManager>();
        button.onClick.AddListener(OnClick);
        title.text = PanelName();
    }

    private string PanelName()
    {
        switch (panelType)
        {
            case PanelType.GameList: return "Games";
            case PanelType.Leaderboard: return "Leaderboard";
            case PanelType.Settings: return "Settings";
            case PanelType.Stats: return "Stats";
            case PanelType.Players: return "Players";
            default: return "";
        }
    }

    private void OnClick()
    {
        canvasManager.OnButtonClicked(this);
    }

    public void SetSelected(bool value)
    {
        //image.color = value ? Color.red : Color.white;
        title.color = value ? Color.red : Color.white;
    }
}
