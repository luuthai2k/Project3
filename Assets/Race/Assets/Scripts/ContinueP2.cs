using UnityEngine;
//this script is used in the continue button when the player 2 selects it's car to race in split-screen mode
public class ContinueP2 : MonoBehaviour
{  
    public GameObject ContinueButtonP2;
    public GameObject TracksPanel;
    public GameObject CarsPanel;
    public GameObject CarsPanelP2;
    public GameObject CashDisplay;
    public GameObject Background4; 

    public void NextP2 ()
    {
        //when the user hits continue, the track selection panel appears
        CashDisplay.SetActive(false);
        CarsPanel.GetComponent<MoveLeftCarsPanel2>().enabled = true;
        TracksPanel.GetComponent<MoveLeftTracksPanel>().enabled = true;
        Background4.SetActive(true);
        Background4.GetComponent<FillAmount>().enabled = true;
        CarsPanelP2.SetActive(false);
    }

}
