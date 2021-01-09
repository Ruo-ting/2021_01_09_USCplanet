using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControler 
{
    private UIControler() { }
    private static UIControler mInstance;
    public static UIControler GetInstance()
    {
        if (mInstance == null)
        {
            mInstance = new UIControler();
        }
        return mInstance;
    }
    /// <summary>
    /// ******************************Main**********************************
    /// </summary>
    /// 

    private GameObject mMainUI;
    private GameObject mShopBackCanvas;
    private UIBackPack mBackPack;
    private UIShop mShop;

    public void InitValue(int iBackMoney) 
    {
        mBackPack.InitValue(iBackMoney);
    }
    public void UpdateMoney(int iBackMoney) 
    {
        if (!mBackPack) 
        {
            return;
        }
        mBackPack.SetBackMoney(iBackMoney);
    }
    public void GetSceneUI()
    {
        if (!mMainUI)
        {
            mMainUI = GameObject.Find("UI").transform.GetChild(0).gameObject;
        }
        if (!mShopBackCanvas)
        {
            if (!mMainUI.transform.GetChild(0))
            {
                return;
            }
            mShopBackCanvas = mMainUI.transform.GetChild(0).gameObject;
            if (!mShopBackCanvas.GetComponent<UIBackPack>() || !mShopBackCanvas.GetComponent<UIShop>())
            {
                return;
            }
            mBackPack = mShopBackCanvas.GetComponent<UIBackPack>();
            mShop = mShopBackCanvas.GetComponent<UIShop>();
        }
    }
    public void Release()
    {
        mMainUI = null;
        mShopBackCanvas = null;
        mBackPack = null;
        mShop = null;
    }
}
