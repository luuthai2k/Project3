﻿using System;
using UnityEngine;
using UnityEngine.UI;
//this script is used in the lap selector from the play menu scene
public class LapSelector : MonoBehaviour
{
    public GameObject LapUp, LapDown, Laps, LapsPanel;//here we declare all the buttons and labels that we are going to use
    public static int nLaps;//here we create a STATIC int to import it from the script LapsSelectedManager.cs
    public int ModeSelection;//import the game mode that player selected

    public void Update ()
    {   
        ModeSelection = ModeSelect.RaceMode;
        //activate or deactivate laps panel depending each race mode 
        if (ModeSelection == 0 || ModeSelection == 3)
        {
            LapsPanel.SetActive(true);
        }
        if (ModeSelection == 1 || ModeSelection == 2)
        {
            LapsPanel.SetActive(false);
        }
        //at the start of the game, the number of selected laps is 2
        nLaps = Convert.ToInt16(Laps.GetComponent<Text>().text);//then, we check every frame to see if the player changed the number of selected laps              
    }
    //with the + button in the game, the void Up is called and 1 more lap is added to the race
    public void Up ()
    {
        nLaps = Convert.ToInt32(Laps.GetComponent<Text>().text) + 1;//the number of selected laps goes 1 up
        Laps.GetComponent<Text>().text = Convert.ToString(nLaps);//here we convert the int to string to show it in the UI text from the laps panel
        //the max of laps its 5 and it deactivates the + button
        //IMPORTANT: if you want more than 5 laps, change the maximum down below in the if statement
        if (Laps.GetComponent<Text>().text == "5")//maximum of laps
        {
            LapUp.SetActive(false);//it deactivates the lap + button because you can't add more laps once you reach the maximum
        }
        //reactivate - button
        if (Laps.GetComponent<Text>().text == "3")
        {
            LapDown.SetActive(true);//if you go from 2 (minimum) to 3, the - button reactivates
        }
    }
    //with the - button in the game, the void Down is called and 1 lap is removed from the race
    public void Down ()
    {
        nLaps = Convert.ToInt32(Laps.GetComponent<Text>().text) - 1;//the number of selected laps goes 1 less
        Laps.GetComponent<Text>().text = Convert.ToString(nLaps);//here we convert the int to string to show it in the UI text from the laps panel
        //the min of laps its 2 and it deactivates the - button
        if (Laps.GetComponent<Text>().text == "2")
        {
            LapDown.SetActive(false);
        }
        //reactivate + button
        //IMPORTANT: if you have, for example, 6 laps: you have to put 5 in the if down below. Always 1 less than the maximum
        //By default we put 4 because our maximum of laps it's 5
        if (Laps.GetComponent<Text>().text == "4")
        {
            LapUp.SetActive(true);//if you go from 5 (maximum) to 4, the + button reactivates
        }
    }
}
