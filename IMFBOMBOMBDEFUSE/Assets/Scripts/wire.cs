using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class wire : UseItemOnThis
{
    public int cutOrder;

    [SerializeField] CFOUR c4;

    public MeshRenderer mr;
    public enum wireColor
    {
        None,
        Red,
        Blue,
        Yellow,
        Green
    }
    public wireColor thisWireColor = wireColor.None;



    public void SetWireColor(string color)
    {
        thisWireColor = (wireColor)Enum.Parse(typeof(wireColor), color);

        switch(thisWireColor)
        {
            case wireColor.Red:
                mr.material.color = Color.red;
                break;

            case wireColor.Blue:
                mr.material.color = Color.blue;
                break;

            case wireColor.Yellow:
                mr.material.color = Color.yellow;
                break;

            case wireColor.Green:
                mr.material.color = Color.green;
                break;
                
        }
    }


    public override void DoesntWork()
    {
        //nothing
    }

    public override void FirstUnlockInstance()
    {

        if(cutOrder != c4.currentCutOrder)
        {
            c4.currentTime = 0;
        }
        //maybe add spark particle

        SetItemAsUsed();
    }

    public override void SubsequentActivation_IfAny()
    {
        //nothing
    }
}
