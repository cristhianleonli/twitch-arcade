using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "AudioData", menuName = "Arcade/AudioData", order = 1)]

    public class AudioData : ScriptableObject
    {
        public AudioClip click;
        public AudioClip userConnected;
        public AudioClip userDisconnected;
        public AudioClip backgroundLoop;
    }
}
