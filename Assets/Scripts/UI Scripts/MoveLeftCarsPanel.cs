using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCarsPanel : MonoBehaviour
{
    RectTransform CarsPanel;
    RectTransform Background2;
    Vector3 newPos = new Vector3(0, 51, 0);
    private Vector3 Speed = Vector3.zero;
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
