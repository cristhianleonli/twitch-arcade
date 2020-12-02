using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameListPanel : MonoBehaviour
{
    public Button archeryButton;

    void Start()
    {
        archeryButton.onClick.AddListener(OnArcheryButton);
    }

    void Update()
    {
        
    }

    private void OnArcheryButton()
    {
        SceneManager.LoadScene(ArcheryController.SceneName, LoadSceneMode.Single);
    }
}