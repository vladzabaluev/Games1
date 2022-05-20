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

    private void Awake()
    {
        GlobalEventManager.OnPlayerDead.AddListener(OnPlayerDead);
        GlobalEventManager.OnGamePaused.AddListener(PauseGame);
        DeathMenu.SetActive(false);
        PauseMenu.SetActive(false);
        UI_Input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        i_pause = UI_Input.UI.OpenPauseMenu;
        i_pause.started += SendThatGameIsPaused;
        i_pause.Enable();
    }

    private void OnDisable()
    {
        i_pause.Disable();
    }

    private void SendThatGameIsPaused(InputAction.CallbackContext obj)
    {
        GlobalEventManager.SendGamePaused();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        CoursorController.SetCursor(true);
        PauseMenu.SetActive(true);
        //убрать ввод
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        CoursorController.SetCursor(false);
        PauseMenu.SetActive(false);
        //вернуть ввод
    }

    private void OnPlayerDead()
    {
        DeathMenu.SetActive(true);
        Time.timeScale = 0;
        CoursorController.SetCursor(true);
    }

    public void RestartLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}