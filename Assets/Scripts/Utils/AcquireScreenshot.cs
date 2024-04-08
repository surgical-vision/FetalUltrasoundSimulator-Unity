// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;


// namespace UnityVolumeRendering
// {
//     public class AcquireScreenshot : MonoBehaviour
//     {
//         private List<string[]> rowData = new List<string[]>();
// 		private string filePath = "AcquiredData/StdPlanes/Poses/stdplanes_unity.csv";
// 		private string imagePath = "AcquiredData/StdPlanes/Acquisitions";

//         private float y_offset_up = 21.0f;
// 		private float y_offset_down = 100.0f;
// 		private float x_offset_left = 5.0f;
//         private int screenshotIndex = 1;

//         private float pos_x = -0.01f, pos_y = -0.05f, pos_z = 0.0f;
// 		private float rot_x = -15f, rot_y = -10f, rot_z = 7.8f;

//         PlayerControls controls;

//         // Start is called before the first frame update
//         void Start()
//         {
//             string[] rowDataTemp = new string[7];
// 			rowDataTemp[0] = "id";
// 	        rowDataTemp[1] = "pos_x";
// 	        rowDataTemp[2] = "pos_y";
// 	        rowDataTemp[3] = "pos_z";
// 	        rowDataTemp[4] = "rot_x";
// 	        rowDataTemp[5] = "rot_y";
// 	        rowDataTemp[6] = "rot_z";
// 	        rowData.Add(rowDataTemp);     

//             EditorApplication.ExecuteMenuItem("Volume Rendering/Slice acquisition");    
//         }

//         void Awake()  
//         {
//             controls = new PlayerControls();
            
//             controls.Gameplay.TakeScreenshot.performed += ctx => TakeScreenshot();

//         }


//   	    // Update is called once per frame
// 	    void TakeScreenshot()
// 	    {
            
//             Debug.Log("Screenshot");

// 	    	var activeWindow = EditorWindow.focusedWindow;
// 			var vec2Position = activeWindow.position.position;
//             var sizeX = activeWindow.position.width;
//             var sizeY = activeWindow.position.height;
//             var sizeX_plane = sizeX - sizeX * 0.5f;
//             var sizeY_plane = sizeY - y_offset_down;

// 			Vector3 rot = new Vector3(rot_x, rot_y, rot_z);
// 			transform.localRotation = Quaternion.Euler(rot);

// 			Vector3 pos = new Vector3(pos_x, pos_y, pos_z);
// 			transform.localPosition = pos;

// 			string img_name = "plane" + (screenshotIndex+0) + ".png";

// 			var colors = InternalEditorUtility.ReadScreenPixel(new Vector2((vec2Position.x + x_offset_left), (vec2Position.y + y_offset_up)), (int)sizeX_plane, (int)sizeY_plane);
//             var result = new Texture2D((int)sizeX_plane, (int)sizeY_plane, TextureFormat.RGB24, false);
//             result.SetPixels(colors);
//             var bytes = result.EncodeToPNG();
//             DestroyImmediate(result);
//             File.WriteAllBytes(Path.Combine(imagePath, "plane" + (screenshotIndex) + ".png"), bytes);
//             Debug.Log(screenshotIndex);
//             screenshotIndex++;
//             AssetDatabase.Refresh();

				                
// 		}

//         void OnEnable()
//         {
//             controls.Gameplay.Enable(); // activation of all the actions in this ActionMap
//         }

//         void OnDisable()
//         {
//             controls.Gameplay.Disable();
//         }
//     }
// }