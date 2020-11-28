using UnityEngine;
using UnityEngine.UI;

public class ArcheryCanvas : MonoBehaviour
{

    [SerializeField] private Button button;
    private ArcheryController _controller;
    private void Start()
    {
        _controller = FindObjectOfType<ArcheryController>();
        button.onClick.AddListener(OnGameStart);
    }

    private void OnGameStart()
    {
        _controller.OnGameStart();
    }
}
