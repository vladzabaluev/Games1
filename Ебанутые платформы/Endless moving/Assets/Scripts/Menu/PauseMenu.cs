using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button exit;
    public Button pause;
    public Button resume;
    public Button restart;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pause.gameObject.SetActive(false);
        resume.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pause.gameObject.SetActive(true);
        resume.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
    }
 
}
