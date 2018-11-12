using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject console;

    public static bool isConsoleActived = false;

    // Use this for initialization
    void Start () {
		
	}

    //Update is called every frame.
    void FixedUpdate()
    {
        float key = Input.GetAxis("CallConsole");

        if (key > 0 && !isConsoleActived)
        {
            isConsoleActived = true;
            Time.timeScale = 0;
            var createConsole = Instantiate(console) as GameObject;
            createConsole.transform.SetParent(gameObject.transform, false);
        }
    }
}
