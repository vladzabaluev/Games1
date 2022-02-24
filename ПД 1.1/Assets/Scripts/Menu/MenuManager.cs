using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public string newGameSceneName;

    //////////////////////////////Main Menu buttons//////////////////////////////
    [SerializeField] Button startButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;

    //////////////////////////////Option buttons////////////////////////////////
    [SerializeField] Button displayOptionButton;
    [SerializeField] Button soundOptionButton;
    [SerializeField] Button backToMenuButton;

    //////////////////////////////Screens//////////////////////////////////////
    [SerializeField] GameObject startGameScreen;
    [SerializeField] GameObject mainOptionsScreen;
    [SerializeField] GameObject soundOptionScreen;
 

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(Options);
        exitButton.onClick.AddListener(ExitGame);

        displayOptionButton.onClick.AddListener(DisplayOption);
        soundOptionButton.onClick.AddListener(SoundOption);
        backToMenuButton.onClick.AddListener(ExitToMenu);

        FirstStart();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(newGameSceneName);   //Нужно будет ввести название сцены с игрой в newGameSceneName
    }

    private void Options()
    {
        mainOptionsScreen.SetActive(true);
        startGameScreen.SetActive(false);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void DisplayOption()
    {

    }

    private void SoundOption()
    {
        mainOptionsScreen.SetActive(false);
        soundOptionScreen.SetActive(true);
    }

    private void ExitToMenu()
    {
        mainOptionsScreen.SetActive(false);
        startGameScreen.SetActive(true);
    }

    private void FirstStart()
    {
        mainOptionsScreen.SetActive(false);
        startGameScreen.SetActive(true);
        soundOptionScreen.SetActive(false);
    }

    public void StartButtonEnter()
    {
        startButton.GetComponentInChildren<Text>().fontSize = 32;
    }

    public void StartButtonExit()
    {
        startButton.GetComponentInChildren<Text>().fontSize = 27;
    }

    public void OptionsButtonEnter()
    {
        optionsButton.GetComponentInChildren<Text>().fontSize = 32;
    }

    public void OptionsButtonExit()
    {
        optionsButton.GetComponentInChildren<Text>().fontSize = 27;
    }

    public void ExitButtonEnter()
    {
        exitButton.GetComponentInChildren<Text>().fontSize = 32;
    }

    public void ExitButtonExit()
    {
        exitButton.GetComponentInChildren<Text>().fontSize = 27;
    }

    public void displayOptionButtonEnter()
    {
        displayOptionButton.GetComponentInChildren<Text>().fontSize = 32;
    }

    public void displayOptionButtonExit()
    {
        displayOptionButton.GetComponentInChildren<Text>().fontSize = 27;
    }
    public void SoundOptionButtonEnter()
    {
        soundOptionButton.GetComponentInChildren<Text>().fontSize = 32;
    }

    public void SoundOptionButtonExit()
    {
        soundOptionButton.GetComponentInChildren<Text>().fontSize = 27;
    }
    public void BackToMenuButtonEnter()
    {
        backToMenuButton.GetComponentInChildren<Text>().fontSize = 32;
    }

    public void BackToMenuButtonExit()
    {
        backToMenuButton.GetComponentInChildren<Text>().fontSize = 27;
    }
}
