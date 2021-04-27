using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player; 
    public Vector2 offset = new Vector2(2f, 1f);

    private float TimeRespawnOfKaktys; //

    public int scoreCount;
    private float TimeScore;
    public float StartTimeScore;


    public Transform respawn1; //
    public Transform respawn2; //
    public Transform respawn3;  //
    public Transform respawn4; //

    public GameObject Obstacles;  //
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        if (TimeScore <= 0)
        {
            scoreCount += 1;
            TimeScore = StartTimeScore;
        }
        else
        {
            TimeScore -= Time.deltaTime;
        }
        if (scoreCount < 50)
        {
            if (TimeRespawnOfKaktys <= 0)
            {
                Instantiate(Obstacles, respawn1.position, respawn1.rotation);
                Instantiate(Obstacles, respawn3.position, respawn3.rotation);
                float StartTime = 5;
                TimeRespawnOfKaktys = StartTime;
            }
            else
            {                    
                TimeRespawnOfKaktys -= Time.deltaTime;               
            }
        }
        else
        {
            if (TimeRespawnOfKaktys <= 0)
            {
                Instantiate(Obstacles, respawn2.position, respawn2.rotation);
                Instantiate(Obstacles, respawn4.position, respawn4.rotation);
                float NewStartTime = 3;
                TimeRespawnOfKaktys = NewStartTime;
            }
            else
            {
                TimeRespawnOfKaktys -= Time.deltaTime;
            }
        } 
    

    }
}
