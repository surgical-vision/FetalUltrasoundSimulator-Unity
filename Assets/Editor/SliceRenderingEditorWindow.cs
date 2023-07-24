using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;
using UnityEditorInternal;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UnityVolumeRendering
{
    public class SliceRenderingEditorWindow : EditorWindow
    {

        private List<string[]> rowData = new List<string[]>();
		private string filePath = "AcquiredData/StdPlanes/Poses/stdplanes_unity.csv";
		private string imagePath = "AcquiredData/StdPlanes/Acquisitions";
        private int screenshotIndex = 1;
        // private float y_offset_up = 21.0f;
		// private float y_offset_down = 100.0f;
		// private float x_offset_left = 5.0f;
        // private float y_offset_up = 21.0f;
        private float y_offset_up = 21.0f;
		private float y_offset_down = 3.0f;
		private float x_offset_left = 0.0f;
        
        private int selectedPlaneIndex = -1;
        private bool handleMouseMovement = false;
        private Vector2 prevMousePos;

        void Start()
        {
            string[] rowDataTemp = new string[7];
			rowDataTemp[0] = "id";
	        rowDataTemp[1] = "pos_x";
	        rowDataTemp[2] = "pos_y";
	        rowDataTemp[3] = "pos_z";
	        rowDataTemp[4] = "rot_x";
	        rowDataTemp[5] = "rot_y";
	        rowDataTemp[6] = "rot_z";
	        rowData.Add(rowDataTemp);
        }

        public static void ShowWindow()
        {
            SliceRenderingEditorWindow wnd = new SliceRenderingEditorWindow();
            wnd.Show();
            wnd.SetInitialPosition();
        }

        private void SetInitialPosition()
        {
            Rect rect = this.position;
            rect.width = 800.0f;
            rect.height = 500.0f;
            this.position = rect;
        }

        private void OnFocus()
        {
            // set selected plane as active GameObject in Hierarchy
            SlicingPlane[] spawnedPlanes = FindObjectsOfType<SlicingPlane>();
            if (selectedPlaneIndex != -1 && spawnedPlanes.Length > 0)
            {
                Selection.activeGameObject = spawnedPlanes[selectedPlaneIndex].gameObject;
            }
        }

        private void OnGUI()
        {
            SlicingPlane[] spawnedPlanes = FindObjectsOfType<SlicingPlane>();

            if (spawnedPlanes.Length > 0)
                selectedPlaneIndex = selectedPlaneIndex % spawnedPlanes.Length;

            // float bgWidth = Mathf.Min(this.position.width - 20.0f, (this.position.height - 50.0f) * 2.0f);
            float bgWidth = Mathf.Min(this.position.width, (this.position.height - 50.0f) * 2.0f);
            Rect bgRect = new Rect(0.0f, 0.0f, bgWidth, bgWidth * 0.5f);
            if (selectedPlaneIndex != -1 && spawnedPlanes.Length > 0)
            {
                SlicingPlane planeObj = spawnedPlanes[System.Math.Min(selectedPlaneIndex, spawnedPlanes.Length - 1)];
                // Draw the slice view
                Material mat = planeObj.GetComponent<MeshRenderer>().sharedMaterial;
                Graphics.DrawTexture(bgRect, mat.GetTexture("_DataTex"), mat);

                    
                // Handle mouse click inside slice view (activates moving the plane with mouse)
                if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && bgRect.Contains(new Vector2(Event.current.mousePosition.x, Event.current.mousePosition.y)))
                {
                    handleMouseMovement = true;
                    prevMousePos = Event.current.mousePosition;
                }

                // Handle mouse movement (move the plane)
                if (handleMouseMovement)
                {
                    Vector2 mouseOffset = (Event.current.mousePosition - prevMousePos) / new Vector2(bgRect.width, bgRect.height);
                    if (Mathf.Abs(mouseOffset.y) > 0.00001f)
                    {
                        planeObj.transform.Translate(Vector3.up * mouseOffset.y);
                        prevMousePos = Event.current.mousePosition;
                    }
                }
            }

            if (Event.current.type == EventType.MouseUp)
                handleMouseMovement = false;

            // Show buttons for changing the active plane
            if (spawnedPlanes.Length > 0)
            {
                // SlicingPlane planeObj = spawnedPlanes[System.Math.Min(selectedPlaneIndex, spawnedPlanes.Length - 1)];

                if (GUI.Button(new Rect(0.0f, bgRect.y + bgRect.height + 20.0f, 70.0f, 30.0f), "previous\nplane"))
                {
                    selectedPlaneIndex = (selectedPlaneIndex - 1) % spawnedPlanes.Length;
                    Selection.activeGameObject = spawnedPlanes[selectedPlaneIndex].gameObject;
                }
                if (GUI.Button(new Rect(90.0f, bgRect.y + bgRect.height + 20.0f, 70.0f, 30.0f), "next\nplane"))
                {
                    selectedPlaneIndex = (selectedPlaneIndex + 1) % spawnedPlanes.Length;
                    Selection.activeGameObject = spawnedPlanes[selectedPlaneIndex].gameObject;
                }
            }

            // Show button for adding new plane
            if (GUI.Button(new Rect(180.0f, bgRect.y + bgRect.height + 20.0f, 70.0f, 30.0f), "add\nplane"))
            {
                VolumeRenderedObject volRend = FindObjectOfType<VolumeRenderedObject>();
                if (volRend != null)
                {
                    selectedPlaneIndex = spawnedPlanes.Length;
                    volRend.CreateSlicingPlane();
                }
            }

            // Show button for removing
            if (spawnedPlanes.Length > 0 && GUI.Button(new Rect(270.0f, bgRect.y + bgRect.height + 20.0f, 70.0f, 30.0f), "remove\nplane"))
            {
                SlicingPlane planeToRemove = spawnedPlanes[selectedPlaneIndex];
                GameObject.DestroyImmediate(planeToRemove.gameObject);
            }

            // Show button for saving the plane
            if (GUI.Button(new Rect(360.0f, bgRect.y + bgRect.height + 20.0f, 70.0f, 30.0f), "save\nplane"))
            {
                Vector3 pos = Selection.activeGameObject.transform.localPosition;
                Vector3 rot = Selection.activeGameObject.transform.localEulerAngles;

                string img_name = "plane" + (screenshotIndex) + ".png";

                // Get screen position and sizes
                var vec2Position = EditorWindow.focusedWindow.position.position;
                var sizeX = bgRect.width;
                var sizeY = bgRect.height;
                // var sizeX = activeWindow.position.width;
                // var sizeY = activeWindow.position.height;
                var sizeX_plane = sizeX;
                var sizeY_plane = sizeY - y_offset_down;

                // Take Screenshot at given position sizes
                var colors = InternalEditorUtility.ReadScreenPixel(new Vector2((vec2Position.x + x_offset_left), (vec2Position.y + y_offset_up)), (int)sizeX_plane, (int)sizeY_plane);
				
                // write result Color[] data into a temporal Texture2D
                var result = new Texture2D((int)sizeX_plane, (int)sizeY_plane, TextureFormat.RGB24, false);
                result.SetPixels(colors);

                // encode the Texture2D to a PNG
                // you might want to change this to JPG for way less file size but slightly worse quality
                // if you do don't forget to also change the file extension below
                var bytes = result.EncodeToPNG();
                // In order to avoid bloading Texture2D into memory destroy it
                DestroyImmediate(result);
                // finally write the file e.g. to the StreamingAssets folder
                System.IO.File.WriteAllBytes(Path.Combine(imagePath, img_name), bytes);
                screenshotIndex++;
                // Refresh the AssetsDatabase so the file actually appears in Unity
                AssetDatabase.Refresh();
                Debug.Log("New Screenshot taken");

                string[] rowDataTemp = new string[7];
                rowDataTemp[0] = img_name.ToString();
                rowDataTemp[1] = pos.x.ToString();
                rowDataTemp[2] = pos.y.ToString();
                rowDataTemp[3] = pos.z.ToString();
                rowDataTemp[4] = rot.x.ToString();
                rowDataTemp[5] = rot.y.ToString();
                rowDataTemp[6] = rot.z.ToString();
                rowData.Add(rowDataTemp);

                string[][] output = new string[rowData.Count][];

                for(int i = 0; i < output.Length; i++)
                {
                    output[i] = rowData[i];
                }

                int length = output.GetLength(0);
                string delimiter = ",";
                StringBuilder sb = new StringBuilder();
            
                for (int index = 0; index < length; index++)
                {
                    sb.AppendLine(string.Join(delimiter, output[index]));
                }

                StreamWriter outStream = System.IO.File.CreateText(filePath);
                outStream.WriteLine(sb);
                outStream.Close();
            }

            // Show hint
            if (spawnedPlanes.Length > 0)
                GUI.Label(new Rect(0.0f, bgRect.y + bgRect.height + 60.0f, 450.0f, 30.0f), "Move plane by left clicking in the above view and dragging the mouse,\n or simply move it in the object hierarchy.");
        }

        public void OnInspectorUpdate()
        {
            Repaint();
        }
    
    }
}

