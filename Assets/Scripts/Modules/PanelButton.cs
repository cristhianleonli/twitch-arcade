using UnityEngine;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    public PanelType panelType;

    private CanvasManager _canvasManager;
    private Button _button;
    private Image _image;

    private void Start()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _canvasManager = FindObjectOfType<CanvasManager>();

        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _canvasManager.OnButtonClicked(this);
    }

    public void SetSelected(bool value)
    {
        // TODO: set the correct sprite
    }
}
