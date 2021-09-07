using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int min = 2;
    float sec = 0;

    public Text minutes;
    public Text points;
    public Text seconds;

    public Text GoalToWin;
    public Check check;
    // Start is called before the first frame update
    void Start()
    {
        minutes.text = min.ToString();
        seconds.text = sec.ToString();
    }

    // Update is called once per frame
    void Update()
    {     
        if (min < 0)
        {
            check.FinalScore();
        }
        else
        {
            sec -= Time.deltaTime;
            if (Mathf.Round(sec) <= 9)
            {
                seconds.text = "0" + Mathf.Round(sec).ToString();
                if (sec <= 0)
                {
                    sec = 59;
                    min--;
                    minutes.text = min.ToString();
                }

            }
            else
            {
                seconds.text = Mathf.Round(sec).ToString();
            }

        }
       

    }
}
