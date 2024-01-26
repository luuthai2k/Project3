using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRotate : MonoBehaviour
{
    void Update()
    {
        //constant 1 degree rotation per second
        transform.Rotate(0, 1, 0 * Time.deltaTime);
    }
}
