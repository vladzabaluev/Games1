using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    private Volume playerVolume;
    private Vignette playerVignette;

    [SerializeField]
    private float _timeOfShowing;

    [SerializeField]
    private float _vignetteIntensiv;

    private float startVignetteIntensiv;

    private void Start()
    {
        GlobalEventManager.SendPlayerDamaged(CurrentHealth);

        playerVolume = GetComponent<Volume>();
        playerVolume.profile.TryGet<Vignette>(out playerVignette);

        startVignetteIntensiv = playerVignette.intensity.value;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        GlobalEventManager.SendPlayerDamaged(CurrentHealth);
        StartCoroutine(DamageEffect());
    }

    private IEnumerator DamageEffect()
    {
        playerVignette.intensity.value = _vignetteIntensiv;
        yield return new WaitForSeconds(_timeOfShowing);
        playerVignette.intensity.value = startVignetteIntensiv;
    }

    public override void Die()
    {
        AudioManager.SetAudioSource("Dead", Sounds, audioSource, false, false);
        base.Die();
        GlobalEventManager.SendPlayerDead();
    }
}