// using UnityEngine;
// using UnityEditor;

// namespace UnityVolumeRendering
// {
//     public class SliceRenderingEditorWindow : EditorWindow
//     {
//         private int selectedPlaneIndex = -1;
//         private bool handleMouseMovement = false;
//         private Vector2 prevMousePos;

//         public static void ShowWindow()
//         {
//             SliceRenderingEditorWindow wnd = new SliceRenderingEditorWindow();
//             wnd.Show();
//             wnd.SetInitialPosition();
//         }

//         private void SetInitialPosition()
//         {
//             Rect rect = this.position;
//             rect.width = 800.0f;
//             rect.height = 500.0f;
//             this.position = rect;
//         }

//         private void OnFocus()
//         {
//             // set selected plane as active GameObject in Hierarchy
//             SlicingPlane[] spawnedPlanes = FindObjectsOfType<SlicingPlane>();
//             if (selectedPlaneIndex != -1 && spawnedPlanes.Length > 0)
//             {
//                 Selection.activeGameObject = spawnedPlanes[selectedPlaneIndex].gameObject;
//             }
//         }

//         private void OnGUI()
//         {
//             SlicingPlane[] spawnedPlanes = FindObjectsOfType<SlicingPlane>();

//             if (spawnedPlanes.Length > 0)
//                 selectedPlaneIndex = selectedPlaneIndex % spawnedPlanes.Length;

