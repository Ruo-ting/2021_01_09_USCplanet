using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public Animator anim;   //動畫控制器
    public float Hor, Ver;//讀取方位值
    public float play_rotion;//暫存方向
                             // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        play_rotion = 0;
        Hor = Input.GetAxis("Horizontal");//水平方位
        Ver = Input.GetAxis("Vertical");//垂直方位       
        if (Ver > 0)//前
        {
            play_rotion = 0;
        }
        else if (Ver < 0)//後
        {
            play_rotion = 180;
        }
        else if (Hor > 0)//右
        {
            play_rotion = 90;
        }
        else if (Hor < 0)//左
        {
            play_rotion = 270;
        }
        if ((Hor != 0) || (Ver != 0))//當有按方向鍵時
        {
            transform.eulerAngles = new Vector3(0, play_rotion, 0);//設定方向
            anim.SetBool("Walk", true);//開啟動畫
            transform.position = transform.position + transform.forward * Time.deltaTime;//座標移動
        }
        else
        {
            anim.SetBool("Walk", false);//關閉動畫
        }
    }
}