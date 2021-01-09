using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemtask : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.instance.itemAmount += 1;
            Destroy(gameObject);
        }
    }
}
