using UnityEngine;
using UnityEngine.SceneManagement;
//this script is used to load scenes when a button requires it
public class ButtonsScript : MonoBehaviour
{
    public static int RestartTrackEditor;

    //Below here are menu buttons
    public void PlayMode()
    {
        LoadCustomTrack.CustomTrack = 0;
        ModeSelect.RaceMode = 0;
        SceneManager.LoadScene("Play Menu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    //pressing the quit button in the main menu will close the game (only in .exe not in Unity editor)
    public void Exit()
    {
        Application.Quit();
    }

    //Below here are track selection buttons
    public void Track01()
    {
        SceneManager.LoadScene("Track01");
    }

    public void Track02()
    {
        SceneManager.LoadScene("Track02");
    }

    //v1.5 Update, Track editor and settings scenes have been added
   
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}