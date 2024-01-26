using System;
using UnityEngine;

public class TrigChk2 : MonoBehaviour
{
    //this script takes the count of the checkpoints and laps passed of the AI bot 1 or player 2 in split-screen
    //and then calculates it as score with the distance from the last passed checkpoint
    //at the end, the information is processed in ChkManager script
    public static bool startDis;
    private int nCheckpointNumber, kPos, CurrentChk, NextChk;
    //IMPORTANT NOTES:
    //if you change the AI cars, you need a gameobject called AICarPosition with a box collider and IsTrigger checked, like the default ones in the project (AICar01, AICar02 and AICar03)
    //then, set the tag: 'CarPosAI' in the AICarPosition gameobject
    //this work is already done in the default AI cars, but you need to do it when importing or creating new vehicles from scratch
    //also, AI cars need to have it's number next to AICarPosition name in the gameobject. (i.e: AICar04Position, AICar05Position, and so on) and the same with the tags: CarPosAI5, CarPosAI6...
    //finally, add this script (TrigChk2) to the AICar01Position gameobject, TrigChk3 for AICar02Position and so on...
    //TrigChk2 also is the one that measures the distance of player 2 in split-screen mode, so set the tag CarPosP2 to the CarPosition game object of the player 2 car

    private void Start()
    {
        CurrentChk = 0;
        NextChk = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Substring takes the last number of the Chk
        if (other.gameObject.name.Substring(0, 3) == "Chk")
        {
            ChkManager.nDistP[1]/*position 1 in chk manager arrays stands for AI bot 1 / player 2 in split-screen*/ = 0;//set the distance from checkpoint to 0 when crossing it
            for (int i = 0; i < this.name.Length; i++)
            {
                if (other.gameObject.name.Substring(i, 1) == "k")
                {
                    kPos = i + 1;
                    break;
                }
            }
            //get the last character of the string which is the checkpoint number (i.e: "chk2", the last character is 2)
            nCheckpointNumber = Convert.ToInt32(other.gameObject.name.Substring(kPos, other.gameObject.name.Length - kPos));
            if (CurrentChk + 1 == nCheckpointNumber)
            {
                ChkManager.nChk[1]/*position 1 in chk manager arrays stands for AI bot 1 / player 2 in split-screen*/ = nCheckpointNumber;
                CurrentChk += 1;
                NextChk += 1;

                if (nCheckpointNumber == 1)//if the next checkpoint you have to pass is number 1
                {//that means that you passed all the checkpoints
                    startDis = true;
                    ChkManager.nLapsP[1]/*position 1 in chk manager arrays stands for AI bot 1 / player 2 in split-screen*/ += 1;//and a lap is added to the lap counter
                    CurrentChk = 1;//and the current checkpoint will be 1 (being 2 the next checkpoint)

                    //also, the time will reset to 0 to make a new lap time for player 2 in split-screen mode
                    if (ModeSelect.RaceMode == 3)
                    {
                        LapTimeManager.MinuteCountP2 = 0;
                        LapTimeManager.SecondCountP2 = 0;
                        LapTimeManager.MilliCountP2 = 0;
                    }
                }
            }
            //if the next checkpoint doesn't exist, then you reached the last checkpoint of the circuit
            if (GameObject.Find("Chk" + NextChk) == null)
            {
                //so the checkpoint counter resets and gets ready to receive the first checkpoint again
                CurrentChk = 0;
                NextChk = 1;
            }
        }
    }
}
