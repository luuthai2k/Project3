using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{

   
    public Image image;

    void Start()
    {
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        while (fadeAway)
        {
           
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
               
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }
           
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}