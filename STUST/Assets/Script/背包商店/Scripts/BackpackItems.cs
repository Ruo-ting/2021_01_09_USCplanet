using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Backpack",menuName="Backpack/New Backpack")]//新背包選項
public class BackpackItems : ScriptableObject
{
    public int itemMoney;
    public List<Item> lstItem = new List<Item>();//存取於這些item列表的背包
}
