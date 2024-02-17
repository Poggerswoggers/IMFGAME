using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool AutoStart = false;
    public Text UITimer;

    public GameObject TheEnd, TimerendText, Paused;
    public AudioSource audio;
    public AudioClip clip, pauseclip;

    [HideInInspector]
    public bool timerIsRunning = false;

    private void Start()
    {
       if(AutoStart) timerIsRunning = true;
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void TogglePauseTimer()
    {
        timerIsRunning = !timerIsRunning;

        
        if (timerIsRunning)
        {
            //add code here
            Paused.SetActive(false);
        }
        else
        {
            //add code here
            Paused.SetActive(true);

            //pause audio
            if (audio)
            {
                audio.Stop();
                audio.PlayOneShot(pauseclip);
            }
        }

     
    }

    public void TimerRunOut()
    {
        TheEnd.SetActive(true);
        TimerendText.SetActive(true);
        audio.Stop();
        audio.PlayOneShot(clip);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePauseTimer();
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(timeRemaining / 60);
                float seconds = Mathf.FloorToInt(timeRemaining % 60);
                if(UITimer) UITimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                TimerRunOut();
                timeRemaining = 0;
                float minutes = Mathf.FloorToInt(timeRemaining / 60);
                float seconds = Mathf.FloorToInt(timeRemaining % 60);
                if (UITimer) UITimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                timerIsRunning = false;
            }
        }
    }
}