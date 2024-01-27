using UnityEngine;
public class UnlockedObjects : MonoBehaviour
{
    public int Car3Select;
    public int Car2Select;
    public GameObject LockedCar3;
    public GameObject LockedCar2;

    void Start()
    {
        Car3Select = PlayerPrefs.GetInt("UnlockedCar3");
        if (Car3Select == 100)
        {
            LockedCar3.SetActive(false);
        }
        Car2Select = PlayerPrefs.GetInt("UnlockedCar2");
        if (Car2Select == 100)
        {
            LockedCar2.SetActive(false);
        }
    }

}