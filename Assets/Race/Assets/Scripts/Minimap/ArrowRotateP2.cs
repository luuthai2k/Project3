using UnityEngine;

public class ArrowRotateP2 : MonoBehaviour
{
    //this script goes attached to the minimap arrow of the player 2 (and it's only used for the split-screen minimap)
    private GameObject Player2Car;
    private Transform Player2CarTransform;

    void FixedUpdate()
    {
        Player2Car = GameObject.FindGameObjectWithTag("PlayerCarP2");
        Player2CarTransform = Player2Car.GetComponent<Transform>();
        transform.rotation = Quaternion.AngleAxis(Player2CarTransform.eulerAngles.y, new Vector3(0, 1, 0));
    }
}