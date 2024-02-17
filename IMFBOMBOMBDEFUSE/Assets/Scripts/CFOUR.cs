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
    bool bombEnabled = true;
    [SerializeField] AudioClip fastTick;

    [SerializeField] GameObject rawImage, Videoplayer;
    //
    public enum WireCombos { R2G1B1 , R1G1B1Y1 , G1B2Y1, R1G2Y1 }
    public WireCombos wireCombo; 



    public List<wire> wires;
    //public int[] number;

    //CutOrder
    public int currentCutOrder = 1;

    //Explosion

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
        wireCombo = (WireCombos)UnityEngine.Random.Range(0, Enum.GetValues(typeof(WireCombos)).Length);

        
        
        //number = new int[4];
        switch(wireCombo)
        {
            case WireCombos.R2G1B1:
                SetWireColor(wires[0], "Red",1 );
                SetWireColor(wires[1], "Red",2);
                SetWireColor(wires[2], "Green",3);
                SetWireColor(wires[3], "Blue",4);
                break;

            case WireCombos.R1G1B1Y1:
                SetWireColor(wires[0], "Red",4);
                SetWireColor(wires[1], "Blue",3);
                SetWireColor(wires[2], "Green",2);
                SetWireColor(wires[3], "Yellow",1);
                break;

            case WireCombos.R1G2Y1:
                SetWireColor(wires[0], "Red",2);
                SetWireColor(wires[1], "Green",1);
                SetWireColor(wires[2], "Green",3);
                SetWireColor(wires[3], "Yellow",4);
                break;

            case WireCombos.G1B2Y1:
                SetWireColor(wires[0], "Green", 3);
                SetWireColor(wires[1], "Blue", 1);
                SetWireColor(wires[2], "Blue", 2);
                SetWireColor(wires[3], "Yellow", 4);
                break;

            default:
                Debug.Log("Defaulted");
                break;

        }
        //currentCutOrder = 0;
        //Array.Sort(number);

    }

    void SetWireColor(wire currentWire, string color, int cutOrder)
    {   
        
        currentWire.SetWireColor(color, cutOrder);
        //int order = (int)Enum.Parse(typeof(wireColor), color);

        /*
        if (!number.Contains(order))
        {
            currentWire.cutOrder = order;
            number[currentCutOrder] = order;
        }
        else
        {
            currentWire.cutOrder = order + 1;
            number[currentCutOrder] = order + 1;
        }
        currentCutOrder++;
        */
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
    }

    private void Update()
    {
        if (bombEnabled)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                var time = TimeSpan.FromSeconds(currentTime);
                timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString("00");
            }
            else
            {
                bombEnabled = false;
                bombSound.enabled = false;
                currentTime = 0;
                timerText.text = "00:00";

                StartCoroutine(triggerExplosion());
            }
        }

        if(currentTime>0 && currentCutOrder > wires.Count)
        {
            bombEnabled = false;
            timerText.text = "XX:XX";
            bombSound.enabled = false;
        }
    }

    IEnumerator triggerExplosion()
    {
        bombSound.enabled = true;
        bombSound.PlayOneShot(fastTick);
        yield return new WaitForSeconds(2f);
        rawImage.SetActive(true);
        Videoplayer.SetActive(true);
        //gameObject.SetActive(false);
    }
}
