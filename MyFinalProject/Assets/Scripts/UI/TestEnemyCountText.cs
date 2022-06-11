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
        GlobalEventManager.OnEnemyDead.AddListener(UpdateText);
    }

    // Start is called before the first frame update
    private void Start()
    {
        enemiesCountText = GetComponent<TMP_Text>();
    }

    public void UpdateText(int enemiesLeft)
    {
        enemiesCountText.text = "Enemies left :" + enemiesLeft;
    }
}