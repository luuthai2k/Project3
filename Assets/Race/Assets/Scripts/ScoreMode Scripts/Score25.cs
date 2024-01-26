using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score25 : MonoBehaviour
{


    void OnTriggerEnter()
    {
        ScoreMode.CurrentScore += 25;
        gameObject.SetActive(false);
    }
}