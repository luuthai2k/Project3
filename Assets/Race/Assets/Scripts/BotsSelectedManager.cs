using UnityEngine;

public class BotsSelectedManager : MonoBehaviour
{
    public GameObject AICar01, AICar02, AICar03, ArrowAI2, ArrowAI3;
    //if you have more bots add them down below like this:
    //the gameobject minimap
  //public GameObject ArrowAI4;
    //the car scene gameobject
  //public GameObject AICar04;
    public static int BotsSelected, ModeSelected;

    void Update()
    {
        BotsSelected = BotSelector.nBots;
        ModeSelected = ModeSelect.RaceMode;

        //the cars in the track will deactivated depending the number of bots selected
        if (BotsSelected < 2) { AICar02.SetActive(false); ArrowAI2.SetActive(false); }
        if (BotsSelected < 3) { AICar03.SetActive(false); ArrowAI3.SetActive(false); }

        //add more if cases if you have more bots

        //if split-screen is selected, all bots get deactivated
        if (ModeSelected == 3)
        {
            AICar01.SetActive(false);
            AICar02.SetActive(false);
            AICar03.SetActive(false);
            ArrowAI2.SetActive(false);
            ArrowAI3.SetActive(false);
        }      
    }
}
