using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CFOUR : MonoBehaviour
{
    //Timer
    [SerializeField] float maxTime;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] AudioSource bombSound;
    public float currentTime;
    //
    public enum WireCombos { R2G1B1 , R1G1B1Y1 , G1B2Y1 }
    public WireCombos wireCombo; 



    public List<wire> wires;


    private void Start()
    {
        currentTime = maxTime;
        bombSound.enabled = true;

        InitialiseWireCombo();
    }

    void InitialiseWireCombo()
    {        

        switch(wireCombo)
        {
            case WireCombos.R2G1B1:
                SetWireColor(wires[0], "Red" );
                SetWireColor(wires[1], "Red");
                SetWireColor(wires[2], "Green");
                SetWireColor(wires[3], "Blue");
                break;

            case WireCombos.R1G1B1Y1:
                SetWireColor(wires[0], "Red");
                SetWireColor(wires[1], "Blue");
                SetWireColor(wires[2], "Blue");
                SetWireColor(wires[3], "Yellow");
                break;

        }
    }

    void SetWireColor(wire currentWire, string color)
    {
        currentWire.SetWireColor(color);
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
