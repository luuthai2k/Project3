using UnityEngine;

public class CameraRotateAI : MonoBehaviour
{
    
    public Transform target;

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
    }
}
