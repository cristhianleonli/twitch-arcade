using UnityEngine;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    public PanelType panelType;

    private CanvasManager _canvasManager;
    private Image _image;
    private Button _button;
    private Text _title;

    private void Start()
    {
        _image = GetComponentInChildren<Image>();
        _button = GetComponentInChildren<Button>();
        _title = GetComponentInChildren<Text>();

        _canvasManager = FindObjectOfType<CanvasManager>();
        _button.onClick.AddListener(OnClick);
        _title.text = PanelName();
    }

    private string PanelName()
    {
        switch (panelType)
        {
            // TODO: Needs translation
            case PanelType.GameList: return "Games";
            case PanelType.Leaderboard: return "Leaderboard";
            case PanelType.Settings: return "Settings";
            default: return "";
        }
    }

    private void OnClick()
    {
        _canvasManager.OnButtonClicked(this);
    }

    public void SetSelected(bool value)
    {
        _title.color = value ? Color.cyan : Color.red;
    }
}
