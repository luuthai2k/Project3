using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//this script is used in time and score gamemodes because runs when the time limit of the race is reached
public class TimeLimit : MonoBehaviour
{
    public int ModeSelection;//import the game mode selected by the player in the play menu
    public GameObject LapsDone, SecondCount, MinuteCount, FinishPanel2, PauseButton, Panel1, Panel2, Panel3, LapPanel, ExtraTimeUI;//UI that will turn off
    public GameObject LevelMusic;//turn off the level music
    public GameObject TimeObject; //turn off time manager so you can't unpause the time limit lose panel
    public GameObject ViewModes;//turn off the viewmodes object so the player can't change the camera
    public GameObject TimeModeTimeLimitUI, ScoreModeTimeLimitUI;//time limit UI for each game mode
    //these strings can be changed from the inspector and you can select the minutes and seconds for the time limit in score and time gamemode
    public string SecTimeModeLimit;
    public string SecScoreModeLimit;
    public string MinTimeModeLimit;
    public string MinScoreModeLimit;

    void Update()
    {
        ModeSelection = ModeSelect.RaceMode;//import race mode selected from play menu
        StartCoroutine(wait());
        //shows the time limit of the score mode in the UI
        ScoreModeTimeLimitUI.GetComponent<Text>().text = "Time Limit: " + MinScoreModeLimit + ":" + SecScoreModeLimit + ".0";
        //shows the time limit of the time mode in the UI
        TimeModeTimeLimitUI.GetComponent<Text>().text = "Time Limit: " + MinTimeModeLimit + ":" + SecTimeModeLimit + ".0";
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        //time limit in score mode
        if (ModeSelection == 1)
        {
            //once you finished the first warmup lap, the second lap it's the time one
            if (LapsDone.GetComponent<Text>().text == "2")
            {
                //when the player reachs the time limit, the time is out (you can change the number via inspector)
                if (MinuteCount.GetComponent<Text>().text == MinScoreModeLimit + ":" && SecondCount.GetComponent<Text>().text == SecScoreModeLimit + ".")
                {
                    TimeObject.SetActive(false);
                    PauseButton.SetActive(false);
                    Panel1.SetActive(false);
                    Panel2.SetActive(false);
                    Panel3.SetActive(false);
                    LapPanel.SetActive(false);
                    LevelMusic.SetActive(false);
                    ViewModes.SetActive(false);
                    ExtraTimeUI.SetActive(false);
                    FinishPanel2.SetActive(true);
                    AudioListener.volume = 0f;
                    Time.timeScale = 0;
                }
            }
        }
        //time limit in time mode
        if (ModeSelection == 2)
        {
            if (LapsDone.GetComponent<Text>().text == "2")
            {
                if (MinuteCount.GetComponent<Text>().text == MinTimeModeLimit + ":" && SecondCount.GetComponent<Text>().text == SecTimeModeLimit + ".")
                {
                    TimeObject.SetActive(false);
                    PauseButton.SetActive(false);
                    Panel1.SetActive(false);
                    Panel2.SetActive(false);
                    Panel3.SetActive(false);
                    LapPanel.SetActive(false);
                    LevelMusic.SetActive(false);
                    ViewModes.SetActive(false);
                    ExtraTimeUI.SetActive(false);
                    FinishPanel2.SetActive(true);
                    AudioListener.volume = 0f;
                    Time.timeScale = 0;
                }
            }
        }
    }

}

