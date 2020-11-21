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
        return "";
    }

    public string GetChannelName()
    {
        return "";
    }

    public string GetToken()
    {
        return "";
    }
}
