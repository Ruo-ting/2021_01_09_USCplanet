using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class slot : MonoBehaviour
{
    //[SerializeField] Image image;
    public int slotID;//空格ID 等於 物品ID
    public Item slotitem;
    public Image slotimage;
    public Text  slotNum;

    public GameObject itemInSlot;
    public string slotInfo;

    public void ItemOnclicked(){ //物品被點擊
        InventoryManager.UpdateItemInfo(slotInfo);
    }
    private void OnMouseEnter(){
        Debug.Log("我接近了");
        InventoryManager.UpdateItemInfo(slotitem.itemInfo);
    }
    public void SetupSlot(Item item) 
    {
        if (item == null)   //列表為空即不顯示
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotimage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
    }
    
    //private  virtual void OnValidate()
    //{
    //    if (slotimage == null)
    //        slotimage = GetComponent<Image>();
    //}
}
