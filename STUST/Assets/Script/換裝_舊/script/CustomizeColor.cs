using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeColor : MonoBehaviour
{
    public Color[] headColors;
    public Material BoyheadMat;
    public Material GirlheadMat;

    public void ChangeHeadColor(int colorIndex) {
        BoyheadMat.color = headColors[colorIndex];
        GirlheadMat.color = headColors[colorIndex];
    }
}
