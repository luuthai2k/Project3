using UnityEngine;

public class ArrowRotateAI : MonoBehaviour
{
    //this script goes attached to the minimap arrow of the AI Bots (only in the singleplayer minimap, not used in split-screen)
    public Transform target;
    int debug;

    void FixedUpdate()
    {
        debug++;
        transform.rotation = Quaternion.AngleAxis(target.eulerAngles.y, new Vector3(0, 1, 0));
    }
}
