using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Command {

    private bool isEnabled = true;

    private GameObject[] walls;

    private GameObject[] floors;

    public Color flashLightColor;

    public Color offColor;

    public override void InitCommad()
    {
        // walls are not init yet
    }

    public override void Execute()
    {
        if (walls == null)
        {
            walls = GameObject.FindGameObjectsWithTag("Wall");
            floors = GameObject.FindGameObjectsWithTag("Floor");
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
        this.SetFlashLightForAll(this.flashLightColor);
    }

    void DisableFlashLight()
    {
        Debug.Log("EnableFogEffect");
        this.SetFlashLightForAll(this.offColor);
    }

    void SetFlashLightForAll(Color color)
    {
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<Renderer>().material.SetColor("_FlashColor", color);
        }
        foreach (GameObject f in floors)
        {
            f.GetComponent<Renderer>().material.SetColor("_FlashColor", color);
        }
    }
}
