using UnityEngine;
using UnityEngine.UI;

public delegate void OnClickCallback();

public class PanelButton : MonoBehaviour
{
    private OnClickCallback _clickCallback;
    private AudioManager _audioManager;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
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
        _clickCallback?.Invoke();
    }

    public void SetAction(OnClickCallback onClickCallback) {
        _clickCallback = onClickCallback;
    }
}
