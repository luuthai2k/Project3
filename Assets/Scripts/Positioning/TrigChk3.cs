using System;
using UnityEngine;

public class TrigChk3 : MonoBehaviour
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
            ChkManager.nDistP[2] = 0;
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
                ChkManager.nChk[2] = nCheckpointNumber;
                CurrentChk += 1;
                NextChk += 1;

                if (nCheckpointNumber == 1)
                {
                    startDis = true;
                    ChkManager.nLapsP[2] += 1;
                    CurrentChk = 1;
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
