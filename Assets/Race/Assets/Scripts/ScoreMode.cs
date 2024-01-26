using System;
using UnityEngine;
using UnityEngine.UI;
//if score gamemode is selected in the play menu, when you select the track the race will load and this script will activate
public class ScoreMode : MonoBehaviour
{
    public static int ScoreMade, ScoreModeTarget, CurrentScore;
    public int ModeSelection, InternalScore;
    public GameObject ScoreTarget, RaceUI, ScoreUI, PosDisplay, AICar, ScoreValue, ScoreObjects, WLap, TLap, ExtraTimeUI, ArrowAI, LapsDone;
    public string ScoreModeTargetString; //set in Unity inspector the minimum of score that the player needs to get to win the race

    void Start()
    {
        ModeSelection = ModeSelect.RaceMode;//import race mode selected from play menu
        //if it's 1 (score gamemode)
        if (ModeSelection == 1)
        {   //then this script will change the race objects to the score mode ones
            //UI changes to the score one
            ScoreUI.SetActive(true);
            WLap.SetActive(true);
            PosDisplay.SetActive(false);
            AICar.SetActive(false);
            ExtraTimeUI.SetActive(true);
            ArrowAI.SetActive(false);

        }
    }

    void Update()
    {
        if (ModeSelection == 1)//if score mode was selected by the user
        { 
            ScoreTarget.GetComponent<Text>().text = "/" + ScoreModeTargetString; //changes the score target UI with the one selected by the player in the inspector
            InternalScore = CurrentScore; //updates the current score of the player during the race
            ScoreValue.GetComponent<Text>().text = "" + InternalScore;
            //then, the score made text converts into an integer and it get's compared with the score target in the RaceFinish script
            ScoreMade = Convert.ToInt16(ScoreValue.GetComponent<Text>().text);
            ScoreModeTarget = Convert.ToInt16(ScoreModeTargetString);
            if (LapsDone.GetComponent<Text>().text == "2")//when the player enters to the 2nd lap:
            {
                //once 2 laps are done the warmup label is not showed anymore, and the time one appears
                WLap.SetActive(false);
                TLap.SetActive(true);
                ScoreObjects.SetActive(true);//also, the score boxes appear so you can make points
                                             //the first lap is a warmup, that's why it shows the Wlap label and doesn't have score boxes
                                             //to set up the time target in time or score mode go to TimeLimit.cs script
            }
        }
    }
}