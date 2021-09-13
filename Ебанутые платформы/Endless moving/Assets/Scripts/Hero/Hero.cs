using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hero : MonoBehaviour
{
    public GameObject topPoint;
    public GameObject botPoint;

    public float speed, tilt;

    public bool isVniz = true;

    public GameObject deadEffect;

    GameObject score;
    public float leftSiteOfGameArea = -0.8f;
    float rightSiteOfGameArea;
    // Start is called before the first frame update
    void Start()
    {
        rightSiteOfGameArea = -leftSiteOfGameArea;
        botPoint.transform.position = new Vector3(Random.Range(leftSiteOfGameArea, rightSiteOfGameArea), 
            botPoint.transform.position.y, botPoint.transform.position.z);
        topPoint.transform.position = new Vector3(Random.Range(leftSiteOfGameArea, rightSiteOfGameArea), 
            topPoint.transform.position.y, topPoint.transform.position.z);
        score = GameObject.FindGameObjectWithTag("Score");
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
        transform.Rotate(0, 0, tilt*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Lose();
        }
        if (other.CompareTag("TopPoint"))
        {
            botPoint.transform.position = new Vector3
                (Random.Range(leftSiteOfGameArea, rightSiteOfGameArea), botPoint.transform.position.y, botPoint.transform.position.z);
            topPoint.gameObject.SetActive(false); //двигаемся от точки к точки 
            botPoint.gameObject.SetActive(true); //в зависимости от того, к какой точке двигаемся выключаем
                                                 //противоположную точку

            score.GetComponent<Score>().addPoint();//добавляем очко
        }
        if (other.CompareTag("BotPoint"))
        {
            topPoint.transform.position = new Vector3
                (Random.Range(leftSiteOfGameArea, rightSiteOfGameArea), topPoint.transform.position.y, topPoint.transform.position.z);
            topPoint.gameObject.SetActive(true);
            botPoint.gameObject.SetActive(false);

            score.GetComponent<Score>().addPoint();//добавляем очко
        }
        Tap();
    }
    public void Tap()
    {
        isVniz = !isVniz;
    }

    void Lose()
    {
        deadEffect.transform.position = gameObject.transform.position;
        deadEffect.SetActive(true);
        gameObject.SetActive(false);
        //Invoke(nameof(Restart), 0.5f);
        Invoke(nameof(PauseMenu.Restart), 0.5f);
    }
    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
