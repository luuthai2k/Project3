using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarControlActive : MonoBehaviour
{
    
    public GameObject AICar01;
    public GameObject AICar02;
    public GameObject AICar03;
    private GameObject CarControl;
    private GameObject CarControlP2;
    public int ModeSelection;
    public int CarImport;
    public int BotImport;

    void Start()
    {
        ModeSelection = ModeSelect.RaceMode;

        CarControl = GameObject.FindWithTag("PlayerCar");
        CarControl.GetComponent<CarUserControl>().enabled = true;
        CarControl.GetComponent<CarController>().enabled = true;

        AICar01.GetComponent<CarAIControl>().enabled = true;
        AICar02.GetComponent<CarAIControl>().enabled = true;
        AICar03.GetComponent<CarAIControl>().enabled = true;
       
    }
}