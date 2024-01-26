using System;
using UnityEngine;
using UnityEngine.UI;
//This script its a modification of LapSelector script, you can check full commentaries and definitions in there.
public class CarSelectorP2 : MonoBehaviour
{
    public GameObject Car1P2, Car2P2, Car3P2;
    public GameObject ArrowRightP2;
    public GameObject ArrowLeftP2;
    public GameObject CarsP2;
    public static int nCars;
    public static int sCars;

    public void Update()
    {
        if (CarsP2.GetComponent<Text>().text == "1")
        {
            sCars = 1;
            Car1P2.SetActive(true);
            Car2P2.SetActive(false);
        }
        if (CarsP2.GetComponent<Text>().text == "2")
        {
            sCars = 2;
            Car1P2.SetActive(false);
            Car2P2.SetActive(true);
            Car3P2.SetActive(false);
        }
        if (CarsP2.GetComponent<Text>().text == "3")
        {
            sCars = 3;
            Car2P2.SetActive(false);
            Car3P2.SetActive(true);
        }
    }

    public void Right()
    {
        nCars = Convert.ToInt32(CarsP2.GetComponent<Text>().text) + 1;
        CarsP2.GetComponent<Text>().text = Convert.ToString(nCars);
        //the player reaches the third car and the right arrow gets deactivated
        if (CarsP2.GetComponent<Text>().text == "3")
        {
            ArrowRightP2.SetActive(false);
        }
        //reactivate the left arrow
        if (CarsP2.GetComponent<Text>().text == "2")
        {
            ArrowLeftP2.SetActive(true);
        }
    }

    public void Left()
    {
        nCars = Convert.ToInt32(CarsP2.GetComponent<Text>().text) - 1;
        CarsP2.GetComponent<Text>().text = Convert.ToString(nCars);
        //the player reaches the first car and the left arrow gets deactivated
        if (CarsP2.GetComponent<Text>().text == "1")
        {
            ArrowLeftP2.SetActive(false);
        }
        //reactivate the right arrow
        if (CarsP2.GetComponent<Text>().text == "2")
        {
            ArrowRightP2.SetActive(true);
        }
    }
}
