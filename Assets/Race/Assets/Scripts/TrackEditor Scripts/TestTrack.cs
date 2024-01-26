using System.Collections;
using UnityEngine;

public class TestTrack : MonoBehaviour
{
    public GameObject PlayObjects, Player, MainPanel, Borders, RaceUI, ReturnBtn, TrackManager;
    public Camera Cam;

    public void Start()
    {       
        //once you hit test button the track editor elements go off and a car and minimap turns on to play
        PlayObjects.SetActive(false);
        RaceUI.SetActive(true);
        Player.SetActive(true);
        MainPanel.SetActive(false);
        Borders.SetActive(false);
        Camera.main.orthographic = false;
        Cam.GetComponent<Animator>().enabled = true;
        //also it starts a coroutine that you can see at the bottom of this script
        StartCoroutine(Test());
        //when you hit play the IsPlay variables turn to true so you can't keep placing new track parts
        InstMousePos.lIsPlay = true;
        TrackManager.GetComponent<InstContPos>().enabled = false;
        TrackManager.GetComponent<InstMousePos>().enabled = false;
        Cam.GetComponent<AudioListener>().enabled = false;
    }

    public void ReturnButton()
    {
        //when you hit Back button in the top left corner all play objects turn off
        RaceUI.SetActive(false);
        Player.SetActive(false);
        MainPanel.SetActive(true);
        Borders.SetActive(true);
        Cam.enabled = true;
        Cam.orthographic = true;
        Cam.GetComponent<Animator>().enabled = false;
        //the IsPlay variables turns back to false so you can place new track parts
        InstMousePos.lIsPlay = false;
        //the player goes back to the start grid
        Player.transform.position = new Vector3(66.75f, 0.125f, 157.5f);
        Player.transform.eulerAngles = new Vector3(0, 0, 0);
        //the camera returns to the normal position
        Cam.transform.position = new Vector3(100, 200, 175.5f);
        Cam.transform.eulerAngles = new Vector3(90, -90, 0);
        //and the back button gets deactivated until the next play session
        ReturnBtn.SetActive(false);
        PlayObjects.SetActive(true);
        TrackManager.GetComponent<InstContPos>().enabled = true;
        TrackManager.GetComponent<InstMousePos>().enabled = true;
        Cam.GetComponent<AudioListener>().enabled = true;
    }

    IEnumerator Test()
    {
        //this coroutine starts when you hit play button and it moves the camera to the player using an Animator
        yield return new WaitForSeconds(2.9f);
        //and changes the camera to the player's car
        Cam.enabled = false;
        ReturnBtn.SetActive(true);
        
    }
}
