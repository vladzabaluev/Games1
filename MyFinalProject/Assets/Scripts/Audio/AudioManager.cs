using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound ThemeSound;

    public static AudioManager instanse;

    public static float MusicVolume = 0.3f;

    public static float SFX_Volume = 0.3f;

    private static AudioSource audioSource;

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

        //foreach (Sound sound in Sounds)
        //{
        //    sound.Source = gameObject.AddComponent<AudioSource>();
        //    sound.Source.clip = sound.Clip;
        //    sound.Source.volume = sound.Volume;
        //    sound.Source.pitch = sound.Pitch;
        //    sound.Source.loop = sound.Loop;
        //    sound.Source.spatialBlend = sound.SpatialBlend;
        //}

        //GlobalEventManager.OnPlayerDead.AddListener(PlayDeadSound);
        //GlobalEventManager.OnPlayerDamaged.AddListener(PlayDamageSound);
        audioSource = GetComponent<AudioSource>();
    }

    public static void SetAudioSource(string SoundName, Sound[] sounds, AudioSource audioSource, bool PlayOneShot, bool isSoundMusic)
    {
        Sound necessarySound = Array.Find(sounds, sound => sound.SoundName == SoundName);
        if (necessarySound == null)
        {
            Debug.LogError("Sound " + SoundName + " not found");
        }
        else
        {
            audioSource.clip = necessarySound.Clip;
            if (isSoundMusic)
                audioSource.volume = necessarySound.Volume * MusicVolume;
            else
                audioSource.volume = necessarySound.Volume * SFX_Volume;

            audioSource.pitch = necessarySound.Pitch;
            audioSource.loop = necessarySound.Loop;
            audioSource.spatialBlend = necessarySound.SpatialBlend;
            if (PlayOneShot)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
            else
            {
                audioSource.Play();
            }
        }
    }

    public static void PlaySound(Sound sound, AudioSource audioSource, bool fullPlaySound, bool isSoundMusic)
    {
        audioSource.clip = sound.Clip;
        if (isSoundMusic)
            audioSource.volume = sound.Volume * MusicVolume;
        else
            audioSource.volume = sound.Volume * SFX_Volume;
        audioSource.pitch = sound.Pitch;
        audioSource.loop = sound.Loop;
        audioSource.spatialBlend = sound.SpatialBlend;
        if (fullPlaySound)
        {
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(audioSource.clip);
        }
        else
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    public static void ChangeMainMusicVolume() //FIXIT
    {
        audioSource.volume = MusicVolume;
    }
}