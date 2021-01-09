using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterchange : MonoBehaviour
{
    public GameObject boy,girl;
    

    private void Start()
    {
        boy.SetActive(true);
        girl.SetActive(false);
    }
    public void ChangeGirl()
    {
        girl.SetActive(true);
        boy.SetActive(false);
    }
    public void ChangeBoy()
    {
        boy.SetActive(true);
        girl.SetActive(false);
    }

}
