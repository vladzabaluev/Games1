using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOneTime : MonoBehaviour
{
    public Sound deadSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        AudioManager.PlaySound(deadSound, audioSource, false, false);
    }
}