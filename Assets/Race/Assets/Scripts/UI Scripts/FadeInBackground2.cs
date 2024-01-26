using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInBackground2 : MonoBehaviour
{

    //the image assigned the inspector to fade it
    public Image Background2;

    void Start()
    {
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            //sets all objects to 0 alpha transparency
            Background2.color = new Color(1, 1, 1, 0);
            yield return null;

            //objects that appears at the first second (play menu title & game mode border panel)
            for (float i = 0f; i <= 1; i += Time.deltaTime)
            {
                //sets objects to 1 alpha transparency
                Background2.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}