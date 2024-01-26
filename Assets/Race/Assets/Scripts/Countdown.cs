﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//this script is used at the start of the race to show a 3, 2, 1, Go countdown
public class Countdown : MonoBehaviour
{
    public GameObject CountDown, LapTimer, CarControls;//race objects that we will use in the coroutine
    public AudioSource GetReady, GoAudio, LevelMusic;//same with audio objects

    void Start()
    {
        StartCoroutine(CountStart());//when we hit play in the first menu, this scripts activates and start the countdown coroutine
    }

    IEnumerator CountStart()
    {
        //Sets the time to 0 when the race starts
        LapTimeManager.MinuteCount = 0; LapTimeManager.SecondCount = 0; LapTimeManager.MilliCount = 0;
        //Start the Score race with 0 points
        ScoreMode.CurrentScore = 0;
        //3, 2, 1 Countdown
        yield return new WaitForSeconds(0.5f);
        CountDown.GetComponent<Text>().text = "3";//we start with the 3
        GetReady.Play();//play the ready noise (normal pitch bell)
        CountDown.SetActive(true);//and activate it in the game UI
        yield return new WaitForSeconds(1);//after one second
        CountDown.SetActive(false);//turn off the UI
        CountDown.GetComponent<Text>().text = "2";//changes to 2
        GetReady.Play();//play the ready noise (normal pitch bell)
        CountDown.SetActive(true);//and activate it in the game UI
        yield return new WaitForSeconds(1);//same process for the number 1 after another second
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "1";
        GetReady.Play();
        CountDown.SetActive(true);
        //Go
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        GoAudio.Play();
        LevelMusic.Play();
        LapTimer.SetActive(true);
        CarControls.SetActive(true);
        yield return null;
    }
}