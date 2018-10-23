using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : MonoBehaviour
{

    // key name in input manager for this command
    public string inputName;


    void Start()
    {
        InputHandler.RegisterCommand(this);
        InitCommad();
    }

    abstract public void InitCommad();

    abstract public void Execute();

}