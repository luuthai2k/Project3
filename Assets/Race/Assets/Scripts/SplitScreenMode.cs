using UnityEngine;
//if split-screen gamemode is selected in the play menu, when you select the track the race will load and this script will activate
public class SplitScreenMode : MonoBehaviour
{
    public int ModeSelection;
    public GameObject AICar01, Player2;//replace the AI car 1 with the player 2 car
    public GameObject Player2LeftPanel, Player2RightPanel;//turn on the player 2 UI
    public GameObject ArrowAI, ArrowP2; //replace the AI minimap arrow with the player 2 one
    public GameObject Minimap, MinimapP2; //turn on the player 2 minimap and move the minimap of player 1 to another position
    private GameObject[] CamParent, CamParentSplit;//find the cameras of the player's cars

    void Start()
    {
        ModeSelection = ModeSelect.RaceMode;//import race mode selected from play menu
        //normal cameras have the 'CameraParent' tag
        CamParent = GameObject.FindGameObjectsWithTag("CameraParent");
        //split-screen cameras have the 'CameraParentSplit' tag
        CamParentSplit = GameObject.FindGameObjectsWithTag("CameraParentSplit");

        if (ModeSelection == 3)
        {
            //If split-screen mode is selected the AI bot turns off and player 2 turns on
            AICar01.SetActive(false);
            Player2.SetActive(true);
            //Also, player 2 UI turns on
            Player2LeftPanel.SetActive(true);
            Player2RightPanel.SetActive(true);
            //All normal cameras from all cars turn off and only split-screen ones remain activated by default
            foreach (GameObject gOb in CamParent) { gOb.SetActive(false); };          
            //Deactivates the AI blue arrow and activates the P2 (Player 2) green one.
            ArrowAI.SetActive(false);
            ArrowP2.SetActive(true);
            //Moves the Player 1 minimap to the first half of the screen.
            Minimap.GetComponent<RectTransform>().anchoredPosition = (new Vector2(120,625));
            //Actiivates the minimap for P2
            MinimapP2.SetActive(true);
        }
        else
        {
            //if split-screen mode is not selected, then split-screen cameras turn off
            foreach (GameObject gOb in CamParentSplit) { gOb.SetActive(false); };
        }
    }
}