using System.Collections;
using UnityEngine;

public class PlayTrack : MonoBehaviour
{
    public GameObject Cam, MainPanel, Borders, Minimap, MinimapP2, RaceUI, Countdown, ColorSelect, Trackers, ButtonManager;
    private GameObject[] UnnamedChks, boxphs;

    public void Start ()
    {
        //once you hit play button the track editor elements go off and a car and minimap turns on to play
        ColorSelect.SetActive(true);
        Trackers.SetActive(true);
        MainPanel.SetActive(false);
        Borders.SetActive(false);
        Camera.main.orthographic = false;
        Cam.GetComponent<Animator>().enabled = true;
        //also it starts a coroutine that you can see at the bottom of this script
        StartCoroutine(Play());
        //when you hit play the IsPlay variables turn to true so you can't keep placing new track parts
        InstMousePos.lIsPlay = true;
        InstContPos.lIsPlay = true;
        UnnamedChks = GameObject.FindGameObjectsWithTag("chk");
        foreach (GameObject go in UnnamedChks)
        {
            if (go.name != "Chk" && go.tag == "chk")
            {
                go.GetComponent<Checkpoint>().enabled = true;//turn on the race checkpoints
            }
        }
        boxphs = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject go in boxphs)
        {
            if (go.name.Contains("posHighlight"))
            {
                go.SetActive(false);
            }
        }
    }

    IEnumerator Play()
    {
        //this coroutine starts when you hit play button and it moves the camera to the player using an Animator
        yield return new WaitForSeconds(2.9f);
        Countdown.SetActive(true);
        //and changes the camera to the player's car
        Cam.SetActive(false);
        RaceUI.SetActive(true);
        Minimap.SetActive(true);
        //if split-screen is selected, then play mode will show the minimap for the player 2 and move up the player 1 minimap
        if (ModeSelect.RaceMode == 3)
        {
            yield return new WaitForSeconds(2.9f);
            Minimap.GetComponent<RectTransform>().anchoredPosition = (new Vector2(120, 625));
            MinimapP2.SetActive(true);
        }      
    }
}
