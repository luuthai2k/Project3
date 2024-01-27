using UnityEngine;

public class BotsSelectedManager : MonoBehaviour
{
    public GameObject AICar01, AICar02, AICar03, ArrowAI2, ArrowAI3;
    public static int BotsSelected, ModeSelected;

    void Update()
    {
        BotsSelected = BotSelector.nBots;
        ModeSelected = ModeSelect.RaceMode;

        if (BotsSelected < 2) { AICar02.SetActive(false); ArrowAI2.SetActive(false); }
        if (BotsSelected < 3) { AICar03.SetActive(false); ArrowAI3.SetActive(false); }

       
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
