// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;

// namespace UnityVolumeRendering
// {
//     public class CameraControlJoystick : MonoBehaviour
//     {
//         float inputX, inputZ;
//         PlayerControls controls_cam;
//         Vector2 cameraMove;
//         Vector2 cameraRot;

//         // Update is called once per frame
//         void Awake()
//         {
//             controls_cam = new PlayerControls();

//             controls_cam.Gameplay.CameraMove.performed += ctx => cameraMove = ctx.ReadValue<Vector2>();
//             controls_cam.Gameplay.CameraMove.canceled += ctx => cameraMove = Vector2.zero;

//             controls_cam.Gameplay.CameraRotate.performed += ctx => cameraRot = ctx.ReadValue<Vector2>();
//             controls_cam.Gameplay.CameraRotate.canceled += ctx => cameraRot = Vector2.zero;
//         }

//         void Update()
//         {
//             Vector2 m = new Vector2(cameraMove.x, cameraMove.y) * Time.deltaTime;
//             transform.Translate(m, Space.World);

//             Vector2 r = new Vector2(cameraRot.y, -cameraRot.x) * 200 * Time.deltaTime;
//             transform.Rotate(r, Space.World); 
//         }

//         void OnEnable()
//         {
//             controls_cam.Gameplay.Enable();
//         }

//         void OnDisable()
//         {
//             controls_cam.Gameplay.Disable();
//         }

//         // private void move()
//         // {
//         //     transform.position += transform.forward * inputZ * Time.deltaTime;
//         // }

//         // private void rotate()
//         // {
//         //     transform.Rotate(new Vector3(0f, inputX * Time.deltaTime, 0f));
//         // }
//     }
// }