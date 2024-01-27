using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;

public class RaceFinish : MonoBehaviour
{
    public int ModeSelection;
    private GameObject MyCar;
    public GameObject FinishCam;
    public GameObject ViewModes;
    public GameObject LevelMusic;
    public GameObject PosDisplay, ScoreValue, PauseButton, Panel1, Panel2, Panel3, Panel4;
    public GameObject FinishPanel, FinishPanel2nd, FinishPanelScore;
    public GameObject LapPanel, ExtraTimeUI, TLap, Minimap, MinimapP2;
    public GameObject P1Wins, P2Wins;
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

        if (ModeSelection == 0)
        {
            if (PosDisplay.GetComponent<Text>().text == "1st Place")
            {
                GlobalCash.TotalCash += 100;
                PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
                FinishMusic.Play();
            }
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

       
       
    }
}