using System.Resources;
using Chat;
using Chat.Credentials;
using Constants;
using UnityEngine;

namespace Data
{
    public static class PreferenceService
    {
        private static readonly ICredentials Credentials = new DebugCredentials();

        public static string Username
        {
            get => Credentials.GetUsername();
            set => PlayerPrefs.SetString(Strings.UsernameKey, value);
        }
        
        public static string ChannelName
        {
            get => Credentials.GetChannelName();
            set => PlayerPrefs.SetString(Strings.ChannelKey, value);
        }

        public static string Token
        {
            get => Credentials.GetToken();
            set => PlayerPrefs.SetString(Strings.TokenKey, value);
        }

        public static int MusicLevel
        {
            get => PlayerPrefs.GetInt(Strings.MusicLevelKey);
            set => PlayerPrefs.SetInt(Strings.MusicLevelKey, value);
        }
        
        public static int EffectsLevel
        {
            get => PlayerPrefs.GetInt(Strings.EffectsLevelKey);
            set => PlayerPrefs.SetInt(Strings.EffectsLevelKey, value);
        }
        
        public static string CommandPrefix
        {
            get
            {
                var prefix = PlayerPrefs.GetString(Strings.CommandPrefixKey);
                if (!string.IsNullOrEmpty(prefix)) return prefix;
                
                CommandPrefix = Strings.DefaultPrefix;
                return Strings.DefaultPrefix;
            } 
            set => PlayerPrefs.SetString(Strings.CommandPrefixKey, value);
        }
    }
}
