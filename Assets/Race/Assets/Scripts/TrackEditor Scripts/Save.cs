using System.Collections.Generic;
//this script is used when creating a save file, pressing one of the save slots buttons
[System.Serializable]
public class Save
{
    public  List<List<float>> pitPositions= new List<List<float>>();
    public int nSavedInst;
    public List<string> nameSavedPieces = new List<string>();
}