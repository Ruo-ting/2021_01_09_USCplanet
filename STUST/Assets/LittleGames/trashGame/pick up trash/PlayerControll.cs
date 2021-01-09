using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerControll : MonoBehaviour
{
    public int m_ScoreValue = 0;
    public float m_TimeValue = 0;

    public Text m_Score = null;
    public Text m_Time = null;

    public Transform m_Bagobj = null;
    public GameObject m_Overobj = null;

    

    
    private bool m_IsGameOver = false;

    public float GetNowTime()
    {
       return m_TimeValue;
    }

    void Start()
    {
        Refresh();
    }

    public void Die()
    {
        Time.timeScale = 0;
        m_IsGameOver = true;
        m_Overobj.SetActive(true);
        
    }

    public void AddScore(int add)
    {
        m_ScoreValue += add;
        Refresh();
    }

    private void Refresh()
    {
        m_Score.text = "分數:" + m_ScoreValue;
    }


    // Update is called once per frame
    void Update()
    {
        if (m_IsGameOver)
        {
            
            return;
        }

        m_TimeValue += Time.deltaTime;
        m_Time.text = "時間  :" + m_TimeValue.ToString("0.0");

        if (Input.GetKey(KeyCode.A) && transform.localPosition.x > -500)
        {
            transform.localPosition += new Vector3(-500, 0, 0) * Time.deltaTime;
            //m_Bagobj.localPosition = new Vector3(90, 60, 0);
            transform.localScale = new Vector2(1f, 1f);
        }
        if (Input.GetKey(KeyCode.D) && transform.localPosition.x < 500)
        {

            transform.localPosition += new Vector3(500, 0, 0) * Time.deltaTime;
            //m_Bagobj.localPosition = new Vector3(-90, 60, 0);
            transform.localScale = new Vector2(-1f, 1f);
        }
        



    }
    public void ExitGame()
    {
        Staticcode.Teleport = "tp01center";
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("room1");
    }




}
