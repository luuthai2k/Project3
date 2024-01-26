using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCarsPanel : MonoBehaviour
{
    //Declare RectTransform in script
    RectTransform CarsPanel;
    RectTransform Background2;
    //The new position of the cars panel
    Vector3 newPos = new Vector3(0, 51, 0);
    //Reference value used for the Smoothdamp method
    private Vector3 Speed = Vector3.zero;
    //Smooth time
    private float SmoothTime = 0.5f;

    void Start()
    {
        CarsPanel = GetComponent<RectTransform>();
    }
	
	void FixedUpdate()
    {
        CarsPanel.localPosition = Vector3.SmoothDamp(CarsPanel.localPosition, newPos, ref Speed, SmoothTime);
    }
}
