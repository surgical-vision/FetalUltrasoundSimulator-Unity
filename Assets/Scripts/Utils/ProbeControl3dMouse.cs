using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace UnityVolumeRendering
{
    public class ProbeControl3dMouse : MonoBehaviour
    {

        PlayerControls controls;

        UnityEngine.Vector3 move;
        UnityEngine.Vector3 rotate;
        UnityEngine.Vector3 vert;

        //Initial probe position
        Vector3 finalPosition;
        //Final probe position
        Vector3 initialPosition;
        //Start and stop probe movement
        bool startSimulation = false;

        bool translationOnly = false;


        void Start ()
        {
            //Initialize plane position
            // initialPosition = new Vector3(0.0f, -0.6f, 0.0f);
            initialPosition = new Vector3(0.0f, 0.0f, 0.0f);
            transform.localPosition = initialPosition;

            //Final position to move probe
            //finalPosition = new Vector3(0.0f, -0.7f, 0.0f);
            finalPosition = new Vector3(0.0f, 0.0f, 0.0f);

            bool translationOnly = false;
            bool rotationOnly = false;

            Debug.Log("Translation and Rotation");
        }

        void Awake()    // it works as the start function
        {
            controls = new PlayerControls();

            controls.Gameplay_3dmouse.Move.performed += ctx => move = ctx.ReadValue<Vector3>();
            controls.Gameplay_3dmouse.Move.canceled += ctx => move = Vector3.zero; // reset the value when we're not moving the thumbstick
            controls.Gameplay_3dmouse.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector3>();
            controls.Gameplay_3dmouse.Rotate.canceled += ctx => rotate = Vector3.zero;
        }

        void Update()
        {
//            GetComponent<Transform>().Rotate(SpaceNavigator.Rotation.ReadValue(), Space.Self);
//            GetComponent<Transform>().Translate(SpaceNavigator.Translation(), Space.Self);
        }

        void OnEnable()
        {
            controls.Gameplay_3dmouse.Enable(); // activation of all the actions in this ActionMap
        }

        void OnDisable()
        {
            controls.Gameplay_3dmouse.Disable();
        }
    }
}
