using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

public class Player : MonoBehaviourPun
{
    public static Player instance;

    public int exp;
    public int gold;

    public int itemAmount;//玩家持有的物品個數

    public List<Quest> questList = new List<Quest>();

    
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            if (instance != this)
            { 
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
