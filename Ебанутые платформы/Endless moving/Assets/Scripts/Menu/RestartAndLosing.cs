using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartAndLosing : MonoBehaviour
{
    public Text GG;
    public Button restart;

    public void relodLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Losing()
    {
        GG.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }

    public void pause()
    {
        Time.timeScale = 0;
    }


}
