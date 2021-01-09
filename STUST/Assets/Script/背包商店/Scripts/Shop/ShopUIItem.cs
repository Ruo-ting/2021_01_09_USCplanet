using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopUIItem : MonoBehaviour
{
    public ShopManager shopManager;
    // UI
    public Text txtDescription;
    public Text txtCost;

    [SerializeField]
    private Item sellItem;
    private bool IsShop; // true: in shop; false:in shopping cart

    public void SetItem(Item item, bool is_shop)
    {
        sellItem = item;
        IsShop = is_shop;
    }

    public void PointerEnter()
    {
        if (sellItem != null && IsShop)
        {
            txtDescription.text = sellItem.itemInfo;
            txtCost.text = sellItem.itemCost.ToString();
        }
    }

    public void PointerExit()
    {
        if (IsShop)
        {
            txtDescription.text = "";
            txtCost.text = "";
        }
    }

    public void PointerClick()
    {
        if (sellItem != null)
        {
            if (IsShop)
                shopManager.AddItemShoppingCart(sellItem);
            else
                shopManager.RemoveItemShoppingCart(sellItem);
        }
    }
}
