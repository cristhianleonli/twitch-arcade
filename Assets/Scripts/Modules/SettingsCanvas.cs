using UnityEngine;

public class SettingsCanvas : MonoBehaviour
{
    public SettingsPanel settingsPanel;
    private void Start()
    {
        settingsPanel.OnCloseTapped(Hide);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}
