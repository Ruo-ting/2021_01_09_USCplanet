using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_move : MonoBehaviour
{
    public float speed = 3;
    public float maxheight;
    float a = 3;
    void Update()
    {

        //transform.position += Vector3.up * speed * Time.deltaTime;
        transform.Translate(a * Time.deltaTime, 0, 0);
        //超出范圍
        if (transform.position.y >= maxheight)
        {
            //反向
            a = -speed;
        }
        if (transform.position.y <= -maxheight)
        {
            a = speed;
        }
    }
}
