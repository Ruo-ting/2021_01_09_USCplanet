using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    public Transform[] SpawnPoints;

    public float SpawnTimemax= 30f;
    public float DeleteTimemax= 18f;
    private string[] checkpoint = new string [6];
    public GameObject[] Items;
    GameObject kill;
   
    void Start()
    {

        for(int i=0;i <SpawnPoints.Length;i++){
            checkpoint[i]="unchecked";
            
        }
        InvokeRepeating("SpawnItems",Random.Range(10,SpawnTimemax),Random.Range(10,SpawnTimemax));
        InvokeRepeating("SpawnItems",Random.Range(10,SpawnTimemax),Random.Range(10,SpawnTimemax));
        InvokeRepeating("SpawnItems",Random.Range(10,SpawnTimemax),Random.Range(10,SpawnTimemax));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnItems(){
        
        int spawnIndex = Random.Range(0,SpawnPoints.Length);
        if(checkpoint[spawnIndex]=="checked"){

        }else{
            checkpoint[spawnIndex]="checked";
            int spawnIndexItems = Random.Range(0,Items.Length);
            GameObject kill = Instantiate(Items[spawnIndexItems],SpawnPoints[spawnIndex].transform.position,SpawnPoints[spawnIndex].transform.rotation);
            Destroy(kill,Random.Range(7,DeleteTimemax));
            checkpoint[spawnIndex]="unchecked";
        }
        
        
        
        
    }
    
}