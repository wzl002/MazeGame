using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Console/Commands/Quit")]
public class Quit : ConsoleCommand
{

    public override void RespondToInput(ConsoleManager console, string[] separatedInputWords)
    {
        Application.Quit();
    }
}