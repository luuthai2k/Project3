using System.Collections;
using UnityEngine;
//camera change p2 is used to change the cameras of the player 2 car in split screen
public class CameraChangeP2 : MonoBehaviour
{
    //change the active camera during the race with V key, in input manager you can change the key in Viewmode input
    public GameObject NormalCam, FarCam, FPCam;//set the different cameras from inspector or add more in here
    public int CamMode;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))//if you press the camera change keyboard button
        {
            if (CamMode == 2)//once you reach the last camera
            {
                CamMode = 0;//you go back to the first one
            }
            else
            {
                CamMode += 1;//if you are not in the last camera, the next one is showed
            }
            StartCoroutine(ChangeCamera());//the camera changes because of the ChangeCamera coroutine
        }
    }

    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(0.01f);//it waits for the next frame
        //and sets the corresponding camera for each number and deactivates the other ones
        if (CamMode == 0)
        {
            NormalCam.SetActive(true);
            FPCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            FarCam.SetActive(true);
            NormalCam.SetActive(false);
        }
        if (CamMode == 2)
        {
            FPCam.SetActive(true);
            FarCam.SetActive(false);
        }
    }
}