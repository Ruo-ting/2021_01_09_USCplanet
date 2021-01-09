using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerUIManager : MonoBehaviour
{
    public void btnSelectPlayer_Click(GameObject obj_who)
    {
        Debug.Log("123");
        obj_who.GetComponent<PlayerManager>().SetPlayerInstance();
        obj_who.GetComponent<PlayerManager>().GotoScene("room1");
    }
}