using Chat;
using Chat.Credentials;
using Constants;
using UnityEngine;

namespace Data
{
    public static class PreferenceService
    {
        private static readonly ICredentials Credentials = new DebugCredentials();
        public static string GetUsername()
        {
            return Credentials.GetUsername();
        }

        public static string GetChannelName()
        {
            return Credentials.GetChannelName();
        }

        public static string GetToken()
        {
            return Credentials.GetToken();
        }

        public static string GetCommandPrefix()
        {
            var prefix = PlayerPrefs.GetString(Strings.CommandPrefixKey);
            if (!string.IsNullOrEmpty(prefix)) return prefix;
            SetCommandPrefix(Strings.DefaultPrefix);
            return Strings.DefaultPrefix;
        }

        public static void SetUsername(string username)
        {
            PlayerPrefs.SetString(Strings.UsernameKey, username);
        }

        public static void SetChannelName(string channelName)
        {
            PlayerPrefs.SetString(Strings.ChannelKey, channelName);
        }

        public static void SetToken(string token)
        {
            PlayerPrefs.SetString(Strings.TokenKey, token);
        }

        public static void SetCommandPrefix(string prefix)
        {
            PlayerPrefs.SetString(Strings.CommandPrefixKey, prefix);
        }
    }
}
