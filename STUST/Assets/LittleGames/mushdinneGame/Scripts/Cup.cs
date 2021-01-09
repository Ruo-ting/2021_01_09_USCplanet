using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    /// <summary>移动速度</summary>
    public float speed = 3;
    public float maxheight;
    float a = 3;
    void Update()
    {
        
        //transform.position += Vector3.up * speed * Time.deltaTime;
        transform.Translate(a * Time.deltaTime,0, 0);
        //超出范圍
        if (transform.position.x >= maxheight)
        {
            //反向
            a = -speed;
        }
        if (transform.position.x <= -maxheight) {
            a = speed;
        }
    }
}
