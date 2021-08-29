using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CheckGround : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy.GetComponent<Jumper_Controller>().canEnemyJump = true;
        Enemy.GetComponent<Animator>().SetBool("isJumped", false);
    }
}
