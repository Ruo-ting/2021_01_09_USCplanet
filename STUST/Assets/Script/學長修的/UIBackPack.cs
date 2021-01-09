using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBackPack : MonoBehaviour
{
    [Header("BackMoney")]

    [SerializeField] private Text mBackMoney;

    public Text GetBackMoney 
    {
        get 
        {
            return mBackMoney;
        }
    }
    public void SetBackMoney(int iBackMoney)
    {
        if (!mBackMoney) 
        {
            return;
        }
        mBackMoney.text = iBackMoney.ToString();
    }




    public void InitValue(int iBackMoney) 
    {
        SetBackMoney(iBackMoney);
    }

}
