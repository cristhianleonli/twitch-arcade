using UnityEngine;

public class Archer : MonoBehaviour
{
    private ArcherData _playerData;
    private ArcherCanvas _playerCanvas;

    public string Identifier => _playerData.Nickname;

    private void Awake()
    {
        _playerCanvas = GetComponentInChildren<ArcherCanvas>();
    }

    public void Init(ArcherData playerData)
    {
        _playerData = playerData;
        UpdateTitle();
        UpdateSprite();
    }

    public void SetState(ArcheryState state)
    {
        switch (state)
        {
            case ArcheryState.Lobby:
                // start random-moving routine
                break;
            case ArcheryState.Gameplay:
                // stop the moving routine, but not lock movement
                break;
            case ArcheryState.Results:
                // lock movement
                break;
        }
    }

    public void MoveLeft(int units)
    {
        
    }
    
    public void MoveRight(int units)
    {
        
    }

    public void Shoot(int angle)
    {
        
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

/*
 !left => player moves x units to the left
 !left 4 => player moves 4 units to the left
 
 enum ArcherState {
    Idle
    MoveLeft
    MoveRight
    Sit
 }
*/