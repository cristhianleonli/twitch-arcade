using System;
using TMPro;
using UnityEngine;

public class ArcherCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TitleText;

    public void SetTitle(string title)
    {
        TitleText.text = title;
    }
}
