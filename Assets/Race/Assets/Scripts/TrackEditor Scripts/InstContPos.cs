using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//this script creates the road track pieces in the mouse position
public class InstContPos : MonoBehaviour
{
    private Vector3 mousePoint, moveboxph;
    public static Vector3 vec3, mousepos;
    public static Transform box;
    public GameObject boxph;
    public Camera mainCamera;
    private float mZCoord;
    public static GameObject newPit, gob;
    public static int sizeGrid = 10;
    public static string objSelected, lastBoxName, instOrientation, instOrientationLast, currentBoxName, lastPitName;
    public static bool lColor, lIsPlay, lIsFreeMode;
    public Collider[] colliders;
    public float radius;
    public LayerMask m_LayerMask;
    public static int nAbsInst;
    public GameObject TrackManager;
    public Button UndoBtn, InstatiateBtn;

    [SerializeField]
    public static List<List<float>> vecPositions = new List<List<float>>();
    public static List<string> namePitPieces = new List<string>();
    public static int nInst;
    //when the scene starts:
    void Start()
    {
        InstatiateBtn.onClick.AddListener(InstatiateTrue);
        lColor = false;
        nAbsInst = 0;
        lIsPlay = false;//we are not playing a race, we are creating the track, so IsPlay = false
        lIsFreeMode = false;
        lastBoxName = "roadStraight"; //the track part selected by default is straight (in BtnManager) so we set it here too
        instOrientation = "East"; //and it will go to the right when placing a new one, so East
        UndoBtn.interactable = false; //we can't undo without having placed anything yet
        //set the default position of the scene when starts
        mousepos.x = 60;
        mousepos.y = 0;
        mousepos.z = 160;
        vec3 = mousepos;
        boxph = Instantiate(boxph, mousepos, Quaternion.identity) as GameObject;
    }

    void InstatiateTrue()
    {
        if (!lIsPlay)
        {
            //Reset trackPart array to start adding parts from the begining
            box = BtnManager.pitpiece.transform;
            if (lIsFreeMode)
            {
                mousePoint = Input.mousePosition;
                mousePoint.z = mZCoord;
                vec3 = mainCamera.ScreenToWorldPoint(mousePoint);
                vec3.y = 0;
                //Align the new pit to 10x10 grid
                vec3.x = AlignToGrid(vec3.x);
                vec3.z = AlignToGrid(vec3.z);
            }
            else
            {
                vec3 = boxph.transform.position;
            }

            RefreshTrackParts();//refresh works like saving in runtime

            if (CheckPos(vec3, "None") && BtnManager.deletePit == "No")
            {
                lastBoxName = BtnManager.pitpiece.transform.name;
                InstantiatePit("");
                boxph.transform.position = mousepos;
                UndoBtn.interactable = true;
            }
        }
    }

