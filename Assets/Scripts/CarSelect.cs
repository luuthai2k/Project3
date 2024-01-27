using UnityEngine;

public class CarSelect : MonoBehaviour
{
   
    public GameObject Car1;
    public GameObject Car2;
    public GameObject Car3;
    public GameObject Car1P2;
    public GameObject Car2P2;
    public GameObject Car3P2;
    private int CarImport;

    void Start()
    {
       
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