using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button resumeButton;
    public Button restartButton;
    public Button menuButton;
    public Button pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        resumeButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        resumeButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
    public void postMatchMenu()
    {
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void backToMenu()
    {
        Debug.Log("Возвращаемся в меню");
    }

    
}
