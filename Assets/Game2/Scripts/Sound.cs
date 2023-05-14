using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(0f, 1f)]
        public float volumeVariance;

        [Range(0f, 3f)]
        public float pitch;

        [Range(0f, 1f)]
        public float pitchVariance;

        public bool loop = true;
        public AudioMixerGroup mixerGroup;

        [HideInInspector]
        public AudioSource source;
    }
}
