using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : Command
{

    public GameObject player; // the camera should follow the player and change position

    public GameObject playerCamera; // the camera 

    private Vector3 position;
    private Quaternion rotation;

    public override void InitCommad()
    {
        LogStartPosition();
    }
    
    public override void Execute()
    {
        ResetLocation();
    }

    // save the start position of the play for reset
    void LogStartPosition()
    {
        
        Transform pTransForm = player.transform;
        position = pTransForm.position;
        rotation = pTransForm.localRotation;

        Debug.Log(" LogStartPosition " + pTransForm.position);
    }

    void ResetLocation()
    {
        Debug.Log(" ResetLocation ");
        player.transform.position = position;
        player.transform.localRotation = rotation;
        playerCamera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        player.GetComponent<FirstPersonController>().ResetSetView();
    }


}
