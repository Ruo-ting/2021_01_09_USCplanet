using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackUIItem : MonoBehaviour
{
    public BackpackUIManager backpackUIManager;
    // UI
    //public Text txtDescription;
    //public Text txtCost;

    [SerializeField]
    private Item backpackItem;

    public void SetItem(Item item)
    {
        backpackItem = item;
        SetSprite();
    }

    void SetSprite()
    {
        if (backpackItem != null)
            GetComponent<Image>().sprite = backpackItem.itemImage;
        else
            GetComponent<Image>().sprite = null;
    }

    public void PointerClick()
    {
        if (backpackItem!=null && backpackItem.itemKind == enumItemKind.服飾)
            backpackUIManager.Dressing(backpackItem);
    }
}
