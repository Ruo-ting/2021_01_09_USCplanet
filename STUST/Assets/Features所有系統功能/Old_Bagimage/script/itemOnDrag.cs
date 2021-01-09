using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class itemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    public Inventory MyBag;
    private int currentItemID;//當前物品ID
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; //記住好原來的父位置，拖住後才不會脫離關係
        currentItemID = originalParent.GetComponent<slot>().slotID;
        transform.SetParent(transform.parent.parent); //脫離父關係 離開當時介面,拖住時不會被格子擋住
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "Image")//判斷下面物體名字是:Item Image 那麼互換位置
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
                //itemList的物品存儲位置改變
                var temp = MyBag.itemList[currentItemID];
                MyBag.itemList[currentItemID] = MyBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID];
                MyBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;//射線阻擋開啟，不然無法再次選中移動物品
                return;
                
            }
            else if (eventData.pointerCurrentRaycast.gameObject.name == "trush")
                {
                    Destroy(gameObject);
                }


            if (eventData.pointerCurrentRaycast.gameObject.name == "ItemImage(Clone)")
            {
                //否則直接掛在檢測到Slot下面
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //itemList的物品存儲位置改變
                MyBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = MyBag.itemList[currentItemID];
                //解決自己放在自己位置的問題
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<slot>().slotID != currentItemID)
                    MyBag.itemList[currentItemID] = null;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            
        }
        //其他任何位置都歸為
        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }
    
    
}
