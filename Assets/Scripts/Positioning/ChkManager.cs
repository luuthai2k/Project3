using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChkManager : MonoBehaviour
{
   
    public GameObject PositionDisplay;
    public GameObject PositionDisplayP2;
    public GameObject RaceFinishTrigger;
    public GameObject LapCounter, LapCounterP2;
    private int LapsSelected;
    public static List<int> nChk = new List<int>();
    public static List<int> nLapsP = new List<int>();
    public static List<double> nDistP = new List<double>();
    public static List<GameObject> CarPosList = new List<GameObject>();
    public static List<double> scoreP = new List<double>();
    public static List<int> pNum = new List<int>();
    public static int posMax;

    private GameObject[] UnparentChks;

    public void Start()
    {
       
        scoreP.Clear();
        pNum.Clear();
        nChk.Clear();
        nDistP.Clear();
        nLapsP.Clear();
        CarPosList.Clear();
       
        TrigChk.startDis = false;
        PositionDisplay.GetComponent<Text>().text = "--";
        PositionDisplayP2.GetComponent<Text>().text = "--";

        if (ModeSelect.RaceMode == 0)
        {
          
            CarPosList.Add(GameObject.FindWithTag("CarPos"));
            CarPosList.Add(GameObject.FindWithTag("CarPosAI"));
            CarPosList.Add(GameObject.FindWithTag("CarPosAI2"));
            CarPosList.Add(GameObject.FindWithTag("CarPosAI3"));
        }
        else if (ModeSelect.RaceMode == 3)
        {
          
            CarPosList.Add(GameObject.FindWithTag("CarPos"));
            CarPosList.Add(GameObject.FindWithTag("CarPosP2"));
            BotSelector.nBots = 1;
        }
       
        if (ModeSelect.RaceMode == 1 || ModeSelect.RaceMode == 2)
        {
            CarPosList.Add(GameObject.FindWithTag("CarPos"));
        }

     
        for (int i = 0; i <= BotSelector.nBots; i++) 
        {
            nChk.Add(0);
            nDistP.Add(0);
            nLapsP.Add(0);
            scoreP.Add(0);
            pNum.Add(i + 1); 
        }
      
        UnparentChks = GameObject.FindGameObjectsWithTag("chk");
        foreach (GameObject go in UnparentChks)
        {
            go.transform.parent = null;
        }        
    }

    public void Update()
    {
      
        LapsSelected = LapSelector.nLaps;

      
        if (ModeSelect.RaceMode == 0 || ModeSelect.RaceMode == 3)
        {
            for (int i = 0; i <= BotSelector.nBots; i++) 
            {
                scoreP[i] = nDistP[i] + (nChk[i] * 100) + (nLapsP[i] * 10000);
            }
        }

       
        if (TrigChk.startDis)
        {
            posPlayer(1);
            PositionDisplay.GetComponent<Text>().text = (posMax) + CardinalPos(posMax) + " Place";
            posPlayer(2);
            PositionDisplayP2.GetComponent<Text>().text = (posMax) + CardinalPos(posMax) + " Place";
        }

     
        if (LapsSelected < nLapsP[0])
        {
            RaceFinishTrigger.SetActive(true);
        }
       
        if (ModeSelect.RaceMode == 3)
        {
            if (LapsSelected < nLapsP[1])
            {
                RaceFinishTrigger.SetActive(true);
            }
        }
      
        LapCounter.GetComponent<Text>().text = Convert.ToString(nLapsP[0]);
       
        if (ModeSelect.RaceMode == 3)
        {
            LapCounterP2.GetComponent<Text>().text = Convert.ToString(nLapsP[1]);
        }
    }
    public string CardinalPos(int i)
    {
        
        string s = "";
        switch (i)
        {
            case 1:
                s = "st";
                break;
            case 2:
                s = "nd";
                break;
            case 3:
                s = "rd";
                break;
            case 4:
                s = "th";
                break;
              
        }
        return s;
    }
 
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