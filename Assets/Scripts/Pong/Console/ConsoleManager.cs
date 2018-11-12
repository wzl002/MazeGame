using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour
{

    public Text displayText;
    public ConsoleCommand[] commands;
   
    List<string> actionLog = new List<string>();

    // Use this for initialization
    void Awake()
    {
    }

    void Start()
    {
        // gameObject.SetActive(false);
        // DisplayLoggedText();
        actionLog.Add(displayText.text); // add orgin text;
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());

        displayText.text = logAsText;
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

    // Update is called once per frame
    void Update()
    {

    }
}