using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityVolumeRendering
{
	// [RequireComponent(typeof(MeshCollider))]

    public class SlicingPlaneControlProbe : MonoBehaviour
    {
	    public SlicingPlane slicingPlane;
	    private GameObject sliceObj;
        public GameObject probeObj;
	    private Vector3 screenPoint;
	    private Vector3 offset;
	    private bool dragMode;
	    public float rotationSpeed = 10.0f;

        // Slicing plane initialization
        void InitSlicingPlane()
        {
            slicingPlane = GameObject.FindObjectOfType<SlicingPlane>();
            sliceObj = slicingPlane.gameObject;
            probeObj = GameObject.FindGameObjectWithTag("Probe");
            // probeObj.transform.parent = slicingPlane.transform;
            // sliceObj.transform.parent = transform;   // it is not possible to attach the slicing plane to another object (it must be child of the volume)
            screenPoint = Camera.main.WorldToScreenPoint(sliceObj.transform.position);
            offset = sliceObj.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            dragMode = false;
        }

	    void Update () 
		{
            if (slicingPlane == null)   // in case the slicing plane has not been spawned yet
                InitSlicingPlane();

            if(slicingPlane != null)
            {
                MoveOnMouseClick();
                RotateOnMouseMove();
            }
		}

		// Move the slicing plane to the targeted position (Right-click)
	    // or continuously translate the slicing plane (Right-click + drag)
        private void MoveOnMouseClick() 
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (slicingPlane.GetComponent<Collider>().Raycast(ray, out hit, float.PositiveInfinity)) 
                    slicingPlane.transform.position = hit.point;
            }
            if (Input.GetButton("Fire2")) 
            { 
                float distance_to_screen = Camera.main.WorldToScreenPoint(slicingPlane.transform.position).z;
                slicingPlane.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            }
        }

        // Rotate the slicing plane based on mouse movement (Left-click + drag)
        private void RotateOnMouseMove() 
        {
            if (Input.GetButtonDown("Fire1")) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (slicingPlane.GetComponent<Collider>().Raycast(ray, out hit, float.PositiveInfinity))
                    dragMode = true;
            }
            
            if (Input.GetButton("Fire1")) 
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");
                float magnitude = Mathf.Abs (mouseX + mouseY) * rotationSpeed;

                Vector3 mouseVector = new Vector3(mouseY, -mouseX, 0f).normalized;
                slicingPlane.transform.Rotate(mouseVector, magnitude, Space.World);
            }
        }
	}
}

