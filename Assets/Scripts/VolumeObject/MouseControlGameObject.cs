using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityVolumeRendering
{ 
    [RequireComponent(typeof(MeshCollider))]
     
    public class MouseControlGameObject : MonoBehaviour 
    {
        // Move the probe using the mouse. Controls are:
        // - LEFT CLICK AND DRAG to rotate the probe in place
        // - RIGHT CLICK to place the probe in a certain position
        // - RIGHT CLICK AND DRAG to continuously translate the probe

        /// The speed of rotation of the probe when dragged by the mouse
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

        // Move the probe to the targeted position (Right-click)
        // or continuously translate the probe (Right-click + drag)
        private void MoveOnMouseClick() 
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (gameObject.GetComponent<Collider>().Raycast(ray, out hit, float.PositiveInfinity)) 
                    this.transform.position = hit.point;
            }
            if (Input.GetButton("Fire2")) 
            { 
                float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            }
        }

        // Rotate the probe based on mouse movement (Left-click + drag)
        private void RotateOnMouseMove() 
        {
            if (!dragMode && Input.GetButtonDown("Fire1")) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (this.GetComponent<Collider>().Raycast(ray, out hit, float.PositiveInfinity))
                    dragMode = true;
            }
            
            if (dragMode && Input.GetButton("Fire1")) 
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");
                float magnitude = Mathf.Abs (mouseX + mouseY) * rotationSpeed;

                Vector3 mouseVector = new Vector3(mouseY, -mouseX, 0f).normalized;
                this.transform.Rotate(mouseVector, magnitude, Space.World);
            } 
            else if (dragMode && !Input.GetButton("Fire1"))
                dragMode = false;
        }
    }
}

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