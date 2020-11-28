using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerData _playerData;
    private PlayerCanvas _playerCanvas;

    public string Identifier => _playerData.Nickname;

    private void Awake()
    {
        _playerCanvas = GetComponentInChildren<PlayerCanvas>();
    }

    public void Init(PlayerData playerData)
    {
        _playerData = playerData;
        UpdateTitle();
        UpdateSprite();
    }

    private void UpdateTitle()
    {
        _playerCanvas.SetTitle(_playerData.Nickname);
    }

    private void UpdateSprite()
    {
        // TODO: Set a special sprite depending on the player score
    }
}
