using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScreenshot : MonoBehaviour
{
    public SnapShotCamera snapCam;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            snapCam.CallTakeSnapshot();
        }
    }
}
