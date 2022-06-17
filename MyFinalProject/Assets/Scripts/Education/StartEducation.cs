using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEducation : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;

        //GlobalEventManager.instanse.player.gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        //GlobalEventManager.instanse.player.gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            CoursorController.SetCursor(true);
        }
    }

    public void FinishEducation()
    {
        Time.timeScale = 1;
        GlobalEventManager.instanse.player.gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        GlobalEventManager.instanse.player.gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        CoursorController.SetCursor(false);
        gameObject.SetActive(false);
    }
}