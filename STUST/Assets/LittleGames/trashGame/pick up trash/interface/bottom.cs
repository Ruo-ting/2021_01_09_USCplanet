using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class bottom : MonoBehaviour
{
    public void mapGoroom1btn()
    {
        Staticcode.Teleport = "tp01center";
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("room1");
    }
    public void gameAccept()
    {
        SceneManager.LoadScene("1");
    }

}
