using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : Command
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
            audioSource.Stop();
        }
        else // go enable
        {
            this.isEnabled = true;
            audioSource.Play();
        }
    }

}
