using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : Command {

    private AudioSource audioSource;

    public AudioClip dayMusic;

    public AudioClip nightMusic;

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
            audioSource.clip = nightMusic;
            audioSource.Play();
        }
        else // go enable
        {
            this.isEnabled = true;
            audioSource.clip = dayMusic;
            audioSource.Play();
        }
    }
}
