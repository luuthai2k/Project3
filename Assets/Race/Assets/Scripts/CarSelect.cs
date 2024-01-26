using UnityEngine;

public class CarSelect : MonoBehaviour
{
    //1=Porsche, 2=Ferrari, 3=Lamborghini
    public GameObject Car1;
    public GameObject Car2;
    public GameObject Car3;
    public GameObject Car1P2;
    public GameObject Car2P2;
    public GameObject Car3P2;
    private int CarImport;

    void Start()
    {
        //Player 1 car selected in any game mode
        CarImport = GlobalCar.CarType;
        if (CarImport == 1)
        {
            Car1.SetActive(true);
        }
        if (CarImport == 2)
        {
            Car2.SetActive(true);
        }
        if (CarImport == 3)
        {
            Car3.SetActive(true);
        }
        //Player 2 car selected when in split-screen
        CarImport = GlobalCarP2.CarType;
        if (ModeSelect.RaceMode == 3)
        { 
            if (CarImport == 1)
            {
                Car1P2.SetActive(true);
            }
            if (CarImport == 2)
            {
                Car2P2.SetActive(true);
            }
            if (CarImport == 3)
            {
                Car3P2.SetActive(true);
            }
        }
    }
}