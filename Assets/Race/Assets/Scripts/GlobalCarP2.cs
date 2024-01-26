using UnityEngine;
using UnityEngine.UI;

public class GlobalCarP2 : MonoBehaviour
{

    public static int CarType;
    public GameObject CarSelectedP2;
    public GameObject Continue2;

    public void Car1()
    {
        CarType = 1;
        CarSelectedP2.GetComponent<Text>().text = "Parsche selected for player 2";
        Continue2.SetActive(true);
    }

    public void Car2()
    {
        CarType = 2;
        CarSelectedP2.GetComponent<Text>().text = "Farara selected for player 2";
        Continue2.SetActive(true);
    }

    public void Car3()
    {
        CarType = 3;
        CarSelectedP2.GetComponent<Text>().text = "Lamba selected for player 2";
        Continue2.SetActive(true);
    }
}