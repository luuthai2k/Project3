using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour
{
    //this script rotates the Player 1 arrow in the minimap
    private Transform target;
    private int started;

    private void Start()
    {
        started = 0;
        StartCoroutine(RotateStart());
    }

    void FixedUpdate()
    {
        //move the ui arrow and minimap camera with the transform coords of the player car
        if (started == 1) { transform.position = new Vector3(target.position.x, transform.position.y, target.position.z); }
    }

    IEnumerator RotateStart()
    {
        yield return new WaitForSeconds(1);
        target = GameObject.FindWithTag("PlayerCar").transform;//get the player car transform
        started++;
        yield return null;
    }
}