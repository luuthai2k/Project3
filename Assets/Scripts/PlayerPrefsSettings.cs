using UnityEngine;
public class PlayerPrefsSettings : MonoBehaviour
{
    public void add()
    {
        GlobalCash.TotalCash += 100;
        PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}