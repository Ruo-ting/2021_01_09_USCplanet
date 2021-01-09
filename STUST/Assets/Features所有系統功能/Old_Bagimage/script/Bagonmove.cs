using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Bagonmove : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    RectTransform currentRect;
    void Awake(){
        currentRect = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData){
       

    }
    public void OnDrag(PointerEventData eventData){
        currentRect.anchoredPosition += eventData.delta;

    }
    public void OnEndDrag(PointerEventData eventData){
        

    }
}
