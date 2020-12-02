using UnityEngine;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    //public PanelType panelType;
    //public Sprite normalImage;
    //public Sprite selectedImage;

    public delegate void OnClickCallback();
    private OnClickCallback _clickCallback;

    private CanvasManager _canvasManager;
    private AudioManager _audioManager;
    private Button _button;
    private Image _image;

    private void Start()
    {
        _button = GetComponent<Button>();
        _canvasManager = FindObjectOfType<CanvasManager>();
        _audioManager = FindObjectOfType<AudioManager>();

        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void OnClick()
    {
        _audioManager.PlayClick();

        if (_clickCallback != null)
        {
            _clickCallback();
        }
    }

    public void SetAction(OnClickCallback onClickCallback) {
        _clickCallback = onClickCallback;
    }

    //public void SetSelected(bool value)
    //{
    //    if (_image == null) _image = GetComponent<Image>();
    //    _image.sprite = value ? selectedImage : normalImage;
    //}
}
