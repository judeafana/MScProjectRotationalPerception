using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script quits the application once done with the last level 


public class QuitApp : MonoBehaviour
{
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            Application.Quit();
        }
    }
}
