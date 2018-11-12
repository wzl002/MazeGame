using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    // save command list as key value pairs.
    private static List<Command> commands = new List<Command>();

    public float inputDelta = 0.1F;

    private float nextInput = 0.5F;
    private float lastInputTime = 0.0F;

    public static void RegisterCommand(Command command)
    {
        commands.Add(command);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKey)
        //{
        //    Debug.Log("Input get : " + Input.inputString);
        //}

        lastInputTime = lastInputTime + Time.deltaTime;

        if (lastInputTime > nextInput)
        {
            foreach (Command c in commands)
            {

                if (Input.GetButtonDown(c.inputName)) // detect input key
                {
                    nextInput = lastInputTime + inputDelta;

                    c.Execute(); // excute command

                    nextInput = nextInput - lastInputTime;
                    lastInputTime = 0.0F;
                }
            }
        }
    }
}
