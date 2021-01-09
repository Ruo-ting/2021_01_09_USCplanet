using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Bottomselect : MonoBehaviour
{

    bool signisopen;
    bool bagisopen;
    bool mapisopen;
    bool shopisopen;
    //bool taskisopen;
    bool chatisopen;
    bool photoisopen;

    public GameObject mysign;
    public GameObject mybag;
    public GameObject mymap;
    public GameObject myshop;
    public GameObject mychat;
    public GameObject myphoto;



    public void signOpenorClose()
    {
        signisopen = !signisopen;
        mysign.SetActive(signisopen);
    }
    public void bagOpenorClose(){
        bagisopen=!bagisopen;
        mybag.SetActive(bagisopen);
    }
    public void mapOpenorClose(){
        mapisopen=!mapisopen;
        mymap.SetActive(mapisopen);
    }
    public void shopOpenorClose()
    {
        shopisopen = !shopisopen;
        myshop.SetActive(shopisopen);
    }
    
    public void chatOpenorClose()
    {
        chatisopen = !chatisopen;
        mychat.SetActive(chatisopen);
    }
    public void photoOpenorClose()
    {
        photoisopen = !photoisopen;
        myphoto.SetActive(photoisopen);
    }



    public void bagClosebtn(){
        bagisopen=false;
        mybag.SetActive(bagisopen);
    }
    public void mapClosebtn(){
        mapisopen=false;
        mymap.SetActive(mapisopen);
    }
    public void shopClosebtn()
    {
        shopisopen = false;
        myshop.SetActive(shopisopen);
    }
    //public void taskClosebtn()
    //{
    //    taskisopen = false;
    //    mytask.SetActive(taskisopen);
    //}
    public void chatClosebtn()
    {
        chatisopen = false;
        mychat.SetActive(chatisopen);
    }
    public void photoClosebtn()
    {
        photoisopen = false;
        myphoto.SetActive(photoisopen);
    }


    public void mapGoroom1btn(GameObject obj_who)
    {
        //Staticcode.Teleport = "tp01center";
        //PhotonNetwork.LeaveRoom();
        //PhotonNetwork.LoadLevel("room1");
        obj_who.GetComponent<PlayerManager>().SetPlayerInstance();
        obj_who.GetComponent<PlayerManager>().GotoScene("room1");
    }
    public void mapGoroom2btn(GameObject obj_who)
    {
        //Staticcode.Teleport="tp02center";
        //PhotonNetwork.LeaveRoom();
        //PhotonNetwork.LoadLevel("room2");
        obj_who.GetComponent<PlayerManager>().SetPlayerInstance();
        obj_who.GetComponent<PlayerManager>().GotoScene("room2");

    }
    
    public void mapGoroom3btn(GameObject obj_who)
    {
        //Staticcode.Teleport = "tp03center";
        //PhotonNetwork.LeaveRoom();
        //PhotonNetwork.LoadLevel("room3");
        obj_who.GetComponent<PlayerManager>().SetPlayerInstance();
        obj_who.GetComponent<PlayerManager>().GotoScene("room2");
    }
    public void mapGoroom4btn()
    {
        Staticcode.Teleport = "tp04center";
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("room4");
    }


    public void mapGame1()
    {
        SceneManager.LoadScene("0");
    }
}
