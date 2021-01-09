using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushdinneMove : MonoBehaviour
{
    /// <summary>移动速度</summary>
    public float speed = 3;
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        //超出范圍
        if (transform.position.y >= 3 || transform.position.y <= -3)
        {
            //反向
            speed = -speed;
        }
    }
}

