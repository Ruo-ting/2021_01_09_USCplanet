using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading; 
using Photon.Realtime;
public class GameManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();   //連上photon
        Staticcode.Chatregionchannel="room1";   //區域頻道設置
    }
    public override void OnConnectedToMaster(){   //已成功連線到PUN的FUNCTION
        RoomOptions options=new RoomOptions{MaxPlayers=20}; 
        
        PhotonNetwork.JoinOrCreateRoom("room1", options,default);  
        
    }
    public override void OnJoinedRoom(){   //當家入房間觸發的FUNCTION
    
        if(Staticcode.Teleport=="tp01"){
            GameObject spawn = (GameObject)PhotonNetwork.Instantiate("boy", new Vector3(45,-9,67),Quaternion.Euler(0f, 25f, 0f),0);
        }
        else if(Staticcode.Teleport=="tp01center"){
            GameObject spawn = (GameObject)PhotonNetwork.Instantiate("boy", new Vector3(65, -9, 67),Quaternion.Euler(0f, 25f, 0f),0);
        }
        else{
            GameObject spawn = (GameObject)PhotonNetwork.Instantiate("boy", new Vector3(65, -9, 67),Quaternion.Euler(0f, 25f, 0f),0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    // private IEnumerator InstantiateObjectDelayed()
    // {
    //     yield return new WaitForSeconds(0.5f);
    //     GameObject spawn = (GameObject)PhotonNetwork.Instantiate("Unitychan",new Vector3(12,3,-60),Quaternion.identity,0);
    // }
}
