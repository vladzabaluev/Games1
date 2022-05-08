using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instanse;

    private void Awake()
    {
        instanse = this;
    }

    #endregion Singleton

    public GameObject player;
}