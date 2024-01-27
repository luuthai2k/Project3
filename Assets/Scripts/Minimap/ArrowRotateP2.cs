using UnityEngine;

public class ArrowRotateP2 : MonoBehaviour
{
    private GameObject Player2Car;
    private Transform Player2CarTransform;

    void FixedUpdate()
    {
        Player2Car = GameObject.FindGameObjectWithTag("PlayerCarP2");
        Player2CarTransform = Player2Car.GetComponent<Transform>();
        transform.rotation = Quaternion.AngleAxis(Player2CarTransform.eulerAngles.y, new Vector3(0, 1, 0));
    }
}