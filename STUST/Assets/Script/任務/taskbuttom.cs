using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskbuttom : MonoBehaviour
{
    public static taskbuttom instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);

    }
    public GameObject mytask;
    public void taskOpenorClose()
    {
        if (basemove.instance.isTalking == true)
        {
            mytask.SetActive(!mytask.activeInHierarchy);
        }


    }
}
