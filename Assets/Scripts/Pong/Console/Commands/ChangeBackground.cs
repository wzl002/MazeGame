using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Console/Commands/Changebg")]
public class ChangeBackground : ConsoleCommand
{
    // keyWord = "color";

    public override void RespondToInput(ConsoleManager console, string[] separatedInputWords)
    {
        GameObject gameBackground = GameObject.Find("Env/Ground");

        if (separatedInputWords.Length > 1)
        {
            string color = separatedInputWords[1].ToLower();
            if (color == "d")
            {
                gameBackground.GetComponent<Renderer>().material.color = Color.black;
            }
            if (color == "b")
            {
                gameBackground.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (color == "r")
            {
                gameBackground.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}