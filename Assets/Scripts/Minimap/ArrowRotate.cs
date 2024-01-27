using UnityEngine;
using System.Collections;

public class ArrowRotate : MonoBehaviour
{
    //this script goes attached to the minimap arrow of the player (in both minimaps: Singleplayer & Split-Screen)
    private Transform target;
    private int started;

    void Start()
    {
        started = 0;
        StartCoroutine(ArrowStart());       
    }

    void FixedUpdate()
    {
        if (started == 1) { transform.rotation = Quaternion.AngleAxis(target.eulerAngles.y, new Vector3(0, 1, 0)); }
    }

    IEnumerator ArrowStart()
    {
        yield return new WaitForSeconds(1);
        target = GameObject.FindWithTag("PlayerCar").transform;
        started++;
        yield return null;
    }
}