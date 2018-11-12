using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Console/Commands/Exit")]
public class Exit : ConsoleCommand
{
    // keyWord = "exit";

    public override void RespondToInput(ConsoleManager console, string[] separatedInputWords)
    {
        GameObject currentConsole = GameObject.FindWithTag("Console") as GameObject;

        Debug.Log("exit(hide) console : " + (currentConsole !=null));
        // currentConsole.SetActive(false);

        Destroy(currentConsole);
        UIManager.isConsoleActived = false;
        Time.timeScale = 1;
    }
}