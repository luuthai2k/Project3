using UnityEngine;

public class CameraRotateAI : MonoBehaviour
{
    //this script rotates the AI bots cars UI arrows of the minimap
    public Transform target;

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
    }
}
