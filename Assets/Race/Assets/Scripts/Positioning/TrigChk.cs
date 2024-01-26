using System;
using UnityEngine;

public class TrigChk : MonoBehaviour
{
    //this script takes the count of the checkpoints and laps passed of player 1
    //and then calculates it as score with the distance from the last passed checkpoint
    //at the end, the information is processed in ChkManager script
    public static bool startDis;
    private int nCheckpointNumber, kPos, CurrentChk, NextChk;
    //IMPORTANT NOTE:
    //if you change the player car, you need a gameobject called CarPosition with a box collider and IsTrigger checked, like the one in the default car (car-parsche)
    //then, set the tag: 'CarPos' in the CarPosition gameobject
    //this work is already done in the default car, but you need to do it when importing and creating a new vehicle from scratch
    //finally, add this script (TrigChk) to the CarPosition gameobject
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
            ChkManager.nDistP[0]/*position 0 in chk manager arrays stands for player 1*/  = 0;//set the distance from checkpoint to 0 when crossing it
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
                ChkManager.nChk[0]/*position 0 in chk manager arrays stands for player 1*/ = nCheckpointNumber;
                CurrentChk += 1;
                NextChk += 1;
                
                if (nCheckpointNumber == 1)//if the next checkpoint you have to pass is number 1
                {//that means that you passed all the checkpoints
                    startDis = true;
                    ChkManager.nLapsP[0]/*position 0 in chk manager arrays stands for player 1*/ += 1;//and a lap is added to the lap counter
                    CurrentChk = 1;//and the current checkpoint will be 1 (being 2 the next checkpoint)

                    //also, the time will reset to 0 to make a new lap time
                    LapTimeManager.MinuteCount = 0;
                    LapTimeManager.SecondCount = 0;
                    LapTimeManager.MilliCount = 0;
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
