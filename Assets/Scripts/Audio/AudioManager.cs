using System.Collections.Generic;
using Audio;
using UnityEngine;
using Data;
using Data.Entities;

public class AudioManager : MonoBehaviour, UserObserver
{
    public AudioSource backgroundSource;
    public AudioSource effectsSource;
    private float _musicLevel => PreferenceService.MusicLevel;
    private float _effectsLevel => PreferenceService.EffectsLevel;

    [SerializeField] private AudioData audioData;

    private void Awake()
    {
        UserManager.Instance.AddObserver(this);
    }

    private void OnDestroy()
    {
        UserManager.Instance.RemoveObserver(this);
    }

    private void Start()
    {
        SetupAudioSources();
        UpdateBackgroundLevel();
    }
    
    private void SetupAudioSources()
    {
        backgroundSource.clip = audioData.backgroundLoop;
        backgroundSource.loop = true;
    }
        
    public void UpdateBackgroundLevel()
    {
        var soundLevel = _musicLevel == 0 ? 0 : _musicLevel / 10;
        backgroundSource.volume = soundLevel;
    }

    public void PlayTestSound(int level)
    {
        PlaySound(audioData.click, level);
    }

    public void PlayClick()
    {
        PlaySound(audioData.click, _effectsLevel);
    }

    public void PlayConnected()
    {
        PlaySound(audioData.userConnected, _effectsLevel);
    }

    public void PlayDisconnected()
    {
        PlaySound(audioData.userDisconnected, _effectsLevel);
    }

    private void PlaySound(AudioClip audioClip, float level)
    {
        var soundLevel = level == 0 ? 0 : level / 10;
        effectsSource.PlayOneShot(audioClip, soundLevel);
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
