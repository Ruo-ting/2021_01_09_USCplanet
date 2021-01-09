using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
public class Camlookat : MonoBehaviourPun
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(60,8,52);
        transform.eulerAngles = new Vector3(1,37,-2);
        transform.position=player.transform.position;
        
    }
}
