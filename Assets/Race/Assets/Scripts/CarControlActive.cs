using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarControlActive : MonoBehaviour
{
    //activate car controls after the race countdown (3, 2, 1, go)
    public GameObject AICar01;
    public GameObject AICar02;
    public GameObject AICar03;
    //if you have more than 3 bots in your game add them from here and down below in the script
    //like this: public GameObject AICar04;
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

        //activate player 2 controls only if split-screen mode is selected
        if (ModeSelection == 3)
        { 
            CarControlP2 = GameObject.FindWithTag("PlayerCarP2");
            CarControlP2.GetComponent<CarUserControlP2>().enabled = true;
            CarControlP2.GetComponent<CarController>().enabled = true;
        }

        //bots selected
        AICar01.GetComponent<CarAIControl>().enabled = true;
        AICar02.GetComponent<CarAIControl>().enabled = true;
        AICar03.GetComponent<CarAIControl>().enabled = true;
        //if you have more bots add them down below like this:
      //AICar04.GetComponent<CarAIControl>().enabled = true;
    }
}