using UnityEngine;
//attaching this script to the cars in the play menu will make them rotate
public class MenuCarRotate : MonoBehaviour
{
    float RotationSpeed = 40f;	
	
	void FixedUpdate()
    {
        transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
    }
}
