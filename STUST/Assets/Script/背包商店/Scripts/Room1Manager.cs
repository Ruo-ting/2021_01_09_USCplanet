using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Manager : MonoBehaviour
{
    public ShopManager shopManager;
    public BackpackUIManager backpackUIManager;
    [SerializeField]
    GameObject objWho;

    // Start is called before the first frame update
    void Start()
    {
        objWho = GameObject.Find("boy");
        if (objWho == null)
        {
            objWho = GameObject.Find("girl");
            if (objWho == null)
                Debug.Log("No Player!!!");
        }

        shopManager.SetWhoBuy(objWho);
        backpackUIManager.SetWho(objWho);
    }
}
