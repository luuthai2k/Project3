using UnityEngine;
using UnityEngine.UI;
//this script is used to unlock cars with money
public class Unlockables : MonoBehaviour
{
    //when you start the game or the player prefs are reset, car 2 and 3 are locked
    public GameObject LockedCar2;
    public GameObject LockedCar3;  
    public int cashValue;

    void Update()
    {
        //if you have enough cash to buy the cars, you can unlock them
        cashValue = GlobalCash.TotalCash;
        if (cashValue >= 100)
        {
            LockedCar3.GetComponent<Button>().interactable = true;
        }
        if (cashValue >= 100)
        {
            LockedCar2.GetComponent<Button>().interactable = true;
        }
    }
    //this void is in the button that let's you unlock the car number 3
    public void Car3Unlock()
    {
        LockedCar3.SetActive(false);
        cashValue -= 100;
        GlobalCash.TotalCash -= 100;
        PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
        PlayerPrefs.SetInt("UnlockedCar3", 100);

    }
    //this void is in the button that let's you unlock the car number 2
    public void Car2Unlock()
    {
        LockedCar2.SetActive(false);
        cashValue -= 100;
        GlobalCash.TotalCash -= 100;
        PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
        PlayerPrefs.SetInt("UnlockedCar2", 100);

    }
}