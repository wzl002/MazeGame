using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolume : Command
{

    private AudioSource audioSource;

    private bool isEnabled = true;

    public GameObject audioBinder;

    public override void InitCommad()
    {
        audioSource = audioBinder.GetComponent<AudioSource>();
    }

    public override void Execute()
    {
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
