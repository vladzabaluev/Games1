using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PS : MonoBehaviour
{
    public GameObject topPoint;
    public GameObject botPoint;
    public GameObject Hero;

    float speed;
    bool isVniz;

    // Start is called before the first frame update
    void Start()
    {
        speed = Hero.GetComponent<Hero>().speed;
        isVniz = Hero.GetComponent<Hero>().isVniz;
    }

    // Update is called once per frame
    void Update()
    {
        isVniz = Hero.GetComponent<Hero>().isVniz;
        if (isVniz)
        {
            transform.position = Vector2.MoveTowards(transform.position, botPoint.transform.position, speed * Time.deltaTime);
            transform.LookAt(botPoint.transform);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, topPoint.transform.position, speed * Time.deltaTime);
            transform.LookAt(topPoint.transform);
        }
    }
}
