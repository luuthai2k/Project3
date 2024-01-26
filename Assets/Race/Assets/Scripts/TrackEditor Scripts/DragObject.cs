using UnityEngine;
//this script manages the mouse click behaviour
public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private Vector3 oldPosition;
    private float mZCoord;
    public static bool lIsPlay;
    //when the user clicks
    void OnMouseDown()
    {
        InstMousePos.RefreshTrackParts();//we refresh all the track parts that we placed
        oldPosition = transform.position;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;//and take the coords from the main camera
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    //when the user stops clicking
    void OnMouseUp()
    {
        //gameObject.name is passed to avoid check a game object w/itself
        if (!InstMousePos.CheckPos(gameObject.transform.position, gameObject.name))
        {
            gameObject.transform.position = oldPosition;
        }

        // If we have the delete button selected, then we delete a pit piece
        if (BtnManager.deletePit == "Yes")
        {
            Destroy(gameObject);//eliminate it
        }

        InstMousePos.RefreshTrackParts();//and refresh (works like a save)
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 posCam;
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        posCam = Camera.main.ScreenToWorldPoint(mousePoint);
        posCam.x = InstMousePos.AlignToGrid(posCam.x);
        posCam.z = InstMousePos.AlignToGrid(posCam.z);
        return posCam;
    }
    //if the player clicks and drags an object
    void OnMouseDrag()
    {
        if (!lIsPlay)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;//move the object
        }
        if (BtnManager.deletePit == "Yes")
        {
            Destroy(gameObject);//or destroy it if delete is selected
        }
        InstMousePos.RefreshTrackParts();//refresh (save) the track parts
    }
}
