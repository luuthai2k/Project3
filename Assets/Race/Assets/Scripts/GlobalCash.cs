using UnityEngine;
using UnityEngine.UI;
//this script shows the amount of cash of the player in a UI text
public class GlobalCash : MonoBehaviour
{
    public int CashValue;
    public static int TotalCash;
    public GameObject CashDisplay;//asign the UI text via Unity inspector

    void Start()
    {
        TotalCash = PlayerPrefs.GetInt("SavedCash");//get the saved data of how much cash the player has
    }

    void Update()
    {
        CashValue = TotalCash;
        CashDisplay.GetComponent<Text>().text = "Cash: $" + CashValue;
    }
}
