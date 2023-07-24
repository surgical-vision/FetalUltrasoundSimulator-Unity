using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UnityVolumeRendering
{
    public class ProbeControlJoystick : MonoBehaviour
    {

        PlayerControls controls;

        UnityEngine.Vector2 move;
        UnityEngine.Vector2 rotate;
        UnityEngine.Vector2 vert;

        Vector3 pos;
        Vector3 rot;

        //Initial probe position
        Vector3 finalPosition;
        //Final probe position
        Vector3 initialPosition;
        //Start and stop probe movement
        bool startSimulation = false;


        void Start ()
        {
            //Initialize probe position
            // initialPosition = new Vector3(0.0f, -0.6f, 0.0f);
            initialPosition = new Vector3(0.0f, 0.0f, 0.0f);
            transform.localPosition = initialPosition;

            //Final position to move probe
            //finalPosition = new Vector3(0.0f, -0.7f, 0.0f);
            finalPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }

        void Awake()    // it works as the start function
        {
            controls = new PlayerControls();

            // controls.ActionMap.Action.x (x = start, performed, cancelled)
            // Each action in the input system has different phases that we can use to trigger input
            controls.Gameplay_joystick.ResetPlane.performed += ctx => ResetPlane(); // use of lambda expression to tell Unity that we are aware that there's some context for this action but we don't really want to use it, but just perform the action

            controls.Gameplay_joystick.Move.performed += ctx => move = ctx.ReadValue<Vector2>(); // here the context is useful because we don't only want to know that our thumbstick was moved but also in what direction and how far; we can store this in a Vector2. In this way, Move will be equal to the value of the thumbstick
            controls.Gameplay_joystick.Move.canceled += ctx => move = Vector2.zero; // resent the value when we're not moving the thumbstick

            controls.Gameplay_joystick.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
            controls.Gameplay_joystick.Rotate.canceled += ctx => rotate = Vector2.zero;

            controls.Gameplay_joystick.VertMov.performed += ctx => vert = ctx.ReadValue<Vector2>();
            controls.Gameplay_joystick.VertMov.canceled += ctx => vert = Vector2.zero;

            controls.Gameplay_joystick.SlideProbe.performed += ctx => Slide();
        }

        void ResetPlane()
        {
            // transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
            transform.localPosition = new Vector3(0,0,0);
        }

        void Update()
        {
            Vector3 m = new Vector3(-move.x, 0, -move.y) * Time.deltaTime;
            // transform.Translate(m, Space.World);
            GetComponent<Transform>().Translate(m, Space.World);

            // Vector2 r = new Vector2(rotate.y, -rotate.x) * 50 * Time.deltaTime;
            Vector2 r = new Vector2(-rotate.y, -rotate.x) * 25 * Time.deltaTime;
            GetComponent<Transform>().Rotate(r, Space.World);

            Vector3 v = new Vector3(0, vert.y, 0) * Time.deltaTime;
            GetComponent<Transform>().Translate(v, Space.World);
            // GetComponent<Rigidbody>().velocity = v;
        }

        void Slide()
        {
            transform.localPosition = Vector3.MoveTowards(transform.position, finalPosition, 0.005f);
        }

        void OnEnable()
        {
            controls.Gameplay_joystick.Enable(); // activation of all the actions in this ActionMap
        }

        void OnDisable()
        {
            controls.Gameplay_joystick.Disable();
        }
    }
}
