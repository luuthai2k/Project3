using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChkManager : MonoBehaviour
{
    //UI Label to show the player position or player 2 position in split-screen mode
    public GameObject PositionDisplay;
    public GameObject PositionDisplayP2;
    //Race finish trigger (used when the player completed all the laps)
    public GameObject RaceFinishTrigger;
    //Update the laps done in the game UI
    public GameObject LapCounter, LapCounterP2;
    //How many laps have been selected for the race
    private int LapsSelected;
    //player values & car pos game object
    public static List<int> nChk = new List<int>();
    public static List<int> nLapsP = new List<int>();
    public static List<double> nDistP = new List<double>();
    public static List<GameObject> CarPosList = new List<GameObject>();
    public static List<double> scoreP = new List<double>();
    public static List<int> pNum = new List<int>();
    public static int posMax;

    //IMPORTANT NOTE: if you change the player's car, remember to have a gameobject called 'CarPosition' with a box collider and IsTrigger checked
    //if you change or add AI bots cars, those need a gameobject called AICarPosition with a box collider and IsTrigger checked
    //then, set the tags: 'CarPos' in the CarPosition gameobject, 'CarPosAI' for the AICarPosition gameobject, 'CarPosAI2' for the AICar02Position gameobject
    //finally, AI cars need to have it's number next to AICarPosition name in the gameobject. (i.e: AICar04Position, AICar05Position, and so on)
    //and the same with the tags: CarPosAI5, CarPosAI6...

    private GameObject[] UnparentChks;

    public void Start()
    {
        //clear previous races values when starting a new race
        scoreP.Clear();
        pNum.Clear();
        nChk.Clear();
        nDistP.Clear();
        nLapsP.Clear();
        CarPosList.Clear();
        //when the race starts:
        TrigChk.startDis = false;//distance isn't measured because no one has passed checkpoints yet
        PositionDisplay.GetComponent<Text>().text = "--";//so we won't show player's position until it triggers a checkpoint
        PositionDisplayP2.GetComponent<Text>().text = "--";//same with player 2 in split-screen mode

        if (ModeSelect.RaceMode == 0)
        {
            //In the game object list of car pos we add each location of the cars in scene
            CarPosList.Add(GameObject.FindWithTag("CarPos"));
            CarPosList.Add(GameObject.FindWithTag("CarPosAI"));
            CarPosList.Add(GameObject.FindWithTag("CarPosAI2"));
            CarPosList.Add(GameObject.FindWithTag("CarPosAI3"));
        }
        else if (ModeSelect.RaceMode == 3)
        {
            //Split Screen Mode
            CarPosList.Add(GameObject.FindWithTag("CarPos"));
            CarPosList.Add(GameObject.FindWithTag("CarPosP2"));
            BotSelector.nBots = 1;
        }
        //if you have more AI cars, remember to set CarPosAI with it's number in the AICarPosition game object (i.e: CarPosAI3)
        //and add it to the CarPosList gameobject list, i.e: CarPosList.Add(GameObject.FindWithTag("CarPosAI4"));

        //in the case of playing time or score gamemodes, only the player car is added because there's no AI bots in these gamemodes
        if (ModeSelect.RaceMode == 1 || ModeSelect.RaceMode == 2)
        {
            CarPosList.Add(GameObject.FindWithTag("CarPos"));
        }

        //here we add a checkpoint, distance, laps, score and player number position for all cars in the scene
        for (int i = 0; i <= BotSelector.nBots; i++) // Player 1 included
        {
            nChk.Add(0);
            nDistP.Add(0);
            nLapsP.Add(0);
            scoreP.Add(0);
            pNum.Add(i + 1); // This sets the number of player in the race
        }
        //unparent checkpoints gameobject so they can get precise transforms       
        UnparentChks = GameObject.FindGameObjectsWithTag("chk");
        foreach (GameObject go in UnparentChks)
        {
            go.transform.parent = null;
        }        
    }

    public void Update()
    {
        //detect how many laps the player has selected for the race
        LapsSelected = LapSelector.nLaps;

        //final score comparison between all players:
        if (ModeSelect.RaceMode == 0 || ModeSelect.RaceMode == 3)
        {
            for (int i = 0; i <= BotSelector.nBots; i++) // Player 1 included
            {
                scoreP[i] = nDistP[i] + (nChk[i] * 100) + (nLapsP[i] * 10000);
            }
        }

        // Show player positions 
        if (TrigChk.startDis)
        {
            posPlayer(1);
            PositionDisplay.GetComponent<Text>().text = (posMax) + CardinalPos(posMax) + " Place";
            posPlayer(2);
            PositionDisplayP2.GetComponent<Text>().text = (posMax) + CardinalPos(posMax) + " Place";
        }

        //if the player completes all the selected laps
        if (LapsSelected < nLapsP[0])
        {
            RaceFinishTrigger.SetActive(true);//the race finish will trigger, ending the race
        }
        //if the player 2 in split-screen mode completes all the selected laps
        if (ModeSelect.RaceMode == 3)
        {
            if (LapsSelected < nLapsP[1])
            {
                RaceFinishTrigger.SetActive(true);//the race finish will trigger, ending the race
            }
        }
        //show the amount of completed laps in the game UI
        LapCounter.GetComponent<Text>().text = Convert.ToString(nLapsP[0]);
        //show the amount of completed laps by player in the game UI in split-screen mode
        if (ModeSelect.RaceMode == 3)
        {
            LapCounterP2.GetComponent<Text>().text = Convert.ToString(nLapsP[1]);
        }
    }
    public string CardinalPos(int i)
    {
        //depending the race position, the display in the canvas will show these letters
        string s = "";
        switch (i)
        {
            case 1:
                s = "st";//i.e: 1st (first) position
                break;
            case 2:
                s = "nd";//2nd (second)
                break;
            case 3:
                s = "rd";//3rd (third)
                break;
            case 4:
                s = "th";//and so on
                break;
                //if you have a 4th bot, add more cases from here:
                //because you will need a 5th position or even more if you add more bots
        }
        return s;
    }
    //get the maximum position comparing cars scores
    public static void posPlayer(int nPlayer)
    {
        double max = 0;
        posMax = 1;

        for (int i = 0; i < scoreP.Count; i++)
        {
            if (scoreP[nPlayer - 1] < scoreP[i])
            {
                max = scoreP[i];
                posMax = posMax + 1;
            }
        }
    }
}