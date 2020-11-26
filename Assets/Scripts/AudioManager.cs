using System.Collections.Generic;
using UnityEngine;
using Data;
using Data.Entities;

public class AudioManager : MonoBehaviour, UserObserver
{
    public AudioSource backgroundSource;
    public AudioSource effectsSource;

    private static readonly Dictionary<string, AudioClip> Sounds = new Dictionary<string, AudioClip>();
    private float _musicLevel => PreferenceService.MusicLevel;
    private float _effectsLevel => PreferenceService.EffectsLevel;

    private enum SoundType
    {
        Click,
        Connected,
        Disconnected
    }

    void Awake()
    {
        UserManager.Instance.AddObserver(this);
    }

    private void OnDestroy()
    {
        UserManager.Instance.RemoveObserver(this);
    }

    private void Start()
    {
        UpdateBackgroundLevel();
    }

    public void UpdateBackgroundLevel()
    {
        float soundLevel = _musicLevel == 0 ? 0 : _musicLevel / 10;
        backgroundSource.volume = soundLevel;
    }

    public void PlayTestSound(int level)
    {
        PlaySound(SoundType.Click, level);
    }

    public void PlayClick()
    {
        PlaySound(SoundType.Click, _effectsLevel);
    }

    public void PlayConnected()
    {
        PlaySound(SoundType.Connected, _effectsLevel);
    }

    public void PlayDisconnected()
    {
        PlaySound(SoundType.Disconnected, _effectsLevel);
    }

    private void PlaySound(SoundType sound, float level)
    {
        var soundName = GetSoundName(sound);

        if (!Sounds.ContainsKey(soundName))
        {
            var audioClip = Resources.Load<AudioClip>(soundName);
            Sounds.Add(soundName, audioClip);
        }

        float soundLevel = level == 0 ? 0 : level / 10;
        PlaySFX(Sounds[soundName], soundLevel);
    }

    private void PlaySFX(AudioClip clip, float level)
    {
        effectsSource.PlayOneShot(clip, level);
    }

    private static string GetSoundName(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.Click: return "ClickSound";
            case SoundType.Connected: return "ConnectedSound";
            case SoundType.Disconnected: return "DisconnectedSound";
            default: return "ClickSound";
        }
    }

    public void OnUserJoined(List<ChatUser> users, ChatUser user)
    {
        PlayConnected();
    }

    public void OnUserLeft(List<ChatUser> users, ChatUser user)
    {
        PlayDisconnected();
    }
}
