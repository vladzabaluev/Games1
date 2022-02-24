using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : HealthSystem
{
    public int maxHealthHero;
    Healthbar _playerHP;
    // Start is called before the first frame update
    void Start()
    {
        _playerHP = GameObject.FindGameObjectWithTag("HeroHP").GetComponent<Healthbar>();
        EnterHealth(maxHealthHero, _playerHP);
    }


    public override void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
