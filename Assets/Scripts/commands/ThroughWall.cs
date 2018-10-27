using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughWall : Command
{

    public GameObject player; // the camera should follow the player and change position

    private bool isEnabled = false;

    private GameObject[] walls;

    public override void InitCommad()
    {
        
    }

    public override void Execute()
    {
        if (walls == null)
        {
            walls = GameObject.FindGameObjectsWithTag("Wall");
        }

        if (isEnabled)
        {
            this.isEnabled = false;
            DisableThroughWall();
        }
        else
        {
            this.isEnabled = true;
            EnableThroughWall();
        }
    }

    // save the start position of the play for reset
    void DisableThroughWall()
    {
        Debug.Log(" DisableThroughWall ");
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<MeshCollider>().enabled = true;
        }
    }

    void EnableThroughWall()
    {
        Debug.Log(" EnableThroughWall ");
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<MeshCollider>().enabled = false;
        }

    }
}
