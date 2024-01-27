using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour
{
    
    private Transform target;
    private int started;

    private void Start()
    {
        started = 0;
        StartCoroutine(RotateStart());
    }

    void FixedUpdate()
    {
        
        if (started == 1) { transform.position = new Vector3(target.position.x, transform.position.y, target.position.z); }
    }

    IEnumerator RotateStart()
    {
        yield return new WaitForSeconds(1);
        target = GameObject.FindWithTag("PlayerCar").transform;
        started++;
        yield return null;
    }
}