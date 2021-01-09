using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager ItemManagerInstance;
    [SerializeField]
    private List<Item> lstItem;

    void Awake()
    {
        object[] obj_apparel = Resources.LoadAll("ItemData/Apparel", typeof(Item));
        object[] obj_Equipment = Resources.LoadAll("ItemData/Equipment", typeof(Item));
        object[] obj_Pros = Resources.LoadAll("ItemData/Pros", typeof(Item));

        lstItem = new List<Item>();
        for (int i = 0; i < obj_apparel.Length; i++) lstItem.Add((Item)obj_apparel[i]);
        for (int i = 0; i < obj_Equipment.Length; i++) lstItem.Add((Item)obj_Equipment[i]);
        for (int i = 0; i < obj_Pros.Length; i++) lstItem.Add((Item)obj_Pros[i]);
        Debug.Log("Get all ScriptableObject files="+lstItem.Count);

        if (ItemManagerInstance == null)
            ItemManagerInstance = this;
        else if (ItemManagerInstance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    //
    // get items by shop
    //
    public List<Item> GetItems(bool in_shop)
    {
        List<Item> tmp_items = new List<Item>();

        for (int i=0; i<lstItem.Count; i++)
            if (lstItem[i].itemInShop)
                tmp_items.Add(lstItem[i]);

        return tmp_items;
    }

    public List<Item> GetItems(bool in_shop, enumItemKind item_kind)
    {
        List<Item> tmp_items = new List<Item>();

        List<Item> tmp_itemshop = GetItems(in_shop);
        for (int i = 0; i < tmp_itemshop.Count; i++)
            if (tmp_itemshop[i].itemKind == item_kind)
                tmp_items.Add(tmp_itemshop[i]);

        return tmp_items;
    }

    //
    // get items by item_kind
    //
    public List<Item> GetItems(enumItemKind item_kind)
    {
        List<Item> tmp_items = new List<Item>();

        for (int i = 0; i < lstItem.Count; i++)
            if (lstItem[i].itemKind == item_kind)
                tmp_items.Add(lstItem[i]);

        return tmp_items;
    }

    public List<Item> GetItems(enumItemKind item_kind, enumWhoUse item_whouse)
    {
        List<Item> tmp_items = new List<Item>();

        List<Item> tmp_itemkinds = GetItems(item_kind);
        for (int i = 0; i < tmp_itemkinds.Count; i++)
            if (tmp_itemkinds[i].itemWhoUsed == item_whouse)
                tmp_items.Add(tmp_itemkinds[i]);

        return tmp_items;
    }

    public Item GetItem(enumItemKind item_kind, bool is_random)
    {
        List<Item> tmp_items = GetItems(item_kind);

        if (tmp_items.Count == 0)
            return null;

        if (is_random)
            return tmp_items[Random.Range(0, tmp_items.Count)];
        else
            return tmp_items[0];
    }

    //
    // get items by item_name
    //
    public List<Item>GetItems(enumItemName item_name)
    {
        List<Item> tmp_items = new List<Item>();

        for (int i = 0; i < lstItem.Count; i++)
            if (lstItem[i].itemName == item_name)
                tmp_items.Add(lstItem[i]);

        Debug.Log("Get ItemName = " + tmp_items.Count);
        return tmp_items;
    }

    public List<Item> GetItems(enumItemName item_name, enumWhoUse item_whouse)
    {
        List<Item> tmp_items = new List<Item>();

        List<Item> tmp_itemname = GetItems(item_name);
        for (int i = 0; i < tmp_itemname.Count; i++)
            if (tmp_itemname[i].itemWhoUsed == item_whouse)
                tmp_items.Add(tmp_itemname[i]);

        Debug.Log("Get ItemName && enumWhoUse = " + tmp_items.Count + ", " + item_whouse);
        return tmp_items;
    }

    public Item GetItem(enumItemName item_name, bool is_random)
    {
        List<Item> tmp_items = GetItems(item_name);

        if (tmp_items.Count == 0)
            return null;

        if (is_random)
            return tmp_items[Random.Range(0, tmp_items.Count)];
        else
            return tmp_items[0];
    }

    public Item GetItem(enumItemName item_name, enumWhoUse item_whouse, bool is_random)
    {
        List<Item> tmp_items = GetItems(item_name, item_whouse);

        if (tmp_items.Count == 0)
            return null;

        if (is_random)
            return tmp_items[Random.Range(0, tmp_items.Count)];
        else
            return tmp_items[0];
    }
}
