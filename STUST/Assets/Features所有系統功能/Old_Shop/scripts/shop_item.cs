using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_item : MonoBehaviour
{
    public int cost;
    public string itemname;

    public Inventory playerInventory;//背包
    public Item thisItem;//物品

    public void bought()
    {
        if (GetComponentInParent<shop>().money >= cost)
        {
            GetComponentInParent<shop>().money -= cost;
            GetComponentInParent<shop>().additem(itemname);

            Addnewitem();
        }
    }

    public void Addnewitem()
    {
        if (!playerInventory.itemList.Contains(thisItem)) //在itemlist當中是否包含此物品
        {
            if (playerInventory.itemList.Count == 9)
            {
                Debug.Log("包包已滿");
            }
            else
            {
                //playerInventory.itemList.Add(thisItem); //將此物品加進來
                Debug.Log("以撿起");
                // InventoryManager.CreateNewItem(thisItem);
            }

            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1; //當前物品持有度增加1
        }

        InventoryManager.RefreshItem();
    }
}
