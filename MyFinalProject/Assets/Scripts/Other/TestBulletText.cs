using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

//using UnityEngine.Events;

public class TestBulletText : MonoBehaviour
{
    private static TMP_Text weaphoneText;

    //public UnityEvent<Weaphone> e_ChangeText;
    // Start is called before the first frame update
    private void Awake()
    {
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