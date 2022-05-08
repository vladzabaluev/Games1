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
        GlobalEventManager.OnBulletAmountChanged.AddListener(UpdateText);
    }

    private void Start()
    {
        weaphoneText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame

    public void UpdateText(Weaphone weaphone)
    {
        weaphoneText.text = weaphone.currentBulletInClip + "/" + weaphone.currentAllBullet;
    }
}