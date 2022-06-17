using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;

    [SerializeField]
    private int currentHP;

    public int CurrentHealth { get; private set; }

    public Sound[] Sounds;

    protected AudioSource audioSource;

    private void Awake()
    {
        CurrentHealth = maxHealth;
        Debug.Log(CurrentHealth);
        currentHP = CurrentHealth;

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        currentHP = CurrentHealth;

        Debug.Log(transform.name + " takes " + damage);

        if (CurrentHealth <= 0)
        {
            Die();
        }
        else
        {
            AudioManager.SetAudioSource("Damaged", Sounds, audioSource, true, false);
        }
    }

    public virtual void Die()
    {
    }
}