using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestHealthText : MonoBehaviour
{
    private TMP_Text healthText;

    private void Awake()
    {
        healthText = GetComponent<TMP_Text>();
        GlobalEventManager.OnPlayerDamaged.AddListener(UpdateText);
    }

    // Start is called before the first frame update
    private void UpdateText(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }
}