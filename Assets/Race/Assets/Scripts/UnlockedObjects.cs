using UnityEngine;
//this scipt saves in the player prefs which cars you have unlocked
public class UnlockedObjects : MonoBehaviour
{
    //starting the game for the first time or reseting player prefs will lock the cars again
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