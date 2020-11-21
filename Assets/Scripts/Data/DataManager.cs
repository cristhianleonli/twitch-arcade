using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string GetUsername()
    {
        // TODO: CHeck for this data into the database
        return "";
    }

    public string GetToken()
    {
        return "";
    }

    public string GetChannelName()
    {
        return "";
    }
}
