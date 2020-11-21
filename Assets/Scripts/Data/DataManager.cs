using UnityEngine;

public class DataManager
{
    private static DataManager instance;

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

    public string GetUsername()
    {
        // TODO: read from user prefs
        return "";
    }

    public string GetChannelName()
    {
        // TODO: read from user prefs
        return "";
    }

    public string GetToken()
    {
        // TODO: read from user prefs
        return "";
    }

    public void SetToken(string token)
    {
        // TODO: save to Player pref
    }

    public void SetChannelName(string channelName)
    {
        // TODO: save to Player pref
    }

    public void SetUsername(string username)
    {
        // TODO: save to Player pref
    }

    public bool UserExists(string username)
    {
        // TODO: read from DB
        return false;
    }

    public void CreateUser(string username)
    {
        // TODO: write to DB
    }

    public string GetCommandPrefix()
    {
        // TODO: read from DB
        return "!arcade";
    }
}
