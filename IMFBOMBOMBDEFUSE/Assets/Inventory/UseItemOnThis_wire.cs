using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemOnThis_wire : UseItemOnThis
{
    public override void DoesntWork()
    {
        //nothing
    }

    public override void FirstUnlockInstance()
    {

        gameObject.SetActive(false);
        //maybe add spark particle

        SetItemAsUsed();
    }

    public override void SubsequentActivation_IfAny()
    {
       //nothing
    }
   
}
