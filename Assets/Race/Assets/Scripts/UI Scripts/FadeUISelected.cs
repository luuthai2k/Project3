using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUISelected : MonoBehaviour
{

    //the image assigned the inspector to fade it
    public Image panel1;
    public Image panel2;
    public Image panel3;
    public Image panel4;

    void Start()
    {
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        while (fadeAway)
        {
            //loop over 1 second backwards
            for (float i = 0.5f; i >= 0; i -= Time.deltaTime)
            {
                //set color with i as alpha
                panel1.color = new Color(1, 1, 1, i);
                panel2.color = new Color(1, 1, 1, i);
                panel3.color = new Color(1, 1, 1, i);
                panel4.color = new Color(1, 1, 1, i);
                yield return null;
            }
            //loop over 1 second
            for (float i = 0; i <= 0.5f; i += Time.deltaTime)
            {
                //set color with i as alpha
                panel1.color = new Color(1, 1, 1, i);
                panel2.color = new Color(1, 1, 1, i);
                panel3.color = new Color(1, 1, 1, i);
                panel4.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}