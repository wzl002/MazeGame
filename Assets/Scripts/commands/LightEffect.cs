using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : Command
{

    private bool isEnabled = true;

    private GameObject[] walls;

    private GameObject[] floors;

    public Color dayAmbient;

    public Color nightAmbient;

    public Material daySkyBox;

    public Material nightSkyBox;

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
            DisableLightEffect();
        }
        else
        {
            this.isEnabled = true;
            EnableLightEffect();
        }
    }

    void EnableLightEffect()
    {
        Debug.Log("EnableFogEffect");
        this.SetFogForAll(this.dayAmbient);

        RenderSettings.skybox = daySkyBox;
    }

    void DisableLightEffect()
    {
        Debug.Log("EnableFogEffect");
        this.SetFogForAll(this.nightAmbient);

        RenderSettings.skybox = nightSkyBox;
    }

    void SetFogForAll(Color ambient)
    {
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<Renderer>().material.SetColor("_Ambient", ambient);
        }
        foreach (GameObject f in floors)
        {
            f.GetComponent<Renderer>().material.SetColor("_Ambient", ambient);
        }
    }
}
