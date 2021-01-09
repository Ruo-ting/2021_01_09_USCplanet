using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Itemontrigger : MonoBehaviour
{
    public Inventory playerInventory;//背包
    public Item thisItem;//物品
    
    
    public void OnTriggerStay(Collider other){ //觸發物件
        
        if(other.gameObject.CompareTag("Player")){ //如果標誌player觸發
            {
                Addnewitem(); //要添加一個新物品
                
                Destroy(gameObject);
            }
        }
        
    }
    public void Addnewitem(){
        if(!playerInventory.itemList.Contains(thisItem)) //在itemlist當中是否包含此物品
        {  if(playerInventory.itemList.Count==9){

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
        else{
            thisItem.itemHeld +=1; //當前物品持有度增加1
        }

        
        InventoryManager.RefreshItem();  
    }
    //刪除物件
    /*private void RemoveItem() {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            { 
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        
    }*/
  
}
