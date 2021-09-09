using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThroughPlatforms : MonoBehaviour
{
    public bool isLadder;
    int playerMask, groundMask;
    // Start is called before the first frame update
    void Start()
    {
        playerMask = LayerMask.NameToLayer("Player");
        groundMask = LayerMask.NameToLayer("Ground");
        Physics2D.IgnoreLayerCollision(playerMask, groundMask, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLadder)
        {
            Physics2D.IgnoreLayerCollision(playerMask, groundMask, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerMask, groundMask, false);
        }

    }

}
