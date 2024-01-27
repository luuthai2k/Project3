using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsScript : MonoBehaviour
{
    public static int RestartTrackEditor;

   
    public void PlayMode()
    {
       
        ModeSelect.RaceMode = 0;
        SceneManager.LoadScene("Play Menu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
   
    public void Exit()
    {
        Application.Quit();
    }

   
    public void Track01()
    {
        SceneManager.LoadScene("Track01");
    }

    public void Track02()
    {
        SceneManager.LoadScene("Track02");
    }

   
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}