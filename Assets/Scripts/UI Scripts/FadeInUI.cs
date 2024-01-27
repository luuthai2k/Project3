using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInUI : MonoBehaviour
{

  
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
        //StartCoroutine(FadeImage(true));
        //image1.color = new Color(1, 1, 1, 0);
        //image2.color = new Color(1, 1, 1, 0);
        //image3.color = new Color(1, 1, 1, 0);
        //image4.color = new Color(1, 1, 1, 0);
        //image5.color = new Color(1, 1, 1, 0);
        //image6.color = new Color(1, 1, 1, 0);
        //image7.color = new Color(1, 1, 1, 0);
        //text1.color = new Color(1, 1, 1, 0);
        //text2.color = new Color(1, 1, 1, 0);
        //text3.color = new Color(1, 1, 1, 0);
        //text4.color = new Color(1, 1, 1, 0);
        //text5.color = new Color(1, 1, 1, 0);
        //text6.color = new Color(1, 1, 1, 0);
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
           
            for (float i = 0f; i <= 1; i += Time.deltaTime)
            {
                
                image1.color = new Color(1, 1, 1, i);
                text1.color = new Color (1, 1, 1, i);
                yield return null;
            }
           
            for (float i = 0f; i <= 1; i += Time.deltaTime)
            {
               
                image2.color = new Color(1, 1, 1, i);
                image3.color = new Color(1, 1, 1, i);
                image4.color = new Color(1, 1, 1, i);
                image5.color = new Color(1, 1, 1, i);
                yield return null;
            }
           
            for (float i = 0.5f; i <= 1; i += Time.deltaTime)
            {
                
                text2.color = new Color(1, 1, 1, i);
                text3.color = new Color(1, 1, 1, i);
                text4.color = new Color(1, 1, 1, i);
                text5.color = new Color(1, 1, 1, i);
                yield return null;
            }

            for (float i = 0.5f; i <= 1; i += Time.deltaTime)
            {
               
                image6.color = new Color(1, 1, 1, i);
                image7.color = new Color(0, 0, 0, i);
                text6.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}