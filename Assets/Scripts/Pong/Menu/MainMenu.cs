using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SinglePlayerCLick()
    {
        Debug.Log(" signle !");
    }

    public void MutiplePlayerCLick()
    {
        Debug.Log(" MutiplePlayerCLick !");
    }

    public void ExitCLick()
    {
        Debug.Log(" ExitCLick !");
        Application.Quit();
    }

}
