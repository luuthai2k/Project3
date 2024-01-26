using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;

public class RaceFinish : MonoBehaviour
{
    public int ModeSelection;
    //cars wont be playable after the race finishes
    private GameObject MyCar;
    //finish camera gets activated
    public GameObject FinishCam;
    //viewmodes gets deactivated so you can't change the camera once the race is over
    public GameObject ViewModes;
    //level music stops playing
    public GameObject LevelMusic;
    //UI that gets deactivated once the race finishes
    public GameObject PosDisplay, ScoreValue, PauseButton, Panel1, Panel2, Panel3, Panel4;
    //the 3 different finish panels
    public GameObject FinishPanel, FinishPanel2nd, FinishPanelScore;
    //UI that gets deactivated once the race finishes
    public GameObject LapPanel, ExtraTimeUI, TLap, Minimap, MinimapP2;
    //the 2 remaining finish panels: split screen
    public GameObject P1Wins, P2Wins;
    //music of the end of the race
    public AudioSource FinishMusic;

    void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        MyCar = GameObject.FindGameObjectWithTag("PlayerCar");
        MyCar.GetComponent<CarController>().enabled = false;
        MyCar.GetComponent<CarUserControl>().enabled = false;
        FinishCam.SetActive(true);
        PauseButton.SetActive(false);
        Panel1.SetActive(false); Panel2.SetActive(false); Panel3.SetActive(false); Panel4.SetActive(false);
        LapPanel.SetActive(false);
        FinishPanel.SetActive(true);
        LevelMusic.SetActive(false);
        ViewModes.SetActive(false);
        ExtraTimeUI.SetActive(false);
        Minimap.SetActive(false); MinimapP2.SetActive(false);
        ModeSelection = ModeSelect.RaceMode;

        //race mode
        if (ModeSelection == 0)
        {
            //if you win (you finish 1st position)
            if (PosDisplay.GetComponent<Text>().text == "1st Place")
            {
                //you win $100
                GlobalCash.TotalCash += 100;
                PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
                FinishMusic.Play();
            }
            //if you lose
            else
            {
                GlobalCash.TotalCash += 0;
                PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
                FinishPanel.SetActive(false);
                FinishPanel2nd.SetActive(true);
                AudioListener.volume = 0f;
                Time.timeScale = 0;
            }
        }

        //score attack
        if (ModeSelection == 1)
        {
            //if you win reaching the score target or passing it (score made by the player <= score requested)
            if (ScoreMode.ScoreMade >= ScoreMode.ScoreModeTarget)
            {
                FinishMusic.Play();
                //you win $100
                GlobalCash.TotalCash += 100;
                PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
            }

            //if you lose becouse you didn't reach the requested score
            else
            {
                AudioListener.volume = 0f;
                GlobalCash.TotalCash += 0;
                PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
                FinishPanel.SetActive(false);
                FinishPanelScore.SetActive(true);
            }
        }

        //time trial
        if (ModeSelection == 2)
        {
            //if you win reaching the finish in time
            if (TLap.GetComponent<Text>().text == "Time Lap")
            {
                FinishMusic.Play();
                //you win $100
                GlobalCash.TotalCash += 100;
                PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
            }
            //if you lose (ran out of time)
            else
            {
                AudioListener.volume = 0f;
                GlobalCash.TotalCash += 0;
                PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
            }
        }
        //split screen finish
        if (ModeSelection == 3)
        {
            //player 1 wins
            if (PosDisplay.GetComponent<Text>().text == "1st Place")
            {
                FinishMusic.Play();
                FinishPanel.SetActive(false);
                P1Wins.SetActive(true);
            }
            //player 2 wins
            else
            {
                FinishMusic.Play();
                FinishPanel.SetActive(false);
                P2Wins.SetActive(true);
            }
        }
    }
}