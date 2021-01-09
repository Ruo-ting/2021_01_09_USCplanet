using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName="Inventory/New Item")]
public class Item : ScriptableObject
{
    public enumItemKind itemKind; // 項目種類
    public enumItemName itemName; //存取物體名字
    [Tooltip("用來區分有相同物體名稱,但為不同物體")] public int itemID;
    public Sprite itemImage;//圖片
    [TextArea] //資訊欄不夠寫的默認值
    public string itemInfo;//物體資訊

    public enumWhoUse itemWhoUsed;
    public bool itemInShop;

    public int itemCost;
    public int itemHeld;//現在持有多少個同類物品

    //
    public string itemObjectName;
    public GameObject itemObject;
    public Texture2D itemTexture;
    public Color itemColor;
}
