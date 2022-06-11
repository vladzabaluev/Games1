using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject tutorilaInfo;

    public void StartGame()
    {
        SceneManager.LoadScene("Learning");
    }

    public void OpenSettings()
    {
        LoadScene("Settings");
    }

    public void OpenMainMenu()
    {
        LoadScene("Main menu");
    }

    public void ShowTutorialText()
    {
        tutorilaInfo.SetActive(true);
    }

    public void HideTutorialText()
    {
        tutorilaInfo.SetActive(false);
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}