using Chat;
using Chat.Credentials;
using Constants;
using UnityEngine;

namespace Data
{
    public class DataManager
    {
        private static DataManager _instance;
        private readonly ICredentials _credentials = new DebugCredentials();
        public static DataManager Instance => _instance ?? (_instance = new DataManager());

        #region credentials
        public string GetUsername()
        {
            return _credentials.GetUsername();
        }

        public string GetChannelName()
        {
            return _credentials.GetChannelName();
        }

        public string GetToken()
        {
            return _credentials.GetToken();
        }

        public string GetCommandPrefix()
        {
            var prefix = PlayerPrefs.GetString(Strings.CommandPrefixKey);
            if (!string.IsNullOrEmpty(prefix)) return prefix;
            SetCommandPrefix(Strings.DefaultPrefix);
            return Strings.DefaultPrefix;
        }

        public void SetUsername(string username)
        {
            PlayerPrefs.SetString(Strings.UsernameKey, username);
        }

        public void SetChannelName(string channelName)
        {
            PlayerPrefs.SetString(Strings.ChannelKey, channelName);
        }

        public void SetToken(string token)
        {
            PlayerPrefs.SetString(Strings.TokenKey, token);
        }

        public void SetCommandPrefix(string prefix)
        {
            PlayerPrefs.SetString(Strings.CommandPrefixKey, prefix);
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
}
