using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMessage : MonoBehaviour {

    public Text text;
	// Use this for initialization
    public static ShowMessage instance;

    private float currentTime = 0.0f;
    private float executedTime = 0.0f;
    private readonly float timeToWait = 3.0f;

    void Start()
    {
        text.text = "";
        instance = this;
    }

    void Update()
    {
        currentTime = Time.time;

        if (executedTime != 0.0f)
        {
            if (currentTime - executedTime > timeToWait)
            {
                executedTime = 0.0f;
                text.text = "";
            }
        }
    }



    private void OnDestroy()
    {
        Destroy(instance);
    }

    // Update is called once per frame
    public static void SetText (string content) {
        instance.text.text = content;
        instance.executedTime = Time.time;
    }

}
