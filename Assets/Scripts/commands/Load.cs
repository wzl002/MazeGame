using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : Command
{
    
    public override void InitCommad()
    {
    }

    public override void Execute()
    {
        Storage.Load();
    }

}