using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class LeaveBtn : MonoBehaviour
{
    public void leave(){
        SceneManager.LoadScene(0);
        PhotonNetwork.LeaveRoom();
        Debug.Log("成功離開房間");
    }
}
