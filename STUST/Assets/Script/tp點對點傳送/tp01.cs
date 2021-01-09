using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using System.Threading; 
public class tp01 :  MonoBehaviourPunCallbacks
{
    public void OnTriggerStay(Collider other){
        
        if(other.gameObject.CompareTag("Player")){  
            Staticcode.Teleport="tp01";
            PhotonNetwork.Destroy(other.gameObject);
            
            PhotonNetwork.LeaveRoom();
            
            PhotonNetwork.LoadLevel("room1"); 
           
            
        }
        
    }
   
}
