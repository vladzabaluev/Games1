using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Animator anim;
    public GameObject Hero;

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
        anim.SetBool("isJump", false);
        Hero.GetComponent<Player>().canJump = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Hero.GetComponent<Player>().canJump = false;
    }
}
