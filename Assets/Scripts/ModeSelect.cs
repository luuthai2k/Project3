using UnityEngine;
public class ModeSelect : MonoBehaviour
{
    public static int RaceMode;
    public GameObject RaceModeSelected;
    public GameObject TimeTrialSelected;
    public GameObject ScoreAttackSelected;
    public GameObject SplitScreenSelected;
    public GameObject ContinueButton;
    public GameObject CustomTrackPanel;
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
   

}