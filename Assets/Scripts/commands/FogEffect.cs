using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogEffect : Command
{

    public GameObject player;

    private bool isEnabled = false;

    public override void InitCommad()
    {
        // 
    }

    public override void Execute()
    {
        if (isEnabled)
        {
            DisableFogEffect();
            isEnabled = false;
        }
        else
        {
            EnableFogEffect();
            isEnabled = true;
        }
    }
    
    void EnableFogEffect()
    {

    }

    void DisableFogEffect()
    {
    }
}
