using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CFOUR : MonoBehaviour
{
    [SerializeField] float maxTime;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] AudioSource bombSound;
    public float currentTime;

    private void Start()
    {
        currentTime = maxTime;
        bombSound.enabled = true;
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
