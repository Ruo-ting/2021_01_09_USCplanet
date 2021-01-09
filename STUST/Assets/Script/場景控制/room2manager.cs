using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
public class room2manager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
         PhotonNetwork.ConnectUsingSettings();   //連上photon
         Staticcode.Chatregionchannel="room2";   //區域頻道設置
    }
    public override void OnConnectedToMaster(){   //已成功連線到PUN的FUNCTION
        RoomOptions options=new RoomOptions{MaxPlayers=20}; 
        
        PhotonNetwork.JoinOrCreateRoom("room2",options,default);  
        
    }
    public override void OnJoinedRoom(){   //當家入房間觸發的FUNCTION
        
        if(Staticcode.Teleport=="tp02center"){
            GameObject spawn = (GameObject)PhotonNetwork.Instantiate("boy", new Vector3(25,7,44),Quaternion.Euler(0f, 25f, 0f),0);
        }else{
            GameObject spawn = (GameObject)PhotonNetwork.Instantiate("boy", new Vector3(25, 7, 44), Quaternion.Euler(0f, 25f, 0f),0);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
