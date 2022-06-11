using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class Settings : MonoBehaviour
{
    public GameObject AudioSettings;
    public GameObject SettingsMenu;

    private GameObject currentMenu;

    public TMP_Text Header;

    private PlayerInputActions UI_Input;
    private InputAction i_back;

    private void Awake()
    {
        UI_Input = new PlayerInputActions();
    }

    private void Start()
    {
        SetActiveMenu(SettingsMenu, "Settings");
    }

    private void OnEnable()
    {
        i_back = UI_Input.UI.EscClick;
        i_back.performed += OnCloseAnySettings;
        i_back.Enable();
    }

    private void OnCloseAnySettings(InputAction.CallbackContext obj)
    {
        CloseAnySettings();
    }

    private void OnDisable()
    {
        i_back.Disable();
    }

    public void OpenAudioSettings()
    {
        SetActiveMenu(AudioSettings, "Settings / Audio");
        //SettingsMenu.SetActive(false);
        //Header.text += " / Audio";
        //AudioSettings.SetActive(true);
    }

    public void CloseAnySettings()
    {
        SetActiveMenu(SettingsMenu, "Settings");
        //SettingsMenu.SetActive(true);
        //Header.text = "Settings";
        //AudioSettings.SetActive(false);
    }

    public void SetActiveMenu(GameObject necessaryMenu, string headerValue)
    {
        if (currentMenu)
            currentMenu.SetActive(false);
        necessaryMenu.SetActive(true);
        currentMenu = necessaryMenu;
        Header.text = headerValue;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}