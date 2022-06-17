using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestEnemyCountText : MonoBehaviour
{
    private TMP_Text enemiesCountText;

    private void Awake()
    {
        enemiesCountText = GetComponent<TMP_Text>();
        GlobalEventManager.EnemyCount.AddListener(UpdateText);
    }


    public void UpdateText(int enemiesLeft)
    {
        enemiesCountText.text = "Enemies left :" + enemiesLeft;
    }
}