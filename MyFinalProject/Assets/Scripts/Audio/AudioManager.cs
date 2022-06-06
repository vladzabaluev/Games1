using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    public static AudioManager instanse;

    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
            sound.Source.spatialBlend = sound.SpatialBlend;
        }

        GlobalEventManager.OnPlayerDead.AddListener(PlayDeadSound);
        GlobalEventManager.OnPlayerDamaged.AddListener(PlayDamageSound);
    }

    //private void Start()
    //{
    //    PlaySound("Audio");
    //}

    private void PlaySound(string SoundName)
    {
        Sound s = Array.Find(Sounds, sound => sound.SoundName == SoundName);
        s.Source.Play();
    }

    private void PlayDeadSound()
    {
        PlaySound("Player Dead");
    }

    private void PlayDamageSound(int SomeVar = 0)
    {
        PlaySound("Player Damaged");
    }
}