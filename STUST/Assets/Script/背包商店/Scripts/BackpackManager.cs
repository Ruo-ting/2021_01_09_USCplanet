using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//背包控制器
public class BackpackManager : MonoBehaviour
{
    [SerializeField]
    public BackpackItems Backpack; //存取於這些item列表的背包

    public int GetItemCount()
    {
        return Backpack.lstItem.Count;
    }

    public void AddItem(Item item)
    {
        int idx;
        if ((idx=FindItem(item))>=0)
            Backpack.lstItem[idx].itemHeld++;
        else
        {
            item.itemHeld = 1;
            Backpack.lstItem.Add(item);
        }
    }

    public void RemoveItem(Item item)
    {
        int idx;
        if ((idx = FindItem(item))>=0)
        {
            Backpack.lstItem[idx].itemHeld--;
            if (Backpack.lstItem[idx].itemHeld <= 0)
            {
                Backpack.lstItem[idx].itemHeld = 0;
                Backpack.lstItem.RemoveAt(idx);
            }
        }
    }

    public int FindItem(Item item)
    {
        int idx;
        for (idx = 0; idx < Backpack.lstItem.Count; idx++)
            if (item == Backpack.lstItem[idx])
                break;

        if (idx >= Backpack.lstItem.Count)
            return -1;
        
        return idx;
    }

    public List<Item> GetItems(enumItemKind item_kind)
    {
        List<Item> lst_item = new List<Item>();
        for (int i=0; i<Backpack.lstItem.Count; i++)
            if (Backpack.lstItem[i].itemKind == item_kind)
                lst_item.Add(Backpack.lstItem[i]);

        return lst_item;
    }

    ///
    public int GetMoney()
    {
        return Backpack.itemMoney;
    }

    public void SetMoney(int money)
    {
        if (money >= 0)
            Backpack.itemMoney = money;
        else
            Backpack.itemMoney = 0;
    }
}
