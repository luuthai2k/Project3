using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{

    //the image assigned the inspector to fade it
    public Image image;
    public Text text;

    void Start()
    {
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        while (fadeAway)
        {
            //loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                //set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                //fade text to transparent
                text.CrossFadeAlpha(0.0f, 0.05f, false);
                yield return null;
            }
            //loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                //set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                //fade text to normal
                text.CrossFadeAlpha(1.0f, 0.05f, false);
                yield return null;
            }
        }
    }
}