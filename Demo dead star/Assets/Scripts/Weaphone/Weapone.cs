using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapone : MonoBehaviour
{
    public float maxDistance = 25f;
    public int damage = 5;
    public ParticleSystem hitEffect;

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
        //GameObject test = GameObject.Find("/MainCanvas/PatronsInfo");
        patrons = GameObject.Find("/MainCanvas/PatronsInfo").GetComponent<TMP_Text>();
        DisplayPatrons();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position,transform.forward, out hit, maxDistance))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<DamageSystem>().TakeDamage(damage);
                    Instantiate(hitEffect, hit.transform.position, hit.transform.rotation);
                    
                }
            }
            currentPatrons--;
            DisplayPatrons();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            DisplayPatrons();
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
