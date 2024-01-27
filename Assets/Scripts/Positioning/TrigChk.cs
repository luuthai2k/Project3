using System;
using UnityEngine;

public class TrigChk : MonoBehaviour
{
  
    public static bool startDis;
    private int nCheckpointNumber, kPos, CurrentChk, NextChk;
    private void Start()
    {
        CurrentChk = 0;
        NextChk = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.name.Substring(0, 3) == "Chk")
        {
            ChkManager.nDistP[0] = 0;
            for (int i = 0; i < this.name.Length; i++)
            {
                if (other.gameObject.name.Substring(i, 1) == "k")
                {
                    kPos = i + 1;
                    break;
                }
            }
          
            nCheckpointNumber = Convert.ToInt32(other.gameObject.name.Substring(kPos, other.gameObject.name.Length - kPos));
            if (CurrentChk + 1 == nCheckpointNumber)
            {
                ChkManager.nChk[0] = nCheckpointNumber;
                CurrentChk += 1;
                NextChk += 1;
                
                if (nCheckpointNumber == 1)
                {
                    startDis = true;
                    ChkManager.nLapsP[0] += 1;
                    CurrentChk = 1;

                  
                    LapTimeManager.MinuteCount = 0;
                    LapTimeManager.SecondCount = 0;
                    LapTimeManager.MilliCount = 0;
                }
            }
          
            if (GameObject.Find("Chk" + NextChk) == null)
            {
               
                CurrentChk = 0;
                NextChk = 1;
            }
        }
    }
}
