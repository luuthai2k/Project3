using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftTracksPanel : MonoBehaviour
{
    RectTransform TracksPanel;
    Vector3 newPos = new Vector3(0, 0, 0);
    private Vector3 Speed = Vector3.zero;
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
