using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainFunctionMenu : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public Button menuButton;
    public Button startButton;
    public Button exitButton;

    bool _pause = false;
    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _pause)
        {
            pause();
        }
    }
    public void pause()
    {
        Time.timeScale = 0;

        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void resume()
    {
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }


    public void startGame()
    {
        Time.timeScale = 1;
        _pause = true;
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }


    public void exitGame()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
