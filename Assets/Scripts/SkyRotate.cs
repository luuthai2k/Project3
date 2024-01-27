using UnityEngine;
//this script rotates the skybox of the scenes Track01 and Track02 (a little detail)
public class SkyRotate : MonoBehaviour
{
    public float rotateSpeed = 0.5f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", rotateSpeed * Time.time);
    }
}