using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapone : MonoBehaviour
{
    public float maxDistance = 25f;
    public int damage = 5;
    public ParticleSystem hitEffect;

    AudioSource _audioSource;
    public AudioClip Click;
    public AudioClip Rel;

    int currentPatrons;
    public int clip;
    int allPatrons;
    public int maxBul;

    private TMP_Text patrons;
    // Start is called before the first frame update
    private void Start()
    {
        currentPatrons = clip;
        allPatrons = maxBul;
        patrons = GameObject.Find("/MainCanvas/PatronsInfo").GetComponent<TMP_Text>();
        _audioSource = GetComponent<AudioSource>();
        DisplayPatrons();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (currentPatrons > 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
                {
                    if (hit.transform.CompareTag("Enemy"))
                    {
                        hit.transform.GetComponent<DamageSystem>().TakeDamage(damage);
                        Instantiate(hitEffect, hit.transform.position, hit.transform.rotation);
                        }
                }
                _audioSource.PlayOneShot(Click);
                currentPatrons--;
                DisplayPatrons();
            }
            else
            {
                Reload();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public bool topUpPatrons(int addingPatrons)
    {
        if (allPatrons < maxBul)
        {
            if (allPatrons + addingPatrons <= maxBul)
            {
                allPatrons += addingPatrons;
            }
            else
            {
                allPatrons = maxBul;
            }
            DisplayPatrons();
            return true;
        }
        else
        {
            return false;
        }
       
       
    }

    void Reload()
    {
        if (currentPatrons < clip)
        {
            _audioSource.PlayOneShot(Rel);
            if (allPatrons < clip)
            {
                currentPatrons += allPatrons;
                allPatrons = 0;
            }
            else
            {
                allPatrons -= (clip - currentPatrons);
                currentPatrons = clip;
            }
        }
        DisplayPatrons();
    }

    void DisplayPatrons()
    {
        patrons.text = currentPatrons + " / " + allPatrons;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
    }
}

