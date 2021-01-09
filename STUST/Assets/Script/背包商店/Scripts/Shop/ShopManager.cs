using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ItemManager itemManager;
    private GameObject objWho; // 誰要來買商品

    public ShopUIManager shopUIManager; // 商店UI

    [SerializeField]
    private List<Item> lstProsItem;
    [SerializeField]
    private List<Item> lstAppraelItem;
    [SerializeField]
    private List<Item> lstEquiementItem;
    //
    private List<Item> lstItemShoppingCart;
    private int PayMoney;

    // Start is called before the first frame update
    void Awake()
    {
        lstProsItem = itemManager.GetItems(true, enumItemKind.道具);
        lstAppraelItem = itemManager.GetItems(true, enumItemKind.服飾);
        lstEquiementItem = itemManager.GetItems(true, enumItemKind.裝備);

        lstItemShoppingCart = new List<Item>();
    }

    public void SetWhoBuy(GameObject obj_who)
    {
        objWho = obj_who;
        InitialShoppingCart();
    }

    private void InitialShoppingCart()
    {
        lstItemShoppingCart.Clear();
        shopUIManager.DispWhoMoney(objWho.GetComponent<BackpackManager>().GetMoney());

        PayMoney = 0;
        shopUIManager.RefreshShopCartItems(lstItemShoppingCart, PayMoney);
    }

    public List<Item> GetSellItems(enumItemKind item_kind)
    {
        if (item_kind == enumItemKind.服飾)
            return lstAppraelItem;
        else if (item_kind == enumItemKind.裝備)
            return lstEquiementItem;
        else if (item_kind == enumItemKind.道具)
            return lstProsItem;
        else
            return null;
    }

    public void AddItemShoppingCart(Item item)
    {
        lstItemShoppingCart.Add(item);
        PayMoney = CostInShoppingCart();
        shopUIManager.RefreshShopCartItems(lstItemShoppingCart, PayMoney);
    }

    public void RemoveItemShoppingCart(Item item)
    {
        lstItemShoppingCart.Remove(item);
        PayMoney = CostInShoppingCart();
        shopUIManager.RefreshShopCartItems(lstItemShoppingCart, PayMoney);
    }

    private int CostInShoppingCart()
    {
        int total_cost = 0;
        for (int i = 0; i < lstItemShoppingCart.Count; i++)
            total_cost += lstItemShoppingCart[i].itemCost;

        return total_cost;
    }

    public void Buy()
    {
        BackpackManager backpack_manager = objWho.GetComponent<BackpackManager>();
        int money = backpack_manager.GetMoney();

        if (money >= PayMoney)
        {
            for (int i = 0; i < lstItemShoppingCart.Count; i++)
                backpack_manager.AddItem(lstItemShoppingCart[i]);

            backpack_manager.SetMoney(money - PayMoney);
        }

        InitialShoppingCart();
    }
}