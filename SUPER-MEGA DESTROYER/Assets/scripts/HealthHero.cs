using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthHero : MonoBehaviour
{
    public int health;
    public int numberOfLives;

    public Image[] lives;
    public Sprite fullLife;
    public Sprite nullLife;

    void Update()
    {
        if (health > numberOfLives)
        {
            health = numberOfLives;
        }
        if (health<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLife;
            }
            else
            {
                lives[i].sprite = nullLife;
            }

            if (i < numberOfLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("BombOrBul"))
        {
            health--;
        }
        if (collider.CompareTag("EndLVL"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
