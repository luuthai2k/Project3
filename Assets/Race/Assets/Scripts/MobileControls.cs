using UnityEngine;

public class MobileControls : MonoBehaviour
{
    public GameObject MobileControlsUI;
    //This script will detect if you are playing on a phone/tablet
    //and it will activate the UI controls for the car in Track01/Track02 scenes.
    //also, it will lock the split-screen and track editor game modes and the track editor custom tracks.
    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            MobileControlsUI.SetActive(true);
        }
    }
}
