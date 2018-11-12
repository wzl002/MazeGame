using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsoleCommand: ScriptableObject
{
    public string keyWord;

    public abstract void RespondToInput(ConsoleManager console, string[] separatedInputWords);
}