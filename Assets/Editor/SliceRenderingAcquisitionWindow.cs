using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace UnityVolumeRendering
{
    public class SliceRenderingAcquisitionWindow : EditorWindow
    {
        private int selectedPlaneIndex = -1;

        [MenuItem("Volume Rendering/Slice acquisition")]
        
        static void ShowWindow()
        {
            SliceRenderingAcquisitionWindow wnd = new SliceRenderingAcquisitionWindow();
            wnd.Show();
            wnd.SetInitialPosition();
            wnd.Focus();
        }

        private void SetInitialPosition()
        {
            Rect rect = this.position;
            // Debug.Log(this.position);
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

            float bgWidth = Mathf.Min(this.position.width, (this.position.height * 2.0f));
            // Rect bgRect = new Rect(0.0f, 0.0f, bgWidth, bgWidth);
            Rect bgRect = new Rect(0.0f, 0.0f, bgWidth * 0.5f, bgWidth * 0.5f);
            // Rect newRect = new Rect(0.0f, 0.0f, bgWidth* 0.5f, bgWidth * 0.5f);
            // float bgWidth = Mathf.Min(this.position.width - 20.0f, (this.position.height - 50.0f) * 2.0f);
            // Rect bgRect = new Rect(0.0f, 0.0f, bgWidth, bgWidth * 0.5f);

            if (selectedPlaneIndex != -1 && spawnedPlanes.Length > 0)
            {
                SlicingPlane planeObj = spawnedPlanes[System.Math.Min(selectedPlaneIndex, spawnedPlanes.Length - 1)];
                // Draw the slice view
                Material mat = planeObj.GetComponent<MeshRenderer>().sharedMaterial;
//                GUIUtility.RotateAroundPivot(180.0f, new Vector2(bgRect.width * 0.5f, bgRect.height * 0.5f)); // removed plane rotation
                Graphics.DrawTexture(bgRect, mat.GetTexture("_DataTex"), mat);
            }
        }

        public void OnInspectorUpdate()
        {
            Repaint();
        }
    }
}