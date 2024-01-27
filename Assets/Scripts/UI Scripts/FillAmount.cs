using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillAmount : MonoBehaviour
{
    public Image Background;
    public bool BackgroundDown;
    public float waitTime = 0.5f;

    void FixedUpdate()
    {
        if (BackgroundDown == true)
        {
            Background.fillAmount += 1.0f / waitTime * Time.deltaTime;
        }
    }
}
