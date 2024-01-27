using UnityEngine;

public class Continue : MonoBehaviour
{
 
    public GameObject Background2;
    public GameObject Background3;
    public GameObject Background4;
    public GameObject TracksPanel;
    public GameObject CashDisplay;
    public GameObject CarsPanel;
    public GameObject CarsPanelP2;
    private void Start()
    {
        Next();
    }

    public void Next ()
    {
       
           
            CarsPanel.GetComponent<MoveLeftCarsPanel>().enabled = true;
            Background2.GetComponent<FadeInBackground2>().enabled = true;
            Background3.GetComponent<FillAmount>().enabled = true;
            CashDisplay.SetActive(true);
       
    }
    
 

    public void Next2()
    {
      
            CashDisplay.SetActive(false);
            CarsPanel.GetComponent<MoveLeftCarsPanel2>().enabled = true;
            TracksPanel.GetComponent<MoveLeftTracksPanel>().enabled = true;
            Background4.SetActive(true);
            Background4.GetComponent<FillAmount>().enabled = true;
       
    }
}
