using UnityEngine;
//script used in play menu in the continue button OnClick void

public class Continue : MonoBehaviour
{
    public int ModeSelection;
    //Objects that disappear when a race mode is selected
    public GameObject ContinueButton;

    //Objects that move away when a race mode is selected (the mode panel)
    public GameObject ModePanel;
    public GameObject Titles;
    public GameObject Background2;
    public GameObject Background3;

    //Objects that appear when a race mode is selected (the cars panel)
    public GameObject CashDisplay;
    public GameObject CarsPanel;
    public GameObject CarsPanelP2;
    private void Start()
    {
        Next();
    }

    public void Next ()
    {
        ModeSelection = ModeSelect.RaceMode;
        //race mode
        if (ModeSelection == 0)
        {
            ContinueButton.SetActive(false);
            CarsPanel.GetComponent<MoveLeftCarsPanel>().enabled = true;
            Titles.GetComponent<MoveLeftTitles>().enabled = true;
            ModePanel.GetComponent<MoveLeftModePanel>().enabled = true;
            Background2.GetComponent<FadeInBackground2>().enabled = true;
            Background3.GetComponent<FillAmount>().enabled = true;
            CashDisplay.SetActive(true);
        }
        //score attack
        if (ModeSelection == 1)
        {
            ContinueButton.SetActive(false);
            CarsPanel.GetComponent<MoveLeftCarsPanel>().enabled = true;
            Titles.GetComponent<MoveLeftTitles>().enabled = true;
            ModePanel.GetComponent<MoveLeftModePanel>().enabled = true;
            Background2.GetComponent<FadeInBackground2>().enabled = true;
            Background3.GetComponent<FillAmount>().enabled = true;
            CashDisplay.SetActive(true);
        }
        //time trial
        if (ModeSelection == 2)
        {
            ContinueButton.SetActive(false);
            CarsPanel.GetComponent<MoveLeftCarsPanel>().enabled = true;
            Titles.GetComponent<MoveLeftTitles>().enabled = true;
            ModePanel.GetComponent<MoveLeftModePanel>().enabled = true;
            Background2.GetComponent<FadeInBackground2>().enabled = true;
            Background3.GetComponent<FillAmount>().enabled = true;
            CashDisplay.SetActive(true);
        }
        //split screen
        if (ModeSelection == 3)
        {
            ContinueButton.SetActive(false);
            CarsPanel.GetComponent<MoveLeftCarsPanel>().enabled = true;
            Titles.GetComponent<MoveLeftTitles>().enabled = true;
            ModePanel.GetComponent<MoveLeftModePanel>().enabled = true;
            Background2.GetComponent<FadeInBackground2>().enabled = true;
            Background3.GetComponent<FillAmount>().enabled = true;
            CashDisplay.SetActive(true);
        }
    }
}
