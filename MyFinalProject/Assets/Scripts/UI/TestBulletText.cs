using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestBulletText : MonoBehaviour
{
    private static TMP_Text weaphoneText;

    private void Awake()
    {
        weaphoneText = GetComponent<TMP_Text>();
        GlobalEventManager.OnBulletAmountChanged.AddListener(UpdateText);
    }

    private void Start()
    {
    
    }

    // Update is called once per frame

    public void UpdateText(Weaphone weaphone)
    {
        weaphoneText.text = weaphone.currentBulletInClip + "/" + weaphone.currentAllBullet;
    }
}