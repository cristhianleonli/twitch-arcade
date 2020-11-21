using UnityEngine;
using TwitchChatConnect.Config;

public class DataManager : MonoBehaviour
{
    [SerializeField] public TwitchConnectData connectData;
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
        return connectData.TwitchConnectConfig.Username;
    }

    public string GetToken()
    {
        return connectData.TwitchConnectConfig.UserToken;
    }

    public string GetChannelName()
    {
        return connectData.TwitchConnectConfig.ChannelName;
    }
}
