using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Console/Commands/MutiplePlyaer")]
public class MutiplePlyaer : ConsoleCommand
{
    
    public override void RespondToInput(ConsoleManager console, string[] separatedInputWords)
    {
        GameObject currentConsole = GameObject.FindWithTag("Console") as GameObject;

        
    }
}