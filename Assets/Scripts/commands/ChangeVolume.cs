using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolume : Command
{

    private AudioSource audioSource;

    private bool isEnabled = true;

    public override void InitCommad()
    {
        
    }

    public override void Execute()
    {
        audioSource = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AudioSource>();

        if (isEnabled) // go disable
        {
            this.isEnabled = false;
            audioSource.volume = 1;
        }
        else // go enable
        {
            this.isEnabled = true;
            audioSource.volume = 0.5f;
        }
    }

}
