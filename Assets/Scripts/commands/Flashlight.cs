using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Command {

    private bool isEnabled = true;

    private GameObject spotLight;

    public override void InitCommad()
    {
        // walls are not init yet

    }

    public override void Execute()
    {
        if(spotLight == null)
        {
            spotLight = GameObject.Find("Spotlight");
        }
        if (isEnabled)
        {
            this.isEnabled = false;
            DisableFlashLight();
        }
        else
        {
            this.isEnabled = true;
            EnableFlashLight();
        }
    }

    void EnableFlashLight()
    {
        Debug.Log("EnableFogEffect");
        spotLight.GetComponent<Light>().enabled = true;
    }

    void DisableFlashLight()
    {
        Debug.Log("EnableFogEffect");
        spotLight.GetComponent<Light>().enabled = false;
    }

}
