using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script manages all the buttons behaviour
public class BtnManager : MonoBehaviour
{
    private Vector3 mousePoint, vec3;
    public static GameObject pitpiece;
    public GameObject box;
    public static string deletePit;
    public Camera mainCamera;
    public Button myButton;
    public static List<GameObject> trackParts = new List<GameObject>();
    public GameObject Panel1, Panel2, TrackManager;
    private GameObject[] UnnamedChks;
    private int CustomTrackSelected;

    //when the scene starts, the first selected piece is the Straight
    private void Start()
    {
        Straight();
        UnnamedChks = GameObject.FindGameObjectsWithTag("chk");
        CustomTrackSelected = LoadCustomTrack.CustomTrack;
        if (CustomTrackSelected != 0)
        {
            foreach (GameObject go in UnnamedChks)
            {
                if (go.name == "Chk")
                {
                    go.GetComponent<Checkpoint>().enabled = false;//turn off the track editor example parts checkpoints
                }
            }
        }
        else
        {
            foreach (GameObject go in UnnamedChks)
            {
                if (go.name == "Chk")
                {
                    go.SetActive(false);//turn off the track editor example parts checkpoints
                }
            }
        }
    }

    //track pieces:
    public void Straight()
    {
        pitpiece = GameObject.Find("/roadStraight");//find them with the exact same name that has in the inspector
        deletePit = "No";//the only piece that can delete objects is the 'Delete' one (you can find it in line 122)
        ActiveBorder(1);//shows a border around the button when selected
    }

    public void Straight90()
    {
        pitpiece = GameObject.Find("/roadStraight90"); deletePit = "No"; ActiveBorder(2);
    }

    public void Corner()
    {
        pitpiece = GameObject.Find("/roadCornerSmall"); deletePit = "No"; ActiveBorder(3);
    }

    public void Corner90()
    {
        pitpiece = GameObject.Find("/roadCornerSmall90"); deletePit = "No"; ActiveBorder(4);
    }

    public void Corner180()
    {
        pitpiece = GameObject.Find("/roadCornerSmall180"); deletePit = "No"; ActiveBorder(5);
    }

    public void Corner270()
    {
        pitpiece = GameObject.Find("/roadCornerSmall270"); deletePit = "No"; ActiveBorder(6);
    }
    //decoration buttons (panel 2)
    public void Tent()
    {
        pitpiece = GameObject.Find("/tent"); deletePit = "No"; ActiveBorder(7);
    }
    public void TentClosed()
    {
        pitpiece = GameObject.Find("/tentClosed"); deletePit = "No"; ActiveBorder(8);
    }
    public void treeLarge()
    {
        pitpiece = GameObject.Find("/treeLarge"); deletePit = "No"; ActiveBorder(9);
    }
    public void Stand()
    {
        pitpiece = GameObject.Find("/grandStand"); deletePit = "No"; ActiveBorder(10);
    }

    //undo button in InstContPos (track parts) / supr button in InstMousePos (decoration objects)
    public void Delete()
    {
        deletePit = "Yes";//with deletePit in Yes, we can delete placed objects
        ActiveBorder(11);
    }

    //goes back to track parts (panel 1)
    public void Less()
    {
        //change the UI
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        //change the mouse routine
        TrackManager.GetComponent<InstContPos>().enabled = true;
        TrackManager.GetComponent<InstMousePos>().enabled = false;
        Straight();//first one selected is straight
    }
    //goes to decoration objects (panel 2)
    public void More()
    {
        //change the UI
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        //change the mouse routine
        TrackManager.GetComponent<InstContPos>().enabled = false;
        TrackManager.GetComponent<InstMousePos>().enabled = true;
        Tent();//first one selected is tent
    }

    //UI borders around the button activation
    public void ActiveBorder(int borderNum)
    {
        //change the UI border around the last pressed button by the user
        for(int i=1; i <= 11; i++)
        {
            GameObject border = GameObject.Find("/Canvas/Borders/Border" + i);
            if (borderNum == i)
            {
                border.GetComponent<Image>().enabled=true;
            }
            else
            {
                border.GetComponent<Image>().enabled = false;
            }
        }
    }
}