    void Update()
    {
        mainCamera = Camera.main;   //set the main camera
        mousePoint = Input.mousePosition;//set the mouse position
        //allign the road pieces to the grid
        mousepos.x = AlignToGrid(mousepos.x);
        mousepos.y = 10;
        mousepos.z = AlignToGrid(mousepos.z);
        //if we are not playing a race, and we are creating a track
        if (!lIsPlay)
        {
            mousepos = mainCamera.ScreenToWorldPoint(mousePoint);//set the mouse pos
            mZCoord = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;//and the coords
            boxph.SetActive(true);
        }
        if (BtnManager.deletePit == "Yes")//if the user selects the delete button
        {
            InstantiatePit("Undo");//we undo the last placed piece
            boxph.transform.position = mousepos;
            nAbsInst--;
            UndoBtn.interactable = false;
            instOrientation = instOrientationLast;
        }
    }
    //when the user right clicks, that's were a pit is instantiated
    public static void InstantiatePit(string sAction)
    {
        if (sAction == "")//normal buttons (not undo)
        {
            Instantiate(box, vec3, Quaternion.identity);
            newPit = GameObject.Find(box.name + "(Clone)");
            newPit.gameObject.tag = "TrackPart";
            RefreshTrackParts();
            newPit.name = newPit.name + nAbsInst;
            newPit.transform.GetChild(0).name = newPit.transform.GetChild(0).name + (nAbsInst + 1);
            newPit.transform.GetChild(1).name = newPit.transform.GetChild(1).name + (nAbsInst + 1);
            nAbsInst++;
            lastPitName = newPit.name;
            BtnManager.trackParts.Add(newPit);

            drawBoxPh();

        }
        else
        if (sAction == "Undo")//undo button
        {
            mousepos = GameObject.Find(lastPitName).transform.position;
            Destroy(GameObject.Find(lastPitName), .1f);
            BtnManager.deletePit = "No";
        }
    }
    //each time you draw a new track piece (with right click)
    public static void drawBoxPh()
    {
        currentBoxName = BtnManager.pitpiece.transform.name;
        instOrientationLast = instOrientation;
        switch (lastBoxName)
        {
            case "roadStraight":
                mousepos.x = vec3.x;
                mousepos.y = vec3.y;
                //it defines the spawn orientation (East, West, North, South) for each track piece
                if (instOrientation == "East")
                {
                    mousepos.z = vec3.z + 10; //Straight only                                                  
                }
                else
                {
                    //West
                    mousepos.z = vec3.z - 10;
                }
                break;
            case "roadCornerSmall":
                mousepos.y = vec3.y;
                if (instOrientation == "East")
                {
                    mousepos.x = vec3.x - 10;
                    mousepos.z = vec3.z;
                    instOrientation = "North";
                }
                else
                {
                    mousepos.x = vec3.x;
                    mousepos.z = vec3.z - 10;
                    instOrientation = "West";
                }
                break;
            case "roadCornerSmall90":
                mousepos.y = vec3.y;
                if (instOrientation == "West")
                {
                    mousepos.x = vec3.x - 10;
                    mousepos.z = vec3.z;
                    instOrientation = "North";
                }
                else
                {
                    mousepos.x = vec3.x;
                    mousepos.z = vec3.z + 10;
                    instOrientation = "East";
                }
                break;
            case "roadCornerSmall180":
                mousepos.y = vec3.y;
                if (instOrientation == "East")
                {
                    mousepos.x = vec3.x + 10;
                    mousepos.z = vec3.z;
                    instOrientation = "South";
                }
                else
                {
                    mousepos.x = vec3.x;
                    mousepos.z = vec3.z - 10;
                    instOrientation = "West";
                }
                break;
            case "roadCornerSmall270":
                mousepos.y = vec3.y;
                if (instOrientation == "North")
                {
                    mousepos.x = vec3.x;
                    mousepos.z = vec3.z + 10;
                    instOrientation = "East";
                }
                else
                {
                    mousepos.x = vec3.x + 10;
                    mousepos.z = vec3.z;
                    instOrientation = "South";
                }
                break;
            case "roadStraight90":
                if (instOrientation == "South")
                {
                    mousepos.x = vec3.x + 10; //Straight only                                                  
                }
                else
                {
                    //North
                    mousepos.x = vec3.x - 10;
                }
                mousepos.y = vec3.y;
                mousepos.z = vec3.z;
                break;
        }
    }
    //check if the position to create a pit is available
    public static bool CheckPos(Vector3 vec, string name)
    {
        bool lPosOk;
        //Terrain limits, you can't get out of these coordinates
        if (vec.x < 190 && vec.z < 290 && vec.x > 0 && vec.z > 10)
        {
            lPosOk = true;
            if (nInst == 0)
            {
                return lPosOk;
            }
            for (int i = 0; i < nInst; i++)
            {
                //Calculates distance between parts already in terrain and new ones
                double nDisX = Mathf.Abs(BtnManager.trackParts[i].transform.position.x - vec.x);
                double nDisZ = Mathf.Abs(BtnManager.trackParts[i].transform.position.z - vec.z);

                //If there are at least one part in terrain already in the same coords, avoid Instantiation of the new part
                if ((nDisX < sizeGrid) && (BtnManager.trackParts[i].name != name))
                {
                    if ((nDisZ < sizeGrid))
                    {
                        lPosOk = false;
                        break;
                    }
                }
            }
            return lPosOk;
        }
        else
        {
            lPosOk = false;
            return lPosOk;
        }
    }

    //Align gameobject to a grid of sizeGrid size
    public static float AlignToGrid(float vec)
    {
        float num = vec / 10;
        num = Mathf.Round(num) * 10;
        num = num / sizeGrid;
        num = Mathf.Round(num);
        num = num * sizeGrid;
        return num;
    }

    public static void RefreshTrackParts()
    {
        //refresh trackParts 
        BtnManager.trackParts.Clear();
        BtnManager.trackParts.AddRange(GameObject.FindGameObjectsWithTag("TrackPart"));
        nInst = BtnManager.trackParts.Count;
    }

    public static void DeleteTrackParts()
    {
        // Delete pit piece if the button delete was selected
        foreach (GameObject track in BtnManager.trackParts)
        {
            if (!(track.name == "roadStartPositionsSmall"))
            {
                Destroy(track, .1f);
            }
        }
    }

    //creates a save object when requested (by pressing one of the save slots buttons)
    public static Save CreateSaveGameObject()
    {
        RefreshTrackParts();
        //and we create a save file with all the track pieces information
        Save save = new Save();

        for (int j = 0; j < nInst; j++)
        {
            string mesh = BtnManager.trackParts[j].GetComponent<MeshFilter>().sharedMesh.name;
            namePitPieces.Add(mesh);
            List<float> level1 = new List<float>();
            level1.Add(BtnManager.trackParts[j].transform.position.x);
            level1.Add(BtnManager.trackParts[j].transform.position.y);
            level1.Add(BtnManager.trackParts[j].transform.position.z);
            vecPositions.Add(level1);
        }

        for (int i = 0; i < nInst; i++)
        {
            save.pitPositions = vecPositions; //xyz
            save.nameSavedPieces = namePitPieces;
        }
        save.nSavedInst = nInst;
        return save;
    }
}