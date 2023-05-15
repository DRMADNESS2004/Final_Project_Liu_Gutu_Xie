using UnityEngine;
using UnityEngine.Audio;
using Assets;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioMixerGroup mixerGroup;

    public Sound[] sounds;

    private void Awake()
    {

        foreach (Sound s in sounds)
        {
            //including audio sources in each sound that we have
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, s => s.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound " + soundName + " not found!");
        }

        s.source.PlayOneShot(s.clip);
    }

    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, s => s.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound " + soundName + " not found!");
            return;
        }
        s.source.Stop();
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
