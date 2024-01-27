using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUISelected : MonoBehaviour
{

    public Image panel1;
    public Image panel2;
    public Image panel3;
    public Image panel4;

    void Start()
    {
        //StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        while (fadeAway)
        {
            
            for (float i = 0.5f; i >= 0; i -= Time.deltaTime)
            {
                
                panel1.color = new Color(1, 1, 1, i);
                panel2.color = new Color(1, 1, 1, i);
                panel3.color = new Color(1, 1, 1, i);
                panel4.color = new Color(1, 1, 1, i);
                yield return null;
            }
          
            for (float i = 0; i <= 0.5f; i += Time.deltaTime)
            {
               
                panel1.color = new Color(1, 1, 1, i);
                panel2.color = new Color(1, 1, 1, i);
                panel3.color = new Color(1, 1, 1, i);
                panel4.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}