using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Console/Commands/SetBallSpeed")]
public class SetBallSpeed : ConsoleCommand
{
    public override void RespondToInput(ConsoleManager console, string[] separatedInputWords)
    {
        if (separatedInputWords.Length > 1)
        {
            try
            {
                float speed = float.Parse(separatedInputWords[1].ToLower());
                Ball.speed = speed;
            }
            catch (Exception e)
            {

            }
        }
    }
}