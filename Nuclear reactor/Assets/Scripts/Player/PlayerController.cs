using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController playerController;
    Animator anim;
    public float speed = 6f;

    float smoothSpeed;
    public float smoothTime = 0.1f;

    public float gravity = -9.81f;
    Vector3 velocity;

    public bool isGrounded;
    public float maxHeightJump = 10f;

    Transform mainCam;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        mainCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float movingDirectionX = Input.GetAxisRaw("Horizontal");
        float movingDirectionZ = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(movingDirectionX, 0, movingDirectionZ).normalized;

        anim.SetFloat("Speed", direction.magnitude);

        if (direction.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + mainCam.eulerAngles.y;
            float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref smoothSpeed, smoothTime);
            transform.rotation = Quaternion.Euler(0, smoothedAngle, 0);

            Vector3 newDir = Quaternion.Euler(0, smoothedAngle, 0) * Vector3.forward;

            playerController.Move(newDir * speed * Time.deltaTime);

        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(maxHeightJump * -2 * gravity);
        }

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }


        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);

    }
}
