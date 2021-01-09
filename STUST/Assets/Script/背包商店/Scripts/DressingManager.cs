//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressingManager : MonoBehaviour
{
    public ItemManager itemManager;
    [SerializeField]
    private enumWhoUse Sex;

    public GameObject objHair;
    public GameObject objShoes1, objShoes2;
    public GameObject objClothes;
    public GameObject objPants;
    public GameObject objEyes;
    public Material matHair;
    //
    public GameObject[] objHairs; //頭數據
    // 
    public PlayerApparel sobjPlayerApparel;

    void Awake()
    {
        Sex = sobjPlayerApparel.IsBoy ? enumWhoUse.Boy : enumWhoUse.Girl;    
    }
    
    /// <summary>
    /// Set Functions
    /// </summary> 
    public bool IsDressing()
    {
        Debug.Log(sobjPlayerApparel);
        if (sobjPlayerApparel.ItemHair != null)
            return true;
        else
            return false;
    }

    public void RandomApparel()
    {
        List<Item> item_hairs = itemManager.GetItems(enumItemName.頭髮, Sex);
        Debug.Log("hairs count=" + item_hairs.Count);
        if (item_hairs != null && item_hairs.Count > 0)
        {
            int item_idx = Random.Range(0, item_hairs.Count);
            sobjPlayerApparel.ItemHair = item_hairs[item_idx];
        }

        sobjPlayerApparel.ItemHairColor = itemManager.GetItem(enumItemName.染髮劑, true);
        sobjPlayerApparel.ItemClothes = itemManager.GetItem(enumItemName.衣服, Sex, true);
        sobjPlayerApparel.ItemPants = itemManager.GetItem(enumItemName.褲子, Sex, true);
        sobjPlayerApparel.ItemShoes = itemManager.GetItem(enumItemName.鞋子, true);
        sobjPlayerApparel.ItemEyesColor = itemManager.GetItem(enumItemName.變色瞳孔, true);

        SetModelByScriptableApparel();
    }

    public void SetModelByScriptableApparel()
    {
        SetModelHair(sobjPlayerApparel.ItemHair);
        SetModelHairColor(sobjPlayerApparel.ItemHairColor);
        SetModelEyesColor(sobjPlayerApparel.ItemEyesColor);
        SetModelClothes(sobjPlayerApparel.ItemClothes);
        SetModelPants(sobjPlayerApparel.ItemPants);
        SetModelShoes(sobjPlayerApparel.ItemShoes);
    }

    public void SetModelHair(Item item)
    {
        List<Item> item_hairs = itemManager.GetItems(enumItemName.頭髮, Sex);

        if (item_hairs != null && item_hairs.Count > 0)
        { 
            for (int i = 0; i < item_hairs.Count; i++)
                if (item == item_hairs[i])
                    transform.Find(item_hairs[i].itemObjectName).gameObject.SetActive(true);
                else
                    transform.Find(item_hairs[i].itemObjectName).gameObject.SetActive(false);
        }

        sobjPlayerApparel.ItemHair = item;
    }

    public void SetModelHairColor(Item item)
    {
        if (item != null)
        {
            matHair.color = item.itemColor;
            sobjPlayerApparel.ItemHairColor = item;
        }
    }

    public void SetModelEyesColor(Item item)
    {
        if (item!=null)
        {
            //objHair.GetComponent<Renderer>().material.mainTexture = texEyesColors[c];
            //sobjPlayerApparel.EyesColor = color;
            objEyes.GetComponent<Renderer>().material.mainTexture = item.itemTexture;
            sobjPlayerApparel.ItemEyesColor = item;
        }
    }

    public void SetModelClothes(Item item)
    {
        if (item!=null)
        {
            objClothes.GetComponent<Renderer>().material.mainTexture = item.itemTexture;
            sobjPlayerApparel.ItemClothes = item;
        }
    }

    public void SetModelPants(Item item)
    {
        if (item != null)
        {
            objPants.GetComponent<Renderer>().material.mainTexture = item.itemTexture;
            sobjPlayerApparel.ItemPants = item;
        }
    }

    public void SetModelShoes(Item item)
    {
        if (item != null)
        {
            objShoes1.GetComponent<Renderer>().material.mainTexture = item.itemTexture;
            objShoes2.GetComponent<Renderer>().material.mainTexture = item.itemTexture;
            sobjPlayerApparel.ItemShoes = item;
        }
    }

    //
    //
    //
    public Item GetModelHair()
    {
        return sobjPlayerApparel.ItemHair;
    }

    public Item GetModelHairColor()
    {
        return sobjPlayerApparel.ItemHairColor;
    }

    public Item GetModelEyesColor()
    {
        return sobjPlayerApparel.ItemEyesColor;
    }

    public Item GetModelClothes()
    {
        return sobjPlayerApparel.ItemClothes;
    }

    public Item GetModelPants()
    {
        return sobjPlayerApparel.ItemPants;
    }

    public Item GetModelShoes()
    {
        return sobjPlayerApparel.ItemShoes;
    }
}
