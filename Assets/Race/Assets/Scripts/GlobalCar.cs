using UnityEngine;
using UnityEngine.UI;

public class GlobalCar : MonoBehaviour
{

    public static int CarType;
    public GameObject CarSelected;
    public GameObject Continue2;

    public void Car1()
    {
        CarType = 1;
        CarSelected.GetComponent<Text>().text = "Parsche selected";
        Continue2.SetActive(true);
    }

    public void Car2()
    {
        CarType = 2;
        CarSelected.GetComponent<Text>().text = "Farara selected";
        Continue2.SetActive(true);
    }

    public void Car3()
    {
        CarType = 3;
        CarSelected.GetComponent<Text>().text = "Lamba selected";
        Continue2.SetActive(true);
    }
}