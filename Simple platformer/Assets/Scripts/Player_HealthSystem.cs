using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_HealthSystem : MonoBehaviour
{
    public Healthbar hp;

    public int maxHealth = 100;
    int currentHealth;

    Animator anim;
    //Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hp.SetMaxValue(maxHealth);

        anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int monstrDamage)
    {
        currentHealth -= monstrDamage;
        if (currentHealth <= 0)
        {
            Die();
        }
        hp.SetValue(currentHealth);
        anim.SetTrigger("underAttack"); //доделать шоб во время атаки не мог нихуя делать и откидывался, ходьба осьминогу и прыжки прыгуну
       
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