//             float bgWidth = Mathf.Min(this.position.width - 20.0f, (this.position.height - 50.0f) * 2.0f);
//             Rect bgRect = new Rect(0.0f, 0.0f, bgWidth, bgWidth * 0.5f);
//             if (selectedPlaneIndex != -1 && spawnedPlanes.Length > 0)
//             {
//                 SlicingPlane planeObj = spawnedPlanes[System.Math.Min(selectedPlaneIndex, spawnedPlanes.Length - 1)];
//                 // Draw the slice view
//                 Material mat = planeObj.GetComponent<MeshRenderer>().sharedMaterial;
//                 Graphics.DrawTexture(bgRect, mat.GetTexture("_DataTex"), mat);



//                 // Handle mouse click inside slice view (activates moving the plane with mouse)
//                 if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && bgRect.Contains(new Vector2(Event.current.mousePosition.x, Event.current.mousePosition.y)))
//                 {
//                     handleMouseMovement = true;
//                     prevMousePos = Event.current.mousePosition;
//                 }

//                 // Handle mouse movement (move the plane)
//                 if (handleMouseMovement)
//                 {
//                     Vector2 mouseOffset = (Event.current.mousePosition - prevMousePos) / new Vector2(bgRect.width, bgRect.height);
//                     if (Mathf.Abs(mouseOffset.y) > 0.00001f)
//                     {
//                         planeObj.transform.Translate(Vector3.up * mouseOffset.y);
//                         prevMousePos = Event.current.mousePosition;
//                     }
//                 }
//             }

//             if (Event.current.type == EventType.MouseUp)
//                 handleMouseMovement = false;

//             // Show buttons for changing the active plane
//             if (spawnedPlanes.Length > 0)
//             {
//                 if (GUI.Button(new Rect(0.0f, bgRect.y + bgRect.height + 20.0f, 70.0f, 30.0f), "previous\nplane"))
//                 {
//                     selectedPlaneIndex = (selectedPlaneIndex - 1) % spawnedPlanes.Length;
//                     Selection.activeGameObject = spawnedPlanes[selectedPlaneIndex].gameObject;
//                 }
//                 if (GUI.Button(new Rect(90.0f, bgRect.y + bgRect.height + 20.0f, 70.0f, 30.0f), "next\nplane"))
//                 {
//                     selectedPlaneIndex = (selectedPlaneIndex + 1) % spawnedPlanes.Length;
//                     Selection.activeGameObject = spawnedPlanes[selectedPlaneIndex].gameObject;
//                 }
//             }

//             // Show button for adding new plane
//             if (GUI.Button(new Rect(180.0f, bgRect.y + bgRect.height + 20.0f, 70.0f, 30.0f), "add\nplane"))
//             {
//                 VolumeRenderedObject volRend = FindObjectOfType<VolumeRenderedObject>();
//                 if (volRend != null)
//                 {
//                     selectedPlaneIndex = spawnedPlanes.Length;
//                     volRend.CreateSlicingPlane();
//                 }
//             }

//             // Show button for removing
//             if (spawnedPlanes.Length > 0 && GUI.Button(new Rect(270.0f, bgRect.y + bgRect.height + 20.0f, 70.0f, 30.0f), "remove\nplane"))
//             {
//                 SlicingPlane planeToRemove = spawnedPlanes[selectedPlaneIndex];
//                 GameObject.DestroyImmediate(planeToRemove.gameObject);
//             }

//             // Show hint
//             if (spawnedPlanes.Length > 0)
//                 GUI.Label(new Rect(0.0f, bgRect.y + bgRect.height + 60.0f, 450.0f, 30.0f), "Move plane by left clicking in the above view and dragging the mouse,\n or simply move it in the object hierarchy.");
//         }

//         public void OnInspectorUpdate()
//         {
//             Repaint();
//         }
//     }
// }