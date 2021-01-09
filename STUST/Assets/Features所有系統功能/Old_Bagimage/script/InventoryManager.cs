using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;
    public Inventory Mybag;
    public GameObject slotGrid;//之前設置好的格式顯示出來

    //public slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInfo;
    public List<GameObject> slots = new List<GameObject>();

    public bool m_isLeft = true;

    public 
    void Awake(){
        if(instance!=null){
            Destroy(this);
        }
        instance=this;
        
    }
    private void OnEnable(){
        RefreshItem();
        instance.itemInfo.text="";
    }
    public static void UpdateItemInfo(string itemDescription){ //顯示物品資訊
        instance.itemInfo.text="";
        instance.itemInfo.text=itemDescription;
    }
    //public static void CreateNewItem(Item item){
    //    slot newItem = Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);//按照格式生成
    //    newItem.gameObject.transform.SetParent(instance.slotGrid.transform);//生成的prefab能掛到下面成子集
    //    newItem.slotitem=item;  //物品
    //    newItem.slotimage.sprite=item.itemImage;  //圖片
    //    newItem.slotNum.text = item.itemHeld.ToString();  //數字
    //}
    public static void RefreshItem(){ //銷毀重新創建
        for(int i=0;i <instance.slotGrid.transform.childCount;i++){
            if(instance.slotGrid.transform.childCount==0){
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        for(int i=0;i <instance.Mybag.itemList.Count;i++){ //重新生成回來 碰撞一次在多一個
            //CreateNewItem(instance.Mybag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));//生成當中也加進list列表裡
            instance.slots[i].transform.SetParent(instance.slotGrid.transform,false);//位置對應grid生成
            instance.slots[i].GetComponent<slot>().slotID = i;
            instance.slots[i].GetComponent<slot>().SetupSlot(instance.Mybag.itemList[i]);
        }
    }
}
