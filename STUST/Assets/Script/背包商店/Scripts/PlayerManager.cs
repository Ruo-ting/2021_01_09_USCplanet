using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager PlayerInstance;

    public ItemManager itemManager;
    public bool IsBoy;

    public DressingManager sysDressing;
    public BackpackManager sysBackpack;

    // Start is called before the first frame update
    void Start()
    {
        sysDressing = GetComponent<DressingManager>();
        sysBackpack = GetComponent<BackpackManager>();
        Debug.Log(sysDressing);

        //if (!sysDressing.IsDressing())
            //sysDressing.RandomApparel();
        //else
            //sysDressing.SetModelByScriptableApparel();
    }

    public void SetPlayerInstance()
    {
        if (PlayerInstance == null)
            PlayerInstance = this;
        else if (PlayerInstance != this)
            Destroy(gameObject);

        Debug.Log("Name=" + gameObject.name);
        DontDestroyOnLoad(gameObject);
    }

    public void GotoScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject objItem = collision.gameObject;
        if (objItem.tag == "Item")
        {
            Item item = objItem.GetComponent<ColliderItem>().GetItem();
            if (item != null)
                sysBackpack.AddItem(item);

            Destroy(collision.gameObject);
        }
    }
}
