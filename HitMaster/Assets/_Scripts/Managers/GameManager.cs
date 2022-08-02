using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Player;
    public static UnityEvent OnGameIsStart = new UnityEvent();
    public static UnityEvent OnGameIsStop = new UnityEvent();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SendGameIsStop();
    }

    public static void SendGameIsStart()
    {
        SetTime(false);
        OnGameIsStart.Invoke();
    }

    public static void SendGameIsStop()
    {
        SetTime(true);
        OnGameIsStop.Invoke();
    }

    public static void Restart()
    {
        SceneLoader.RestartLVL();
    }

    private static void SetTime(bool isStop)
    {
        if (isStop)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}