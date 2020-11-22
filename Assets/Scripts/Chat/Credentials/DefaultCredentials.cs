using Constants;
using UnityEngine;

namespace Chat.Credentials
{
    public class DefaultCredentials : ICredentials
    {
        public string GetChannelName()
        {
            return PlayerPrefs.GetString(Strings.ChannelKey);
        }

        public string GetToken()
        {
            return PlayerPrefs.GetString(Strings.TokenKey);
        }

        public string GetUsername()
        {
            return PlayerPrefs.GetString(Strings.UsernameKey);
        }
    }
}
