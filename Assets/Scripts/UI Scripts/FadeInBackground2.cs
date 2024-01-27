using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInBackground2 : MonoBehaviour
{

   
    public Image Background2;

    void Start()
    {
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
           
            Background2.color = new Color(1, 1, 1, 0);
            yield return null;

            
            for (float i = 0f; i <= 1; i += Time.deltaTime)
            {
                
                Background2.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}