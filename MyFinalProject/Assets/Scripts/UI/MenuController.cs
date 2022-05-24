using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject DeathMenu;

    private PlayerInputActions UI_Input;
    private InputAction i_pause;

    private bool GameIsPaused = false;

    private GameObject currentMenu;

    private void Awake()
    {
        GlobalEventManager.OnPlayerDead.AddListener(OnPlayerDead);
        GlobalEventManager.OnGamePaused.AddListener(PauseGame);
        GlobalEventManager.OnGameUnpaused.AddListener(UnpauseGame);

        DeathMenu.SetActive(false);
        PauseMenu.SetActive(false);
        UI_Input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        i_pause = UI_Input.UI.OpenPauseMenu;
        i_pause.started += PauseControl;
        i_pause.Enable();
    }

    private void OnDisable()
    {
        i_pause.Disable();
    }

    private void PauseControl(InputAction.CallbackContext obj)
    {
        if (currentMenu != DeathMenu)
        {
            if (!GameIsPaused)
            {
                GameIsPaused = true;
                GlobalEventManager.SendGamePaused();
            }
            else
            {
                SendGameContinue();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        CoursorController.SetCursor(true);
        PauseMenu.SetActive(true);
        currentMenu = PauseMenu;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        CoursorController.SetCursor(false);
        PauseMenu.SetActive(false);
        currentMenu = null;
    }

    public void SendGameContinue()
    {
        GameIsPaused = false;
        GlobalEventManager.SendGameUnpaused();
    }

    private void OnPlayerDead()
    {
        DeathMenu.SetActive(true);
        currentMenu = DeathMenu;
        Time.timeScale = 0;
        CoursorController.SetCursor(true);
    }

    public void RestartLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(1);
    }
}