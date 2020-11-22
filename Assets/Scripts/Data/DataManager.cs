using UnityEngine;

public class DataManager
{
    private static DataManager instance;

    private readonly string usernameKey = "USERNAME";
    private readonly string channelKey = "CHANNEL";
    private readonly string tokenKey = "TOKEN";
    private readonly string commandPrefixKey = "COMMAND_PREFIX";
    private readonly string defaultPrefix = "!arcade";

    private readonly ICredentials credentials = new DebugCredentials();

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DataManager();
            }

            return instance;
        }
    }

    #region credentials
    public string GetUsername()
    {
        return credentials.GetUsername();
    }

    public string GetChannelName()
    {
        return credentials.GetChannelName();
    }

    public string GetToken()
    {
        return credentials.GetToken();
    }

    public string GetCommandPrefix()
    {
        string prefix = PlayerPrefs.GetString(commandPrefixKey);
        if (string.IsNullOrEmpty(prefix))
        {
            SetUsername(defaultPrefix);
            return defaultPrefix;
        }

        return prefix;
    }

    public void SetUsername(string username)
    {
        PlayerPrefs.SetString(usernameKey, username);
    }

    public void SetChannelName(string channelName)
    {
        PlayerPrefs.SetString(channelKey, channelName);
    }

    public void SetToken(string token)
    {
        PlayerPrefs.SetString(tokenKey, token);
    }

    public void SetCommandPrefix(string prefix)
    {
        PlayerPrefs.SetString(commandPrefixKey, prefix);
    }
    #endregion

    #region database
    public bool UserExists(string username)
    {
        // TODO: read from DB
        return false;
    }

    public void CreateUser(string username)
    {
        // TODO: write to DB
    }
    #endregion
}
