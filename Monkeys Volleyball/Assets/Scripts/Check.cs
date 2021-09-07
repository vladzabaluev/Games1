using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour
{
    int scoreFP = 0; //first player
    int scoreSP = 0; //second player

    public Text Score1;
    public Text Score2;

    public Timer timer;

    public Text notificationPlayer1Win;
    public Text notificationPlayer2Win;

    public Menu menu;
    public void SecondPlayerScored()
    {      
        Score2.text = ++scoreSP + "";
    }

    public void FirstPlayerScored()
    {
        Score1.text = ++scoreFP + "";
    }

    public void FinalScore()
    {
        if (scoreFP > scoreSP)
        {
            notificationPlayer1Win.gameObject.SetActive(true);
            resultOfTheGame();
        }
        else if (scoreFP < scoreSP)
        {
            notificationPlayer2Win.gameObject.SetActive(true);
            resultOfTheGame();
        }
        else
        {
            timer.GoalToWin.gameObject.SetActive(true);
        }
        timer.minutes.gameObject.SetActive(false);
        timer.points.gameObject.SetActive(false);
        timer.seconds.gameObject.SetActive(false);
    }

    void resultOfTheGame()
    {
        timer.GoalToWin.gameObject.SetActive(false);
        Time.timeScale = 0;
        menu.postMatchMenu();
    }
}
