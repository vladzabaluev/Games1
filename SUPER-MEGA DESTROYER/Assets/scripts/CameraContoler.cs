using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoler : MonoBehaviour
{
    public float delay=1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool isLeft;

    private Transform player;
    private int lastX;

    public float leftLimit;
    public float rightLimit;
    public float bottomLimit;
    public float upperLimit;


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX)
            {
                isLeft = false;
            }
            else if (currentX < lastX)
            {
                isLeft = true;
            }
            lastX = Mathf.RoundToInt(player.position.x);
            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, delay * Time.deltaTime);
            transform.position = currentPosition;
            
        }
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z
            );
    }

    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z) ;
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector2(leftLimit-15, bottomLimit ), new Vector2(leftLimit-15, upperLimit + 8));
        Gizmos.DrawLine(new Vector2(rightLimit + 15, bottomLimit ), new Vector2(rightLimit + 15, upperLimit + 8)) ;
        Gizmos.DrawLine(new Vector2(leftLimit - 15, upperLimit + 8), new Vector2(rightLimit + 15, upperLimit + 8));
    }
}
