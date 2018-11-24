using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogEffect : Command
{

    private bool isEnabled = true;

    private GameObject[] walls;

    private GameObject[] floors;

    public float fogIntensity = 0.18f;

    public override void InitCommad()
    {
        // walls are not init yet
    }

    public override void Execute()
    {   

        walls = GameObject.FindGameObjectsWithTag("Wall");
        floors = GameObject.FindGameObjectsWithTag("Floor");
        
        if (isEnabled)
        {
            this.isEnabled = false;
            DisableFogEffect();
        }
        else
        {
            this.isEnabled = true;
            EnableFogEffect();
        }
    }

    void EnableFogEffect()
    {
        Debug.Log("EnableFogEffect");
        this.SetFogForAll(this.fogIntensity);
    }

    void DisableFogEffect()
    {
        Debug.Log("EnableFogEffect");
        this.SetFogForAll(0);
    }

    void SetFogForAll(float intensity)
    {
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<Renderer>().material.SetFloat("_FogIntensity", intensity);
        }
        foreach (GameObject f in floors)
        {
            f.GetComponent<Renderer>().material.SetFloat("_FogIntensity", intensity);
        }
    }
}
