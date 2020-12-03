using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TransitionsCanvas : MonoBehaviour
{
    [SerializeField] private GameObject leftPanel;
    [SerializeField] private GameObject rightPanel;

    private RectTransform leftTransform;
    private RectTransform rightTransform;

    private void Start()
    {
        leftTransform = leftPanel.GetComponent<RectTransform>();
        rightTransform = rightPanel.GetComponent<RectTransform>();
    }

    public void MoveOut()
    {
        
    }

    public void MoveIn(OnClickCallback callback)
    {
        gameObject.SetActive(true);
        leftTransform.position = new Vector3(-600, leftTransform.position.y, leftTransform.position.z);
        rightTransform.position = new Vector3(600, rightTransform.position.y, rightTransform.position.z);

        leftTransform
            // .DOMoveX(-500, 0)
            .DOMoveX(0, 0.5f)
            .OnComplete(() => callback?.Invoke());
    }
}
