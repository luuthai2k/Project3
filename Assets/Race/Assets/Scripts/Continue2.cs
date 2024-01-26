using UnityEngine;
//script used in the play menu in the continue button after selecting a car
public class Continue2 : MonoBehaviour
{
    public int ModeSelection;
    public GameObject Background4;
    public GameObject CashDisplay;
    public GameObject CarsPanel;
    public GameObject CarsPanelP2;
    public GameObject TracksPanel;

    public void Next2 ()
    {
        ModeSelection = ModeSelect.RaceMode;
        if (ModeSelection == 3)//if split-screen mode is selected
        {
            CarsPanel.SetActive(false);
            CarsPanelP2.SetActive(true);//turn on player 2 car select panel
        }
        else
        {   //else open the track panels directly
            CashDisplay.SetActive(false);
            CarsPanel.GetComponent<MoveLeftCarsPanel2>().enabled = true;
            TracksPanel.GetComponent<MoveLeftTracksPanel>().enabled = true;
            Background4.SetActive(true);
            Background4.GetComponent<FillAmount>().enabled = true;
        }
    }
}
