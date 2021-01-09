using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject objWho; 
    [SerializeField]
    private BackpackManager backpackManager; // 誰的背包
    private DressingManager dressingManager;

    [Header("BackMoney")]

    [SerializeField] private Text mBackMoney;

    public bool IsOpened = false;

    //UI
    public GameObject pnlBackpack;
    public Image[] imgItems;
    public Text txtMoney;

    // ShoppingCart
    //public Text txtWhoMoney;
    public Camera imgCamera;
    public RawImage imgModel;


    public Text GetBackMoney
    {
        get
        {
            return mBackMoney;
        }
    }
    public void SetBackMoney(int iBackMoney)
    {
        if (!mBackMoney)
        {
            return;
        }
        mBackMoney.text = iBackMoney.ToString();
    }
    public void InitValue(int iBackMoney)
    {
        SetBackMoney(iBackMoney);
    }
    public void SetWho(GameObject obj_who)
    {
        objWho = obj_who;
        backpackManager = objWho.GetComponent<BackpackManager>();
        dressingManager = objWho.GetComponent<DressingManager>();

        RefreshBackpackItems(backpackManager.GetItems(enumItemKind.服飾));
        DisplayWhoMoney();
    }

    private void DisplayWhoMoney()
    {
        txtMoney.text = "金幣 : " + backpackManager.GetMoney().ToString();
    }

    private void AdjustCamera()
    {
        //imgCamera.enabled = true;
        if (IsOpened)
        {
            imgCamera.transform.position = new Vector3(objWho.transform.position.x + 10*objWho.transform.forward.x,
                                                       4.5f,
                                                       objWho.transform.position.z + 10 * objWho.transform.forward.z);
            imgCamera.transform.forward = objWho.transform.forward * (-1);
        }
    }

    public void SwitchVisible()
    {
        IsOpened = !IsOpened;
        pnlBackpack.SetActive(IsOpened);
        AdjustCamera();
        btnItemKindClick((int)enumItemKind.服飾);
        DisplayWhoMoney();
    }

    public void btnItemKindClick(int kind)
    {
        enumItemKind item_kind = (enumItemKind)kind;
        RefreshBackpackItems(backpackManager.GetItems(item_kind));
    }

    public void RefreshBackpackItems(List<Item> lstItems)
    {
        for (int i = 0; i < imgItems.Length; i++)
        {
            if (i < lstItems.Count)
                imgItems[i].GetComponent<BackpackUIItem>().SetItem(lstItems[i]);
            else
                imgItems[i].GetComponent<BackpackUIItem>().SetItem(null);
        }
    }

    public void Dressing(Item item)
    {
        backpackManager.RemoveItem(item);

        Item model_item = null;
        if (item.itemName == enumItemName.染髮劑)
            model_item = dressingManager.GetModelHairColor();
        else if (item.itemName == enumItemName.衣服)
            model_item = dressingManager.GetModelClothes();
        else if (item.itemName == enumItemName.褲子)
            model_item = dressingManager.GetModelPants();
        else if (item.itemName == enumItemName.頭髮)
            model_item = dressingManager.GetModelHair();
        else if (item.itemName == enumItemName.鞋子)
            model_item = dressingManager.GetModelShoes();
        else if (item.itemName == enumItemName.變色瞳孔)
            model_item = dressingManager.GetModelEyesColor();

        backpackManager.AddItem(model_item);

        if (item.itemName == enumItemName.染髮劑)
            dressingManager.SetModelHairColor(item);
        else if (item.itemName == enumItemName.衣服)
            dressingManager.SetModelClothes(item);
        else if (item.itemName == enumItemName.褲子)
            dressingManager.SetModelPants(item);
        else if (item.itemName == enumItemName.頭髮)
            dressingManager.SetModelHair(item);
        else if (item.itemName == enumItemName.鞋子)
            dressingManager.SetModelShoes(item);
        else if (item.itemName == enumItemName.變色瞳孔)
            dressingManager.SetModelEyesColor(item);

        RefreshBackpackItems(backpackManager.GetItems(enumItemKind.服飾));
    }

    private void Update()
    {
        if (IsOpened)
            imgModel.texture = imgCamera.targetTexture;   
    }
}
