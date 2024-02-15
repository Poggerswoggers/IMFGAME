using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class CFOUR : MonoBehaviour
{
    //Timer
    [SerializeField] float maxTime;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] AudioSource bombSound;
    public float currentTime;
    //
    public enum WireCombos { R2G1B1 , R1G1B1Y1 , G1B2Y1, R1G2B1Y1 }
    public WireCombos wireCombo; 



    public List<wire> wires;
    List<int> number;

    private enum wireColor
    {
        Red,
        Blue,
        Yellow,
        Green
    }
    wireColor wc;
    private void Start()
    {
        currentTime = maxTime;
        bombSound.enabled = true;

        InitialiseWireCombo();
    }

    void InitialiseWireCombo()
    {
        number = new List<int>(4);
        switch(wireCombo)
        {
            case WireCombos.R2G1B1:
                SetWireColor(wires[0], "Red" );
                SetWireColor(wires[1], "Green");
                SetWireColor(wires[2], "Red");
                SetWireColor(wires[3], "Blue");
                break;

            case WireCombos.R1G1B1Y1:
                SetWireColor(wires[0], "Red");
                SetWireColor(wires[1], "Blue");
                SetWireColor(wires[2], "Green");
                SetWireColor(wires[3], "Yellow");
                break;

            case WireCombos.R1G2B1Y1:
                SetWireColor(wires[0], "Red");
                SetWireColor(wires[1], "Green");
                SetWireColor(wires[2], "Green");
                SetWireColor(wires[3], "Yellow");
                break;

            default:
                Debug.Log("Defaulted");
                break;

        }

    }

    void SetWireColor(wire currentWire, string color)
    {   

        currentWire.SetWireColor(color);
        int order = (int)Enum.Parse(typeof(wireColor), color);

        if (!number.Contains(order))
        {
            currentWire.cutOrder = order;
            number.Add(order);
        }
        else
        {
            currentWire.cutOrder = order + 1;
            number.Add(order+1);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            var time = TimeSpan.FromSeconds(currentTime);
            timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString("00");
        }
        else
        {
            bombSound.enabled = false;
            currentTime = 0;
            timerText.text = 00 + ":" + 00;
        }
    }
}
