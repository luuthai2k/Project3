using UnityEngine;
//in player prefs scene you can delete all saved data or add $100, for test purposings
public class PlayerPrefsSettings : MonoBehaviour
{
    //add $100 pressing the add 100 button in player prefs scene
    public void add()
    {
        GlobalCash.TotalCash += 100;
        PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
    }

    void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button on the player prefs scene
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}