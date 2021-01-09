using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Realtime;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System;
public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject blockUI;
    public GameObject loginUI;
    public GameObject ServerUI;
    public InputField logintext;
    public InputField Servertext;

    public InputField idtext;
    public InputField passtext;
    public Text errortext;
    
    
    //public string url = "http://120.118.90.130/login.php";

    
    public void Start()
    {
        Screen.SetResolution(1440, 900, false);
        Screen.fullScreen = false;
        blockUI.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();  //嘗試連線到PUN
    }
    public override void OnConnectedToMaster(){   //已成功連線到PUN的FUNCTION
        blockUI.SetActive(false);
        loginUI.SetActive(true);  
    }
    public void playbtn(){   // LOGIN BTN按下
        loginUI.SetActive(false);
        string id = idtext.text;
        string pass = passtext.text;
        string url = "http://120.118.90.130/login.php?id="+id+"&pass="+pass;
        Debug.Log(url);
        StartCoroutine(GetRequest(url));

        // PhotonNetwork.NickName=logintext.text; //獲得ID
        // ServerUI.SetActive(true);
    }
    
    public void signbtn()  //註冊按下
        {
            Application.OpenURL ("http://120.118.90.130/signin.php");
        }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.data);
                string all = System.Text.Encoding.Default.GetString ( webRequest.downloadHandler.data );
                if(all=="error"){
                    Debug.Log("error");
                    errortext.text = "登入失敗，尚未註冊或帳密輸入失敗。";
                    loginUI.SetActive(true);
                }else{
                    Debug.Log("ok");

                    PhotonNetwork.NickName=logintext.text; //獲得ID
                    ServerUI.SetActive(true);
                }
                
            }
        }
    }
            
    
    public void JoinanRoom1(){     ///伺服器1按下加入伺服器1
        loginUI.SetActive(false);
        RoomOptions options=new RoomOptions{MaxPlayers=20}; 
        PhotonNetwork.JoinOrCreateRoom("room1",options,default);    //參數1伺服器名2人數3伺服器樣式default
    }
    public override void OnJoinedRoom(){   //當家入房間觸發的FUNCTION
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("room1");
        
        
    }
    void Update()
    {
        
    }
}
