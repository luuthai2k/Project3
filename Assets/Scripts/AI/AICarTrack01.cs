using System.Collections;
using UnityEngine;

public class AICarTrack01 : MonoBehaviour
{
    private GameObject Point;
    private int CurrentPoint;

    private void Start()
    {
        CurrentPoint = 1;
    }

    void Update()
    {
        Point = GameObject.Find("Point" + CurrentPoint);   
        this.transform.position = Point.transform.position; 
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "AICar01")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            CurrentPoint += 1;
            if (GameObject.Find("Point" + CurrentPoint) == null)
            {
                CurrentPoint = 1;
            }
           
            yield return new WaitForSeconds(0.1f);
            this.GetComponent<BoxCollider>().enabled = true;
        }
        
    }
}