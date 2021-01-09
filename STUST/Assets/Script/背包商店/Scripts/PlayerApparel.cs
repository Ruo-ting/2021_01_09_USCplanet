using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Apparel", menuName = "Player Apparel/New Apparel")]
[System.Serializable]
public class PlayerApparel : ScriptableObject
{
    [SerializeField]
    private bool Is_Boy;
    public bool IsBoy
    {
        get { return Is_Boy; }
        set { Is_Boy = value; }
    }

    [SerializeField]
    private Item itemHair;
    public Item ItemHair
    {
        get { return itemHair; }
        set { itemHair = value; }
    }

    [SerializeField]
    private Item itemHairColor;
    public Item ItemHairColor
    {
        get { return itemHairColor; }
        set { itemHairColor = value; }
    }

    [SerializeField]
    private Item itemEyesColor;
    public Item ItemEyesColor
    {
        get { return itemEyesColor; }
        set { itemEyesColor = value; }
    }

    [SerializeField]
    private Item itemClothes;
    public Item ItemClothes
    {
        get { return itemClothes; }
        set { itemClothes = value; }
    }

    [SerializeField]
    private Item itemPants;
    public Item ItemPants
    {
        get { return itemPants; }
        set { itemPants = Is_Boy ? value : null; }
    }

    [SerializeField]
    private Item itemShoes;
    public Item ItemShoes
    {
        get { return itemShoes; }
        set { itemShoes = value; }
    }

    /// <summary>
    /// funcions
    /// </summary>
    public void SetData(bool is_boy, Item item_hair, Item item_haircolor, Item item_eyescolor,
                        Item item_clothes, Item item_pants, Item item_shoes)
    {
        IsBoy = is_boy;
        ItemHair = item_hair;
        ItemHairColor = item_haircolor;
        ItemEyesColor = item_eyescolor;
        ItemClothes = item_clothes;
        ItemPants = item_pants;
        ItemShoes = item_shoes;
    }
}
