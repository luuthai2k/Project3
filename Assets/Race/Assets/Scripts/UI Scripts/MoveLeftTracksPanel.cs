using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftTracksPanel : MonoBehaviour
{
    ///Declare RectTransform in script
    RectTransform TracksPanel;
    //The new position of the cars panel
    Vector3 newPos = new Vector3(0, 0, 0);
    //Reference value used for the Smoothdamp method
    private Vector3 Speed = Vector3.zero;
    //Smooth time
    private float SmoothTime = 0.5f;

    void Start()
    {
        TracksPanel = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        TracksPanel.localPosition = Vector3.SmoothDamp(TracksPanel.localPosition, newPos, ref Speed, SmoothTime);
    }
}
