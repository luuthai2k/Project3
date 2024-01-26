using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public float accel, steering;
    public void AccelInput(float value)
    {
        accel = value;
    }

    public void SteeringInput(float value)
    {
        steering = value;
    }
}
