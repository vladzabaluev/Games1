using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public GameObject topPoint;
    public GameObject botPoint;

    public float speed, tilt, startTilt;

    public bool isVniz = true;
    
    public static int score = 0;
    public Text textScore;

    public Text GG;
    public Button restart;

    public GameObject deadEffect;

    public GameObject menu;
    RestartAndLosing ral;

    // Start is called before the first frame update
    void Start()
    {
        botPoint.transform.position = new Vector3(Random.Range(-0.8f, 0.8f), botPoint.transform.position.y, botPoint.transform.position.z);
        topPoint.transform.position = new Vector3(Random.Range(-0.8f, 0.8f), topPoint.transform.position.y, topPoint.transform.position.z);
        score = 0;
        startTilt = tilt;
        ral = menu.GetComponent<RestartAndLosing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isVniz)
        {
            transform.position = Vector2.MoveTowards(transform.position, botPoint.transform.position, speed * Time.deltaTime);
        } 
        else
        { 
            transform.position = Vector2.MoveTowards(transform.position, topPoint.transform.position, speed * Time.deltaTime);            
        }
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + tilt);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            deadEffect.transform.position = gameObject.transform.position;
            deadEffect.SetActive(true);
            gameObject.SetActive(false);
            ral.Losing();
        }
        if (other.CompareTag("TopPoint"))
        {
            botPoint.transform.position = new Vector3
                (Random.Range(-0.8f, 0.8f), botPoint.transform.position.y, botPoint.transform.position.z);
            topPoint.gameObject.SetActive(false); //двигаемся от точки к точки 
            botPoint.gameObject.SetActive(true); //в зависимости от того, к какой точке двигаемся выключаем
                                                 //противоположную точку
            score++; //перевод из инта в текст на экране
            string scr = score.ToString();
            textScore.text = scr;
        }
        if (other.CompareTag("BotPoint"))
        {
            topPoint.transform.position = new Vector3(Random.Range(-0.8f, 0.8f), topPoint.transform.position.y, topPoint.transform.position.z);
            topPoint.gameObject.SetActive(true);
            botPoint.gameObject.SetActive(false);

            score++; //перевод из инта в текст на экране
            string scr = score.ToString();
            textScore.text = scr;
        }
        Tap();
    }
    public void Tap()
    {
        isVniz = !isVniz;
    }

    
}
