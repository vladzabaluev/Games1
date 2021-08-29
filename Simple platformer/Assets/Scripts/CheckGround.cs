using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        player.GetComponent<PlayerMovement>().canWeJump = true;
        player.GetComponent<Animator>().SetBool("isJumped", false);
    }

    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerMovement>().canWeJump = false;
    }
}
