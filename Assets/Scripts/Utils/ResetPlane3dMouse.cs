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
    public class ResetPlane3dMouse : MonoBehaviour
    {

        PlayerControls controls;

        void Start ()
        {}

        void Awake()    // it works as the start function
        {
            controls = new PlayerControls();

            controls.Gameplay_3dmouse.ResetPlane.performed += ctx => ResetPlane();
        }


        void ResetPlane()
        {

            transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
            transform.localPosition = new Vector3(0,0,0);
//            GetComponent<Transform>().Translate(new Vector3(0,0,0), Space.Self);
//            GetComponent<Transform>().Rotate(new Vector3(0,0,0), Space.Self);
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
