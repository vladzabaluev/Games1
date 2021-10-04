using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSmth : MonoBehaviour
{
    public float radius = 0.4f;
    public LayerMask throwThings;

    int eat, playerMask;

    public bool isCarries;

    GameObject player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        eat = LayerMask.NameToLayer("Reactor's eat");
        playerMask = LayerMask.NameToLayer("Player");

        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCarries = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {            
            BackToDefault();
            isCarries = false;
        }


        if (isCarries)
        {
           
            Carry();
            if (Input.GetMouseButtonDown(1))
            {
                isCarries = false;
                Collider[] hittedThings = Physics.OverlapSphere(transform.position, radius, throwThings);
                foreach (Collider thing in hittedThings)
                {
                    thing.GetComponent<EatLikeBullet>().Throw();
                }

            }          

        }
    }

    void Carry()
    {
        anim.SetBool("isCarried", true);
        Collider[] hittedThings = Physics.OverlapSphere(transform.position, radius, throwThings);
        foreach (Collider thing in hittedThings)
        {
            thing.transform.position = transform.position;
            Physics.IgnoreLayerCollision(playerMask, eat, true);
            thing.transform.rotation = Quaternion.Euler(Vector3.up);
        }
    }

    void BackToDefault()
    {
        Collider[] hittedThings = Physics.OverlapSphere(transform.position, radius, throwThings);
        foreach (Collider thing in hittedThings)
        {
            Physics.IgnoreLayerCollision(playerMask, eat, false);
        }
        anim.SetBool("isCarried", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}


