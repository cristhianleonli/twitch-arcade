using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCanvas : MonoBehaviour
{
    [SerializeField] private SettingsPanel settingsPanel;
    [SerializeField] private GameObject background;

    private void Start()
    {
        settingsPanel.OnCloseTapped(Hide);
        settingsPanel.transform.localScale = new Vector3(0, 0, 0);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        DOTween.Sequence()
            .Append(
                settingsPanel.transform.DOScale(1.15f, 0.2f)
            )
            .Append(
                settingsPanel.transform.DOScale(1, 0.1f)
            );
    }

    private void Hide()
    {
        DOTween.Sequence()
            .Append(
                settingsPanel.transform.DOScale(1.15f, 0.2f)
            )
            .Append(
                settingsPanel.transform.DOScale(0.8f, 0.1f)
            )
            .OnComplete(() => gameObject.SetActive(false));
    }
}
