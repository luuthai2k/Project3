using System;
using UnityEngine;
using UnityEngine.UI;
//from this script we will show in the racing UI the lap requirement with the number of laps selected
public class LapsSelectedManager : MonoBehaviour
{
    public GameObject LapRequirement, LapRequirementP2;//declare the lap requirements labels of the Canvas (player and player 2 for split-screen gamemode)

    void Start()
    {
        LapRequirement.SetActive(true);//turn on the UI label
        LapRequirement.GetComponent<Text>().text = Convert.ToString(LapSelector.nLaps);
        LapRequirementP2.SetActive(true);
        LapRequirementP2.GetComponent<Text>().text = Convert.ToString(LapSelector.nLaps);
    }
}
