using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCanvas : MonoBehaviour
{
    public SettingsPanel settingsPanel;
    public GameObject background;

    private Image backgroundImage;

    private void Start()
    {
        settingsPanel.OnCloseTapped(Hide);
        backgroundImage = background.GetComponent<Image>();
        settingsPanel.transform.localScale = new Vector3(0, 0, 0);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        var color = Color.black;
        color.a = 0.5f;
        backgroundImage.DOColor(color, 0.3f);

        DOTween.Sequence()
            .Append(
                settingsPanel.transform
                    .DOScale(1, 0.3f)
                    .SetEase(Ease.OutBack, 0.1f)
            );
    }

    private void Hide() {
        DOTween.Sequence()
            .Append(
                settingsPanel.GetComponent<RectTransform>()
                    .DOScale(0.9f, 0.3f)
                    .OnComplete(() => gameObject.SetActive(false))
            );


        backgroundImage.DOColor(Color.clear, 0.3f);
    }
}
