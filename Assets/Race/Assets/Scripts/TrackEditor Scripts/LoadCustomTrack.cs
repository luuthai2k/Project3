using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCustomTrack : MonoBehaviour
{
    public static int CustomTrack;

    public void Track1 ()
    {
        SceneManager.LoadScene(6);
        CustomTrack = 1;
    }
    public void Track2()
    {
        SceneManager.LoadScene(6);
        CustomTrack = 2;
    }
    public void Track3()
    {
        SceneManager.LoadScene(6);
        CustomTrack = 3;
    }
}
