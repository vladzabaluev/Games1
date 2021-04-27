using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cucumber : MonoBehaviour
{
    private Transform player;

    public AudioSource gameOverSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
              
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x-3f > transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
       
            gameOverSound.Play();  
           Invoke(nameof(ReloadLevel), 0.2f);          
        }
     //  Destroy(gameObject);
    }

    void ReloadLevel()
    {
          
     //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }


}
