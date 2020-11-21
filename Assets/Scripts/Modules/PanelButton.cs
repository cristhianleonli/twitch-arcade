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

    private void Awake()
    {
        image = GetComponent<Image>();
        button= GetComponent<Button>();
        canvasManager = FindObjectOfType<CanvasManager>();
    }

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        canvasManager.OnButtonClicked(this);
    }

    public void SetSelected(bool value)
    {
        image.color = value ? Color.red : Color.white;
    }
}
