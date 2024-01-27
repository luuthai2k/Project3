using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftTitles : MonoBehaviour
{
    RectTransform Titles;
    Vector3 newPos = new Vector3(-2500, 0, 0);
    private Vector3 Speed = Vector3.zero;
    private float SmoothTime = 0.5f;

    void Start()
    {
        Titles = GetComponent<RectTransform>();
    }
	
	void FixedUpdate()
    {
        Titles.localPosition = Vector3.SmoothDamp(Titles.localPosition, newPos, ref Speed, SmoothTime);
    }
}
