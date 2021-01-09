using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderItem : MonoBehaviour
{
    public ItemManager itemManager;
    //
    public bool IsRandom = false;
    public enumItemKind itemKind;
    public Item colliderItem;

    // Start is called before the first frame update
    void Start()
    {
        if (IsRandom)
           colliderItem = itemManager.GetItem(itemKind, true);
    }

    // Update is called once per frame
    public Item GetItem()
    {
        return colliderItem;
    }
}
