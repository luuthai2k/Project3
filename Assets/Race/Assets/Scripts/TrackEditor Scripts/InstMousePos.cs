using System.Collections.Generic;
using UnityEngine;
//this script spawns the decoration objects in the mouse position
public class InstMousePos : MonoBehaviour
{
    private Vector3 mousePoint;
    public static Vector3 vec3, mousepos;
    public static Transform box;
    public GameObject boxph;
    public Camera mainCamera;
    private float mZCoord, mZCoord1;
    public static GameObject newPit, gob;
    public static int sizeGrid = 10;
    public static string objSelected;
    public static bool lColor, lIsPlay;
    public Collider[] colliders;
    public float radius;
    public LayerMask m_LayerMask;
    public static int nAbsInst;

    [SerializeField]
    public static List<List<float>> vecPositions1 = new List<List<float>>();
    public static List<string> namePitPieces1 = new List<string>();
    public static int nInst1;
    //when the scene starts:
    void Start()
    {
        lColor = false;
        nAbsInst = 0;
        lIsPlay = false;//we are not playing a race, we are creating the track, so IsPlay = false

        //Align the new pit to 10x10 grid 
        vec3.x = AlignToGrid(vec3.x);
        vec3.y = 10;
        vec3.z = AlignToGrid(vec3.z);
        mousePoint = Input.mousePosition;
        mZCoord1 = mainCamera.WorldToScreenPoint(boxph.transform.position).z;
        mousePoint.z = mZCoord1;
        mousepos = mainCamera.ScreenToWorldPoint(mousePoint);
        boxph = Instantiate(boxph, mousepos, Quaternion.identity) as GameObject;
        boxph.transform.position = mousepos;
    }

    void Update()
    {
        mainCamera = Camera.main;//set the main camera
        mZCoord = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
        mZCoord1 = mainCamera.WorldToScreenPoint(boxph.transform.position).z;
        mousePoint = Input.mousePosition;//set the mouse position
        mousePoint.z = mZCoord1;
        mousepos = mainCamera.ScreenToWorldPoint(mousePoint);
        //alling objects to the grid
        mousepos.x = AlignToGrid(mousepos.x);
        mousepos.y = 10;
        mousepos.z = AlignToGrid(mousepos.z);
        if (!lIsPlay)
        {
            boxph.transform.position = mousepos;
        }
        if (Input.GetMouseButtonUp(1) && !lIsPlay)
        {
            //Reset trackPart array to start adding parts from the begining
            box = BtnManager.pitpiece.transform;
            mousePoint = Input.mousePosition;
            mousePoint.z = mZCoord;
            vec3 = mainCamera.ScreenToWorldPoint(mousePoint);
            vec3.y = 0;
            //Align the new pit to 10x10 grid 
            vec3.x = AlignToGrid(vec3.x);
            vec3.z = AlignToGrid(vec3.z);
            RefreshTrackParts();
            if (CheckPos(vec3, "None") && BtnManager.deletePit == "No")
            {
                InstantiatePit();
            }
        }
    }
    //each object placed (with right click)
    public static void InstantiatePit()
    {
        Instantiate(box, vec3, Quaternion.identity);
        newPit = GameObject.Find(box.name + "(Clone)");
        newPit.gameObject.tag = "TrackObj";
        newPit.AddComponent<DragObject>();
        RefreshTrackParts();
        newPit.name = newPit.name + nAbsInst;
        nAbsInst++;
        BtnManager.trackParts.Add(newPit);
    }
    //check if the position to create a pit is available
    public static bool CheckPos(Vector3 vec, string name)
    {
        bool lPosOk;
        //Terrain limits, you can't get out of these coordinates:
        if (vec.x < 190 && vec.z < 290 && vec.x > 0 && vec.z > 10)
        {
            lPosOk = true;
            if (nInst1 == 0)
            {
                return lPosOk;
            }
            for (int i = 0; i < nInst1; i++)
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
        BtnManager.trackParts.AddRange(GameObject.FindGameObjectsWithTag("TrackObj"));
        nInst1 = BtnManager.trackParts.Count;
    }

    public static void DeleteTrackParts()
    {
        // Delete pit piece if delete button is selected
        foreach (GameObject track in BtnManager.trackParts)
        {
            if (!(track.name == "roadStartPositionsSmall"))
            {
                Destroy(track, .1f);
            }
        }
    }

    void OnMouseUp()
    {
        if (BtnManager.deletePit == "Yes")
        {
            Destroy(gameObject, .1f);
        }
        RefreshTrackParts();
    }
    //creates a save object when requested (by pressing one of the save slots buttons)
    public static Save CreateSaveGameObject()
    {
        RefreshTrackParts();
        //and we create a save file with all the track objects information
        Save save = new Save();

        for (int j = 0; j < nInst1; j++)
        {
            string mesh = BtnManager.trackParts[j].GetComponent<MeshFilter>().sharedMesh.name;
            namePitPieces1.Add(mesh);
            List<float> level1 = new List<float>();
            level1.Add(BtnManager.trackParts[j].transform.position.x);
            level1.Add(BtnManager.trackParts[j].transform.position.y);
            level1.Add(BtnManager.trackParts[j].transform.position.z);
            vecPositions1.Add(level1);
        }

        for (int i = 0; i < nInst1; i++)
        {
            save.pitPositions = vecPositions1; //xyz
            save.nameSavedPieces = namePitPieces1;
        }
        save.nSavedInst = nInst1;
        return save;
    }
}