using Cinemachine;
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
    public GameObject SettingsMenu;
    public GameObject LevelCompleteMenu;

    private PlayerInputActions UI_Input;
    private InputAction i_pause;

    private bool GameIsPaused = false;

    private GameObject currentMenu;

    private void Awake()
    {
        GlobalEventManager.OnPlayerDead.AddListener(OnPlayerDead);
        GlobalEventManager.OnGamePaused.AddListener(PauseGame);
        GlobalEventManager.OnGameUnpaused.AddListener(UnpauseGame);
        GlobalEventManager.OnAllEnemiesDead.AddListener(ShowCompleteMenu);

        DeathMenu.SetActive(false);
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        LevelCompleteMenu.SetActive(false);

        UI_Input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        i_pause = UI_Input.UI.EscClick;
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
        Camera.main.GetComponent<CinemachineBrain>()
            .ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<Cinemachine.CinemachineVirtualCamera>()
            .GetComponent<CinemachineInputProvider>().enabled = false; 
    }

    public void RestartLVL()
    {
        EnemyStats.EnemiesOnLVL = 0;////FIX IT
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void OpenSettings()
    {
        i_pause.started -= PauseControl;
        i_pause.started += BackToPauseMenu;

        currentMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    private void BackToPauseMenu(InputAction.CallbackContext obj)
    {
        CloseSettings();
    }

    //private void OnOp(InputAction.CallbackContext obj)

    public void CloseSettings()
    {
        i_pause.started += PauseControl;
        i_pause.started -= BackToPauseMenu;

        SettingsMenu.SetActive(false);
        currentMenu.SetActive(true);
    }

    private void ShowCompleteMenu() //—À€ÿ ŒÃ  Œ—“€À‹ÕŒ
    {
        Camera.main.GetComponent<CinemachineBrain>()
    .ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<Cinemachine.CinemachineVirtualCamera>()
    .GetComponent<CinemachineInputProvider>().enabled = false;
        currentMenu = LevelCompleteMenu;
        LevelCompleteMenu.SetActive(true);
        Time.timeScale = 0;
        CoursorController.SetCursor(true);
    }

    public void LoadNextLevel()
    {
        EnemyStats.EnemiesOnLVL = 0;////FIX IT
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}