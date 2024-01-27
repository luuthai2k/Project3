using System;
using UnityEngine;
using UnityEngine.UI;
public class BotSelector : MonoBehaviour
{
    public GameObject BotUp, BotDown, Bots, BotsPanel;
    public static int nBots;
    public int ModeSelection;

    private void Start()
    {
        nBots = 1;
    }
    public void Update ()
    {
        ModeSelection = ModeSelect.RaceMode;
       
        if (ModeSelection == 0)
        {
            BotsPanel.SetActive(true);
        }
        else
        {
            BotsPanel.SetActive(false);
        }
        
        nBots = Convert.ToInt16(Bots.GetComponent<Text>().text);
    }
   
    public void Up()
    {
        nBots = Convert.ToInt32(Bots.GetComponent<Text>().text) + 1;
        Bots.GetComponent<Text>().text = Convert.ToString(nBots);
        if (Bots.GetComponent<Text>().text == "3")
        {
            BotUp.SetActive(false);
        }
      
        if (Bots.GetComponent<Text>().text == "2")
        {
            BotDown.SetActive(true);
        }
    }
    
    public void Down()
    {
        nBots = Convert.ToInt32(Bots.GetComponent<Text>().text) - 1;
        Bots.GetComponent<Text>().text = Convert.ToString(nBots);
        if (Bots.GetComponent<Text>().text == "1")
        {
            BotDown.SetActive(false);
        }
        if (Bots.GetComponent<Text>().text == "2")
        {
            BotUp.SetActive(true);
        }
    }
}
