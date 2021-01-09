using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory",menuName="Inventory/New Inventory")]//新背包選項
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();//存取於這些item列表的背包
}
