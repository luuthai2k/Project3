using UnityEngine;
using UnityEngine.UI;

public class TimeMode : MonoBehaviour
{
    public int ModeSelection;
    public GameObject AICar;
    public GameObject LapsDone;
    public GameObject PosDisplay;
    public GameObject TargetTime;
    public GameObject ExtraTimeUI;
    public GameObject ArrowAI;
    public GameObject WLap, TLap;

    public static bool isTimeMode = false;

    void Start()
    {
        ModeSelection = ModeSelect.RaceMode;//import race mode selected from play menu
        //if it's 2 (time gamemode)
        if (ModeSelection == 2)
        {
            //change the objects of the scene and the UI to the time gamemode one
            isTimeMode = true;
            AICar.SetActive(false);
            PosDisplay.SetActive(false);
            TargetTime.SetActive(true);
            ExtraTimeUI.SetActive(true);
            ArrowAI.SetActive(false);

        }
    }

    private void Update()
    {
        if (ModeSelection == 2)//if time mode was selected by the user
        {
            if (LapsDone.GetComponent<Text>().text == "2")//when the player enters to the 2nd lap:
            {
                //the warmup label is not showed anymore, and the time one appears
                WLap.SetActive(false);
                TLap.SetActive(true);
                //the first lap is a warmup, that's why it shows the Wlap label
                //the second lap is the time one where you have to beat the time target
                //to set up the time target in time or score mode go to TimeLimit.cs script
            }
        }
    }
}