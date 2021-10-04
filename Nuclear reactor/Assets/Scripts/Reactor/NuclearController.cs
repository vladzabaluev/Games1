using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NuclearController : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public float powerOfEat = 10f;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        health -= Time.deltaTime;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Eat for reactor"))
        {
            if (health < maxHealth - powerOfEat)
            {
                health += powerOfEat;
            }
            else if (health < maxHealth && health > maxHealth - powerOfEat) 
            {
                health = maxHealth;
            }

            other.GetComponent<MoveEat>().newHole();
        }

    }
}
