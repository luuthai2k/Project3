using UnityEngine;

public class LockGraphicsPC : MonoBehaviour
{
    public GameObject LockGraphics;
    // This script will lock the graphics resolution and quality if you are in the PC version
    // The graphics settings are used only in the mobile version, because you can change those settings in PC when launching the project
    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            LockGraphics.SetActive(true);
        }
    }
}
