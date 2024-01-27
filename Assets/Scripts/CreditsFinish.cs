using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//this script is used to show the credits text in the credits scene
public class CreditsFinish : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CreditsAnim());//start credits animation
    }

    IEnumerator CreditsAnim()
    {
        //you can change the lenght of the credits by changing the number inside the () right now its at 10
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(1);//load main menu scene after the credits ends
    }
}