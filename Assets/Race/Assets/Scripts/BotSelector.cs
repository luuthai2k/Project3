using System;
using UnityEngine;
using UnityEngine.UI;
//this script is used in the bot selector from the play menu
public class BotSelector : MonoBehaviour
{
    public GameObject BotUp, BotDown, Bots, BotsPanel;//here we declare all the buttons and labels that we are going to use
    public static int nBots;//here we create a STATIC int to import it from the script BotsSelectedManager.cs
    public int ModeSelection;//here we import the game mode selected by the player

    private void Start()
    {
        nBots = 1;//at the start of the game, the number of selected bots is 1
    }
    public void Update ()
    {
        ModeSelection = ModeSelect.RaceMode;//import the gamemode
        //activate the bots panel only in race gamemode
        if (ModeSelection == 0)
        {
            BotsPanel.SetActive(true);
        }
        else
        {
            BotsPanel.SetActive(false);
        }
        //nBots
        nBots = Convert.ToInt16(Bots.GetComponent<Text>().text);
    }
    //with the + button in the game, the void Up is called and 1 more bot is added to the race
    public void Up()
    {
        nBots = Convert.ToInt32(Bots.GetComponent<Text>().text) + 1;//the number of selected bots goes 1 up
        Bots.GetComponent<Text>().text = Convert.ToString(nBots);//here we convert the int to string to show it in the UI text from the bots panel
        //the max of bots it's 3 and it deactivates the + button
        //IMPORTANT: if you have more than 3 bots, change the maximum down below in the if statement
        //By default we put 3 because it's the maximum of bots in the scene
        if (Bots.GetComponent<Text>().text == "3")//maximum of bots
        {
            BotUp.SetActive(false);//it deactivates the bot + button because you can't add more bots
        }
        //reactivate - button
        if (Bots.GetComponent<Text>().text == "2")
        {
            BotDown.SetActive(true);//button - gets activated again because the number of selected bots it's not 1 (the minimum)
        }
    }
    //with the - button in the game, the void Down is called and 1 bot is removed from the race
    public void Down()
    {
        nBots = Convert.ToInt32(Bots.GetComponent<Text>().text) - 1;//the number of selected bots goes 1 less
        Bots.GetComponent<Text>().text = Convert.ToString(nBots);//here we convert the int to string to show it in the UI text from the bots panel
        //the min of bots it's 1 and it deactivates the - button
        if (Bots.GetComponent<Text>().text == "1")
        {
            BotDown.SetActive(false);
        }
        //reactivate + button
        //IMPORTANT: if you have, for example 5 bots, you have to put 4 in the if down below. Always 1 less than the maximum
        //By default we put 2 because our maximum of bots it's 3
        if (Bots.GetComponent<Text>().text == "2")
        {
            BotUp.SetActive(true);//button + gets activated again because the number of selected bots it's not 3 (the maximum)
        }
    }
}
