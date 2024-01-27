using UnityEngine;

public class MobileControls : MonoBehaviour
{
    public GameObject MobileControlsUI;
   
    void Start()
    {
       
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            MobileControlsUI.SetActive(true);
        }
    }
}
