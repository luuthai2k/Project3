using UnityEngine;

public class CameraRotateP2 : MonoBehaviour
{
    //this script rotates the Player 2 (in split-screen) arrow in the minimap
    private GameObject Player2Arrow;
    private Transform Player2ArrowTransform;

    void FixedUpdate()
    {
        Player2Arrow = GameObject.FindGameObjectWithTag("PlayerCarP2");//find the player 2 car
        Player2ArrowTransform = Player2Arrow.GetComponent<Transform>();//get the transform
        transform.position = new Vector3(Player2ArrowTransform.position.x, transform.position.y, Player2ArrowTransform.position.z);//translate it to the UI arrow
    }
}
