using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInUI : MonoBehaviour
{

    //the image assigned the inspector to fade it
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Image image6;
    public Image image7;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;

    void Start()
    {
        StartCoroutine(FadeImage(true));
        //sets all objects to 0 alpha transparency
        image1.color = new Color(1, 1, 1, 0);
        image2.color = new Color(1, 1, 1, 0);
        image3.color = new Color(1, 1, 1, 0);
        image4.color = new Color(1, 1, 1, 0);
        image5.color = new Color(1, 1, 1, 0);
        image6.color = new Color(1, 1, 1, 0);
        image7.color = new Color(1, 1, 1, 0);
        text1.color = new Color(1, 1, 1, 0);
        text2.color = new Color(1, 1, 1, 0);
        text3.color = new Color(1, 1, 1, 0);
        text4.color = new Color(1, 1, 1, 0);
        text5.color = new Color(1, 1, 1, 0);
        text6.color = new Color(1, 1, 1, 0);
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            //objects that appears at the first second (play menu title & game mode border panel)
            for (float i = 0f; i <= 1; i += Time.deltaTime)
            {
                //sets objects to 1 alpha transparency
                image1.color = new Color(1, 1, 1, i);
                text1.color = new Color (1, 1, 1, i);
                yield return null;
            }
            //objects that appears at 2 seconds (game mode images)
            for (float i = 0f; i <= 1; i += Time.deltaTime)
            {
                //sets objects to 1 alpha transparency
                image2.color = new Color(1, 1, 1, i);
                image3.color = new Color(1, 1, 1, i);
                image4.color = new Color(1, 1, 1, i);
                image5.color = new Color(1, 1, 1, i);
                yield return null;
            }
            //objects that appears at 3 seconds (game mode titles)
            for (float i = 0.5f; i <= 1; i += Time.deltaTime)
            {
                //sets objects to 1 alpha transparency
                text2.color = new Color(1, 1, 1, i);
                text3.color = new Color(1, 1, 1, i);
                text4.color = new Color(1, 1, 1, i);
                text5.color = new Color(1, 1, 1, i);
                yield return null;
            }
            //objects that appears at 4 seconds (game mode descriptions)
            for (float i = 0.5f; i <= 1; i += Time.deltaTime)
            {
                //sets objects to 1 alpha transparency
                image6.color = new Color(1, 1, 1, i);
                image7.color = new Color(0, 0, 0, i);
                text6.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}