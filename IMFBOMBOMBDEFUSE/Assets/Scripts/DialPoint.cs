using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialPoint : MonoBehaviour
{
    [SerializeField] List<Lockpoints> lpoints;

    public int currentOrder;
    public int currentDialNumber;
    [SerializeField] float waitTime;
    [SerializeField] float waitTimeMax;
    [SerializeField] bool set;

    //parents
    [SerializeField] GameObject parent;
    [SerializeField] GameObject worldlock;
    [SerializeField] GameObject tp;

    private void Start()
    {
        waitTime = waitTimeMax;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Lockpoints>())
        {
            Lockpoints lp = other.GetComponent<Lockpoints>();
            if (waitTime > 0 && !set)
            {
                waitTime -= Time.deltaTime;
            }
            if (waitTime < 0 && !set)
            {
                currentDialNumber = other.GetComponent<Lockpoints>().number;
                if (lpoints[currentOrder].GetComponent<Lockpoints>().number == currentDialNumber)
                {
                    set = true;
                    waitTime = waitTimeMax;
                    currentOrder++;
                    CheckOrder();
                }
                else 
                {
                    currentOrder = 0;
                    waitTime = waitTimeMax;
                }


            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Lockpoints>())
        {
            set = false;
        }
    }

    void CheckOrder()
    {
        if(currentOrder == lpoints.Count)
        {
            tp.SetActive(true);
            worldlock.SetActive(false);
            Destroy(parent);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentOrder = 0;
            parent.SetActive(false);
        }
    }
}
