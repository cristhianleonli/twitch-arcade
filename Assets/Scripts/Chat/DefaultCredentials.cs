using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCredentials : ICredentials
{
    private readonly string usernameKey = "USERNAME";
    private readonly string channelKey = "CHANNEL";
    private readonly string tokenKey = "TOKEN";

    public string GetChannelName()
    {
        return PlayerPrefs.GetString(channelKey);
    }

    public string GetToken()
    {
        return PlayerPrefs.GetString(tokenKey);
    }

    public string GetUsername()
    {
        return PlayerPrefs.GetString(usernameKey);
    }
}
