using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Menu StartMenu;
    // Start is called before the first frame update

    public void HideStartMenu()
    {
        GameManager.SendGameIsStart();
        SetMenuActive(false, StartMenu);
    }

    private void SetMenuActive(bool active, Menu menu)
    {
        menu.gameObject.SetActive(active);
    }
}