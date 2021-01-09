using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EyesColor : MonoBehaviour
{
    public  GameObject BoyFace, GirlFace;
    
    public  GameObject BoyShoes, BoyShoes2;
    
    public  GameObject GirlShoes, GirlShoes2;
    
    public  GameObject GirlClothes, BoyClothes;

    public  GameObject Boypants;
    
    public  Texture2D[] eyes;
    public  Texture2D[] shoes;
    public  Texture2D[] Girlclothes;
    public  Texture2D[] Boyclothes;
    public  Texture2D[] pants;
    private int currenteyes;
    private int currentshoes;
    private int currentGirlclothes;
    private int currentBoyclothes;
    private int currentpants;


    private void Update()
    {
        for (int i = 0; i < eyes.Length; i++)
        {
            if (i == currenteyes)
            {
                BoyFace.GetComponent<Renderer>().material.mainTexture = eyes[i];
                GirlFace.GetComponent<Renderer>().material.mainTexture = eyes[i];
            }
            
        }
        for (int i = 0; i < shoes.Length; i++)
        {
            if (i == currentshoes)
            {
                BoyShoes.GetComponent<Renderer>().material.mainTexture = shoes[i];
                BoyShoes2.GetComponent<Renderer>().material.mainTexture = shoes[i];
                GirlShoes.GetComponent<Renderer>().material.mainTexture = shoes[i];
                GirlShoes2.GetComponent<Renderer>().material.mainTexture = shoes[i];
            }

        }
        for (int i = 0; i < Girlclothes.Length; i++)
        {
            if (i == currentGirlclothes)
            {
                GirlClothes.GetComponent<Renderer>().material.mainTexture = Girlclothes[i];
            }
        }
        for (int i = 0; i < Boyclothes.Length; i++)
        {
            if (i == currentBoyclothes)
            {
                BoyClothes.GetComponent<Renderer>().material.mainTexture = Boyclothes[i];
            }
        }
        for (int i = 0; i < pants.Length; i++)
        {
            if (i == currentpants)
            {
                Boypants.GetComponent<Renderer>().material.mainTexture = pants[i];
            }
        }

    }
    public void SwitchEyes()
    {

        if (currenteyes == eyes.Length - 1)
        {
            currenteyes = 0;
        }
        else
        {
            currenteyes++;
        }
    }
    public void SwitchShoes()
    {

        if (currentshoes == shoes.Length - 1)
        {
            currentshoes = 0;
        }
        else
        {
            currentshoes++;
        }
    }
    public void SwitchGirlClothes()
    {
        if (currentGirlclothes == Girlclothes.Length - 1)
        {
            currentGirlclothes = 0;
        }
        else
        {
            currentGirlclothes++;
        }
    }
    public void SwitchBoyClothes()
    {
        if (currentBoyclothes == Boyclothes.Length - 1)
        {
            currentBoyclothes = 0;
        }
        else
        {
            currentBoyclothes++;
        }
    }
    public void SwitchPants()
    {
        if (currentpants == pants.Length - 1)
        {
            currentpants = 0;
        }
        else
        {
            currentpants++;
        }
    }
}





