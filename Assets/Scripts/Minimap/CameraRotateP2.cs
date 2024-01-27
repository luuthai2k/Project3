using UnityEngine;

public class CameraRotateP2 : MonoBehaviour
{
   
    private GameObject Player2Arrow;
    private Transform Player2ArrowTransform;

    void FixedUpdate()
    {
        Player2Arrow = GameObject.FindGameObjectWithTag("PlayerCarP2");
        Player2ArrowTransform = Player2Arrow.GetComponent<Transform>();
        transform.position = new Vector3(Player2ArrowTransform.position.x, transform.position.y, Player2ArrowTransform.position.z);
    }
}
