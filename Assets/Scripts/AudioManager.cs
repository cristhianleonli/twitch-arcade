using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SoundType
{
    Click,
    Connected,
    Disconnected
}

public class AudioManager : MonoBehaviour
{
    private static AudioSource _audioSource;
    private static readonly Dictionary<string, AudioClip> Sounds = new Dictionary<string, AudioClip>();
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound)
    {
        var soundName = GetSoundName(sound);
        
        if (!Sounds.ContainsKey(soundName))
        {
            var audioClip = Resources.Load<AudioClip>(soundName);
            Sounds.Add(soundName, audioClip);
        }

        _audioSource.PlayOneShot(Sounds[soundName]);
    }

    private static string GetSoundName(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.Click:
                return "ClickSound";
            case SoundType.Connected:
                return "ConnectedSound";
            case SoundType.Disconnected:
                return "DisconnectedSound";
        }

        return "ClickSound";
    }
}
