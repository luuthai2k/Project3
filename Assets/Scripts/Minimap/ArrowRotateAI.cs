using UnityEngine;

public class ArrowRotateAI : MonoBehaviour
{
    
    public Transform target;
    int debug;

    void FixedUpdate()
    {
        debug++;
        transform.rotation = Quaternion.AngleAxis(target.eulerAngles.y, new Vector3(0, 1, 0));
    }
}
