using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftModePanel : MonoBehaviour
{
    //Declare RectTransform in script
    RectTransform ModePanel;
    //The new position of your button
    Vector3 newPos = new Vector3(-2500, 0, 0);
    //Reference value used for the Smoothdamp method
    private Vector3 Speed = Vector3.zero;
    //Smooth time
    private float SmoothTime = 0.5f;

    void Start()
    {
        ModePanel = GetComponent<RectTransform>();
    }
	
	void FixedUpdate()
    {
        ModePanel.localPosition = Vector3.SmoothDamp(ModePanel.localPosition, newPos, ref Speed, SmoothTime);
    }
}
