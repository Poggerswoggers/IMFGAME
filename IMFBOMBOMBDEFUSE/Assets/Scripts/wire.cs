using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class wire : MonoBehaviour
{
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

    private void OnMouseOver()
    {
        Debug.Log("HEHEHEHAR");
    }
}
