using DG.Tweening;
using UnityEngine;

public class SettingsCanvas : MonoBehaviour
{
    public SettingsPanel settingsPanel;
    public GameObject background;
    
    private void Start()
    {
        settingsPanel.OnCloseTapped(Hide);
        settingsPanel.transform.localScale = new Vector3(0, 0, 0);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        var scale = 0f;
        DOTween
            .To(() => 0, x => scale = x, 1, 0.3f)
            .SetEase(Ease.OutBack, 0.1f)
            .OnUpdate(() => settingsPanel.transform.localScale = new Vector3(scale, scale, scale));
    }

    private void Hide() {
        settingsPanel.transform
            .DOScale(0, 0.2f)
            .OnComplete(() => 
                gameObject.SetActive(false)
                );
    }
}
