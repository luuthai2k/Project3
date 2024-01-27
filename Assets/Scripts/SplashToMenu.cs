using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//when the application starts, it stays 5 seconds in the splash screen
public class SplashToMenu : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ToMenu());
    }
    //and then, it loads the main menu scene
    IEnumerator ToMenu()
    {
        yield return new WaitForSeconds(5);//here you can change the seconds
        SceneManager.LoadScene(1);
    }
}