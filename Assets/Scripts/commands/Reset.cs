using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : Command
{

    public GameObject player; // the camera should follow the player and change position

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
        rotation = pTransForm.rotation;

        Debug.Log(" LogStartPosition " + pTransForm.position);
    }

    void ResetLocation()
    {
        Debug.Log(" ResetLocation ");
        player.transform.position = position;
        player.transform.rotation = rotation;
    }


}
