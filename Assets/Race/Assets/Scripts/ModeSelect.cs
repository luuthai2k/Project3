using UnityEngine;
//this script is used in the 4 game mode buttons of the play menu
public class ModeSelect : MonoBehaviour
{
    public static int RaceMode; // 0=Race, 1=Score, 2=Time, 3=Split-Screen
    public GameObject RaceModeSelected;
    public GameObject TimeTrialSelected;
    public GameObject ScoreAttackSelected;
    public GameObject SplitScreenSelected;
    public GameObject ContinueButton;
    public GameObject CustomTrackPanel;
    //and it changes the race mode int depending what the user has selected
    //also it activates some UI to show on screen which game mode is selected
    public void resetMode()
    {
        RaceModeSelected.SetActive(false);
        TimeTrialSelected.SetActive(false);
        ScoreAttackSelected.SetActive(false);
        SplitScreenSelected.SetActive(false);
    }
    public void TheRaceMode()
    {
        RaceMode = 0;
        resetMode();
        RaceModeSelected.SetActive(true);
        ContinueButton.SetActive(true);
        CustomTrackPanel.SetActive(true);
    }
    public void ScoreMode()
    {
        RaceMode = 1;
        resetMode();
        ScoreAttackSelected.SetActive(true);
        ContinueButton.SetActive(true);
        CustomTrackPanel.SetActive(false);
    }
    public void TimeMode()
    {
        RaceMode = 2;
        resetMode();
        TimeTrialSelected.SetActive(true);
        ContinueButton.SetActive(true);
        CustomTrackPanel.SetActive(false);
    }
    public void SplitScreenMode()
    {
        RaceMode = 3;
        resetMode();
        SplitScreenSelected.SetActive(true);
        ContinueButton.SetActive(true);
        CustomTrackPanel.SetActive(true);
    }

}