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

    }

    public override void Execute()
    {
        audioSource = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AudioSource>();

        if (isEnabled) // go disable
        {
            this.isEnabled = false;
            audioSource.Stop();
            ShowMessage.SetText("Mute on");
        }
        else // go enable
        {
            this.isEnabled = true;
            audioSource.Play();
            ShowMessage.SetText("Mute off");
        }
    }

}
