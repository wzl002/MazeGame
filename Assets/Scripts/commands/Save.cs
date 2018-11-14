using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : Command
{


    public override void InitCommad()
    {
    }

    public override void Execute()
    {
        Storage.Save();
    }

}
