using UnityEngine;
using UnityEngine.UI;
public class Unlockables : MonoBehaviour
{
    public GameObject LockedCar2;
    public GameObject LockedCar3;  
    public int cashValue;

    void Update()
    {
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
    public void Car3Unlock()
    {
        LockedCar3.SetActive(false);
        cashValue -= 100;
        GlobalCash.TotalCash -= 100;
        PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
        PlayerPrefs.SetInt("UnlockedCar3", 100);

    }
    public void Car2Unlock()
    {
        LockedCar2.SetActive(false);
        cashValue -= 100;
        GlobalCash.TotalCash -= 100;
        PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
        PlayerPrefs.SetInt("UnlockedCar2", 100);

    }
}