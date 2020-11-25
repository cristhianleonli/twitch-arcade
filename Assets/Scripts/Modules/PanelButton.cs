using UnityEngine;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    public PanelType panelType;
    public Sprite normalImage;
    public Sprite selectedImage;

    private CanvasManager _canvasManager;
    private Button _button;
    private Image _image;

    private void Start()
    {
        _button = GetComponent<Button>();
        _canvasManager = FindObjectOfType<CanvasManager>();
        
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _canvasManager.OnButtonClicked(this);
        AudioManager.PlaySound(SoundType.Click);
    }

    public void SetSelected(bool value)
    {
        if (_image == null) _image = GetComponent<Image>();
        _image.sprite = value ? selectedImage : normalImage;
    }
}
