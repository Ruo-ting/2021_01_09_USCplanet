using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public ShopManager shopManager;
    public bool IsOpened = false;

    //UI
    public GameObject pnlShop;
    public Image[] imgShopItem;
    public Image[] imgShoppingCartItem;

    // ShoppingCart
    public Text txtWhoMoney;
    public Text txtPayMoney;

    private void Start()
    {
        RefreshShopItems(shopManager.GetSellItems(enumItemKind.服飾));
    }

    public void SwitchShopVisible()
    {
        IsOpened = !IsOpened;
        pnlShop.SetActive(IsOpened);
    }

    public void DispWhoMoney(int money)
    {
        txtWhoMoney.text = money.ToString();
    }

    public void btnItemKindClick(int kind)
    {
        enumItemKind item_kind = (enumItemKind)kind;
        RefreshShopItems(shopManager.GetSellItems(item_kind));
    }

    public void RefreshShopItems(List<Item> lstSellItems)
    {
        for (int i = 0; i < imgShopItem.Length; i++)
        {
            if (i < lstSellItems.Count)
            {
                imgShopItem[i].GetComponent<ShopUIItem>().SetItem(lstSellItems[i], true);
                imgShopItem[i].sprite = lstSellItems[i].itemImage;
            }
            else
            {
                imgShopItem[i].GetComponent<ShopUIItem>().SetItem(null, true);
                imgShopItem[i].sprite = null;
            }
        }
    }

    public void RefreshShopCartItems(List<Item> lstShoopingCartItem, int pay_money)
    {
        for (int i = 0; i < imgShoppingCartItem.Length; i++)
        {
            if (i < lstShoopingCartItem.Count)
            {
                imgShoppingCartItem[i].GetComponent<ShopUIItem>().SetItem(lstShoopingCartItem[i], false);
                imgShoppingCartItem[i].sprite = lstShoopingCartItem[i].itemImage;
            }
            else
            {
                imgShoppingCartItem[i].GetComponent<ShopUIItem>().SetItem(null, false);
                imgShoppingCartItem[i].sprite = null;
            }
        }

        txtPayMoney.text = "應付 : " + pay_money.ToString();
    }

    //
    // Buy 
    public void btnBuyClick()
    {
        shopManager.Buy();
    }
}
