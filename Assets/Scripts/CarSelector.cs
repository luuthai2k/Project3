using System;
using UnityEngine;
using UnityEngine.UI;
public class CarSelector : MonoBehaviour
{
    public GameObject Car1, Car2, Car3;
    public GameObject ArrowRight;
    public GameObject ArrowLeft;
    public GameObject Cars;
    public static int nCars;
    public static int sCars;

    public void Update()
    {
        if (Cars.GetComponent<Text>().text == "1")
        {
            sCars = 1;
            Car1.SetActive(true);
            Car2.SetActive(false);
        }
        if (Cars.GetComponent<Text>().text == "2")
        {
            sCars = 2;
            Car1.SetActive(false);
            Car2.SetActive(true);
            Car3.SetActive(false);
        }
        if (Cars.GetComponent<Text>().text == "3")
        {
            sCars = 3;
            Car2.SetActive(false);
            Car3.SetActive(true);
        }
    }

    public void Right()
    {
        nCars = Convert.ToInt32(Cars.GetComponent<Text>().text) + 1;
        Cars.GetComponent<Text>().text = Convert.ToString(nCars);
       
        if (Cars.GetComponent<Text>().text == "3")
        {
            ArrowRight.SetActive(false);
        }
      
        if (Cars.GetComponent<Text>().text == "2")
        {
            ArrowLeft.SetActive(true);
        }
    }

    public void Left()
    {
        nCars = Convert.ToInt32(Cars.GetComponent<Text>().text) - 1;
        Cars.GetComponent<Text>().text = Convert.ToString(nCars);
       
        if (Cars.GetComponent<Text>().text == "1")
        {
            ArrowLeft.SetActive(false);
        }
       
        if (Cars.GetComponent<Text>().text == "2")
        {
            ArrowRight.SetActive(true);
        }
    }
}
