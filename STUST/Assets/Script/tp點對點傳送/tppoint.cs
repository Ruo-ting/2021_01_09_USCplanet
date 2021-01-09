using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using System.Threading; 
public class tppoint :  MonoBehaviourPunCallbacks
{
    public void OnTriggerStay(Collider other){
        
        if(other.gameObject.CompareTag("Player")){  
            Staticcode.Teleport="tp02";
            PhotonNetwork.Destroy(other.gameObject);

            PhotonNetwork.LeaveRoom();
            
            PhotonNetwork.LoadLevel("room2"); 
           
            
        }
        
    }
}
