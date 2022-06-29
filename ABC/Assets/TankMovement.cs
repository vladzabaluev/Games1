using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rb;
    float moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * moveDirection * Time.deltaTime, rb.velocity.y);
    }
}
