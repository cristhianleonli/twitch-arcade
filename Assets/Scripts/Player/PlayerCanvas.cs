using System;
using TMPro;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PlayerTitleText;

    public void SetTitle(string title)
    {
        PlayerTitleText.text = title;
    }
}
