using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(MeshCollider))]
 
public class GameObjectRotateMouse : MonoBehaviour 
{
    /// Move the probe using the mouse. Controls are:
    /// - RIGHT CLICK (or alt-click) to position the probe
    /// - CLICK AND DRAG to rotate the probe in place

    /// The speed of rotation of the probe when dragged by the mouse.
    public float rotationSpeed = 20.0f;

    // "Drag mode" is turned on when the user is click-dragging to rotate the probe.
    // When not in drag mode, the user is free to use the mouse to interact with other
    // parts of the scene (e.g. GUI elements).
    private bool dragMode;

    private Vector3 screenPoint;
    private Vector3 offset;
    
    // Use this for initialization
    void Start () 
    {
        dragMode = false;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    
    // Update is called once per frame
    void Update () 
    {
        MoveOnMouseClick();
        RotateOnMouseMove();
    }

    // Move the probe to the targeted position. (Right click)
    private void MoveOnMouseClick() 
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (gameObject.GetComponent<Collider>().Raycast(ray, out hit, float.PositiveInfinity)) 
                this.transform.position = hit.point;
        }
    }

    // Rotates the probe based on mouse movement. (Left-click + drag)
    private void RotateOnMouseMove() 
    {
        if (!dragMode && Input.GetButtonDown("Fire2")) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (this.GetComponent<Collider>().Raycast(ray, out hit, float.PositiveInfinity))
                dragMode = true;
        }
        
        if (dragMode && Input.GetButton("Fire2")) 
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            float magnitude = Mathf.Abs (mouseX + mouseY) * rotationSpeed;

            Vector3 mouseVector = new Vector3(mouseY, -mouseX, 0f).normalized;
            this.transform.Rotate(mouseVector, magnitude, Space.World);
        } 
        else if (dragMode && !Input.GetButton("Fire2"))
            dragMode = false;
    }
}

/*// TRANSLATION (left button pressed)
[RequireComponent(typeof(MeshCollider))]
 
public class DragGameObject : MonoBehaviour 
{
    private Vector3 screenPoint;
    private Vector3 offset;
 
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));  
    }
}*/

/*// ROTOTRANSLATION (left button pressed)
[RequireComponent(typeof(MeshCollider))]
 
public class DragGameObject : MonoBehaviour 
{
    /// The speed of rotation of the probe when dragged by the mouse.
    public float rotationSpeed = 20.0f;

    private Vector3 screenPoint;
    private Vector3 offset;
 
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        
        if (Input.GetButton("Fire1"))
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)); 

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            float magnitude = Mathf.Abs (mouseX + mouseY) * rotationSpeed;

            Vector3 mouseVector = new Vector3(mouseY, -mouseX, 0f).normalized;
            gameObject.transform.Rotate(mouseVector, magnitude, Space.World);
        } 
    }
}*/


/*// ROTOTRANSLATION (left button pressed for translation and right button pressed for rotation)
[RequireComponent(typeof(MeshCollider))]
 
[RequireComponent(typeof(MeshCollider))]
 
public class DragGameObject : MonoBehaviour 
{
    private Vector3 screenPoint;
    private Vector3 offset;
 
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));  
    }
}*/

/*// TRANSLATION (second version with left button pressed) 
public class DragSlicingPlane : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}*/


