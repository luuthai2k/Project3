using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    //save/load the tracks in the 3 slots
    public GameObject LoadBtn, SaveSlots, LoadSlots, TrackManager;
    public static GameObject pitpiece;
    private int CustomTrackSelected;

    private void Start()
    {     
        CustomTrackSelected = LoadCustomTrack.CustomTrack;
        if (CustomTrackSelected == 1)
        {
            LoadGame();
            TrackManager.GetComponent<PlayTrack>().enabled = true;
        }
        if (CustomTrackSelected == 2)
        {
            LoadGame2();
            TrackManager.GetComponent<PlayTrack>().enabled = true;
        }
        if (CustomTrackSelected == 3)
        {
            LoadGame3();
            TrackManager.GetComponent<PlayTrack>().enabled = true;
        }
    }

    public void RestartCustomTrack()
    {
        CustomTrackSelected = LoadCustomTrack.CustomTrack;
        SceneManager.LoadScene(6);
        if (CustomTrackSelected == 1)
        {
            LoadGame();
        }
        if (CustomTrackSelected == 2)
        {
            LoadGame2();
        }
        if (CustomTrackSelected == 3)
        {
            LoadGame3();
        }
    }

    //select save/load slot
    public void SelectSaveSlot()
    {
        SaveSlots.SetActive(true);
    }
    public void SelectLoadSlot()
    {
        LoadBtn.SetActive(false);
        LoadSlots.SetActive(true);
    }

    //save track in slot 1
    public void SaveGame()
    {
        // 1 creating the save file
        Save save = InstContPos.CreateSaveGameObject();
        Save save1 = InstMousePos.CreateSaveGameObject();

        // 2 instcontpos (track parts roads: straights, turns...)
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
        // 2 instmousepos (track objects: tents, stands, rails...)
        BinaryFormatter bf1 = new BinaryFormatter();
        FileStream file1 = File.Create(Application.persistentDataPath + "/gamesaveObj.save");
        bf.Serialize(file1, save1);
        file.Close();
        // 3 done
        SaveSlots.SetActive(false);
        Debug.Log("Game Saved in Slot 1");
    }

    //save track in slot 2
    public void SaveGame2()
    {
        // 1
        Save save = InstContPos.CreateSaveGameObject();
        Save save1 = InstMousePos.CreateSaveGameObject();

        // 2 instcontpos (track parts roads: straights, turns...)
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave2.save");
        bf.Serialize(file, save);
        file.Close();
        // 2 instmousepos (track objects: tents, stands, rails...)
        BinaryFormatter bf1 = new BinaryFormatter();
        FileStream file1 = File.Create(Application.persistentDataPath + "/gamesave2Obj.save");
        bf.Serialize(file1, save1);
        file.Close();
        // 3 done
        SaveSlots.SetActive(false);
        Debug.Log("Game Saved in Slot 2");
    }

    //save track in slot 3
    public void SaveGame3()
    {
        // 1
        Save save = InstContPos.CreateSaveGameObject();
        Save save1 = InstMousePos.CreateSaveGameObject();

        // 2 instcontpos (track parts roads: straights, turns...)
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave3.save");
        bf.Serialize(file, save);
        file.Close();
        // 2 instmousepos (track objects: tents, stands, rails...)
        BinaryFormatter bf1 = new BinaryFormatter();
        FileStream file1 = File.Create(Application.persistentDataPath + "/gamesave3Obj.save");
        bf.Serialize(file1, save1);
        file.Close();
        // 3 done
        SaveSlots.SetActive(false);
        Debug.Log("Game Saved in Slot 3");
    }

    //load track saved in slot 1
    public void LoadGame()
    {
        // 0
        InstContPos.RefreshTrackParts();
        InstContPos.DeleteTrackParts();
        InstContPos.nAbsInst = 0;
        // 1
        Vector3 vec;
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = new Save();
            save = (Save)bf.Deserialize(file);
            file.Close();
            // 3
            InstContPos.vecPositions = save.pitPositions;
            InstContPos.namePitPieces = save.nameSavedPieces;
            for (int i = 0; i < save.nSavedInst; i++)
            {
                if (!(InstContPos.namePitPieces[i] == "roadStartPositionsSmall"))
                {
                    vec.x = InstContPos.vecPositions[i][0];
                    vec.y = InstContPos.vecPositions[i][1];
                    vec.z = InstContPos.vecPositions[i][2];
                    pitpiece = GameObject.Find(InstContPos.namePitPieces[i]);
                    InstContPos.vec3 = vec;
                    InstContPos.box = pitpiece.transform;
                    InstContPos.InstantiatePit("");
                }
            }
            save.pitPositions.Clear();
            save.nameSavedPieces.Clear();
            save.nSavedInst = 0;
            //// InstMousePos
            InstMousePos.RefreshTrackParts();
            InstMousePos.DeleteTrackParts();
            // 1

            if (File.Exists(Application.persistentDataPath + "/gamesaveObj.save"))
            {
                // 2
                bf = new BinaryFormatter();
                file = File.Open(Application.persistentDataPath + "/gamesaveObj.save", FileMode.Open);
                save = new Save();
                save = (Save)bf.Deserialize(file);
                file.Close();
                // 3
                InstMousePos.vecPositions1 = save.pitPositions;
                InstMousePos.namePitPieces1 = save.nameSavedPieces;
                for (int i = 0; i < save.nSavedInst; i++)
                {
                    if (!(InstMousePos.namePitPieces1[i] == "roadStartPositionsSmall"))
                    {
                        vec.x = InstMousePos.vecPositions1[i][0];
                        vec.y = InstMousePos.vecPositions1[i][1];
                        vec.z = InstMousePos.vecPositions1[i][2];
                        pitpiece = GameObject.Find(InstMousePos.namePitPieces1[i]);
                        InstMousePos.vec3 = vec;
                        InstMousePos.box = pitpiece.transform;
                        InstMousePos.InstantiatePit();
                    }
                }
                save.pitPositions.Clear();
                save.nameSavedPieces.Clear();
                save.nSavedInst = 0;
                // 4
                LoadBtn.SetActive(true);
                LoadSlots.SetActive(false);
            }
        }
        else
        {
            LoadBtn.SetActive(true);
            LoadSlots.SetActive(false);
        }
        //myButton.interactable = false;
        InstContPos.RefreshTrackParts();
    }

    //load track saved in slot 2
    public void LoadGame2()
    {
        // 0
        InstContPos.RefreshTrackParts();
        InstContPos.DeleteTrackParts();
        InstContPos.nAbsInst = 0;
        // 1
        Vector3 vec;
        if (File.Exists(Application.persistentDataPath + "/gamesave2.save"))
        {
            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave2.save", FileMode.Open);
            Save save = new Save();
            save = (Save)bf.Deserialize(file);
            file.Close();
            // 3
            InstContPos.vecPositions = save.pitPositions;
            InstContPos.namePitPieces = save.nameSavedPieces;
            for (int i = 0; i < save.nSavedInst; i++)
            {
                if (!(InstContPos.namePitPieces[i] == "roadStartPositionsSmall"))
                {
                    vec.x = InstContPos.vecPositions[i][0];
                    vec.y = InstContPos.vecPositions[i][1];
                    vec.z = InstContPos.vecPositions[i][2];
                    pitpiece = GameObject.Find(InstContPos.namePitPieces[i]);
                    InstContPos.vec3 = vec;
                    InstContPos.box = pitpiece.transform;
                    InstContPos.InstantiatePit("");
                }
            }
            save.pitPositions.Clear();
            save.nameSavedPieces.Clear();
            save.nSavedInst = 0;
            //// InstMousePos
            InstMousePos.RefreshTrackParts();
            InstMousePos.DeleteTrackParts();
            // 1

            if (File.Exists(Application.persistentDataPath + "/gamesave2Obj.save"))
            {
                // 2
                bf = new BinaryFormatter();
                file = File.Open(Application.persistentDataPath + "/gamesave2Obj.save", FileMode.Open);
                save = new Save();
                save = (Save)bf.Deserialize(file);
                file.Close();
                // 3
                InstMousePos.vecPositions1 = save.pitPositions;
                InstMousePos.namePitPieces1 = save.nameSavedPieces;
                for (int i = 0; i < save.nSavedInst; i++)
                {
                    if (!(InstMousePos.namePitPieces1[i] == "roadStartPositionsSmall"))
                    {
                        vec.x = InstMousePos.vecPositions1[i][0];
                        vec.y = InstMousePos.vecPositions1[i][1];
                        vec.z = InstMousePos.vecPositions1[i][2];
                        pitpiece = GameObject.Find(InstMousePos.namePitPieces1[i]);
                        InstMousePos.vec3 = vec;
                        InstMousePos.box = pitpiece.transform;
                        InstMousePos.InstantiatePit();
                    }
                }
                save.pitPositions.Clear();
                save.nameSavedPieces.Clear();
                save.nSavedInst = 0;
                // 4
                LoadBtn.SetActive(true);
                LoadSlots.SetActive(false);
            }
        }
        else
        {
            LoadBtn.SetActive(true);
            LoadSlots.SetActive(false);
        }
        //myButton.interactable = false;
        InstContPos.RefreshTrackParts();
    }

    //load track saved in slot 3
    public void LoadGame3()
    {
        // 0
        InstContPos.RefreshTrackParts();
        InstContPos.DeleteTrackParts();
        InstContPos.nAbsInst = 0;
        // 1
        Vector3 vec;
        if (File.Exists(Application.persistentDataPath + "/gamesave3.save"))
        {
            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave3.save", FileMode.Open);
            Save save = new Save();
            save = (Save)bf.Deserialize(file);
            file.Close();
            // 3
            InstContPos.vecPositions = save.pitPositions;
            InstContPos.namePitPieces = save.nameSavedPieces;
            for (int i = 0; i < save.nSavedInst; i++)
            {
                if (!(InstContPos.namePitPieces[i] == "roadStartPositionsSmall"))
                {
                    vec.x = InstContPos.vecPositions[i][0];
                    vec.y = InstContPos.vecPositions[i][1];
                    vec.z = InstContPos.vecPositions[i][2];
                    pitpiece = GameObject.Find(InstContPos.namePitPieces[i]);
                    InstContPos.vec3 = vec;
                    InstContPos.box = pitpiece.transform;
                    InstContPos.InstantiatePit("");
                }
            }
            save.pitPositions.Clear();
            save.nameSavedPieces.Clear();
            save.nSavedInst = 0;
            //// InstMousePos
            InstMousePos.RefreshTrackParts();
            InstMousePos.DeleteTrackParts();
            // 1

            if (File.Exists(Application.persistentDataPath + "/gamesave3Obj.save"))
            {
                // 2
                bf = new BinaryFormatter();
                file = File.Open(Application.persistentDataPath + "/gamesave3Obj.save", FileMode.Open);
                save = new Save();
                save = (Save)bf.Deserialize(file);
                file.Close();
                // 3
                InstMousePos.vecPositions1 = save.pitPositions;
                InstMousePos.namePitPieces1 = save.nameSavedPieces;
                for (int i = 0; i < save.nSavedInst; i++)
                {
                    if (!(InstMousePos.namePitPieces1[i] == "roadStartPositionsSmall"))
                    {
                        vec.x = InstMousePos.vecPositions1[i][0];
                        vec.y = InstMousePos.vecPositions1[i][1];
                        vec.z = InstMousePos.vecPositions1[i][2];
                        pitpiece = GameObject.Find(InstMousePos.namePitPieces1[i]);
                        InstMousePos.vec3 = vec;
                        InstMousePos.box = pitpiece.transform;
                        InstMousePos.InstantiatePit();
                    }
                }
                save.pitPositions.Clear();
                save.nameSavedPieces.Clear();
                save.nSavedInst = 0;
                // 4
                LoadBtn.SetActive(true);
                LoadSlots.SetActive(false);
            }
        }
        else
        {
            LoadBtn.SetActive(true);
            LoadSlots.SetActive(false);
        }
        //myButton.interactable = false;
        InstContPos.RefreshTrackParts();
    }
}
