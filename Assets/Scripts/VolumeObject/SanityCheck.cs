using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using System.Text;
using System.IO;

namespace UnityVolumeRendering
{
	public class SanityCheck : MonoBehaviour
	{		
		private List<string[]> rowData = new List<string[]>();
		private string filePath = "AcquiredData/Poses/pose_unity_real_eval.csv";
		private string imagePath = "AcquiredData";

		private int waitForMilliSeconds = 200;

		// private float y_offset_up = 21.0f;
		private float y_offset_up = 27.0f;
		private float y_offset_down = 100.0f;

		private int screenshotIndex = 2;

	    void Start()
	    {
	    	// Creating First row of titles manually
	    	string[] rowDataTemp = new string[6];
	        rowDataTemp[0] = "pos_x";
	        rowDataTemp[1] = "pos_y";
	        rowDataTemp[2] = "pos_z";
	        rowDataTemp[3] = "rot_x";
	        rowDataTemp[4] = "rot_y";
	        rowDataTemp[5] = "rot_z";
	        rowData.Add(rowDataTemp);

	        EditorApplication.ExecuteMenuItem("Volume Rendering/Slice acquisition");

	    	GetPose();
	    }


	    void GetPose()
	    {

	    	var activeWindow = EditorWindow.focusedWindow;
			var vec2Position = activeWindow.position.position;                     
            var sizeX = activeWindow.position.width;
            var sizeY = activeWindow.position.height;
            var sizeX_plane = sizeX - sizeX * 0.5f;
            var sizeY_plane = sizeY - y_offset_down;
            // var sizeX_plane = sizeX;
            // var sizeY_plane = sizeY;

	        string[] rowDataTemp = new string[6];
		    rowDataTemp[0] = transform.localPosition.x.ToString();
		    rowDataTemp[1] = transform.localPosition.y.ToString();
		    rowDataTemp[2] = transform.localPosition.z.ToString();
		    rowDataTemp[3] = transform.localEulerAngles.x.ToString();
		    rowDataTemp[4] = transform.localEulerAngles.y.ToString();
		    rowDataTemp[5] = transform.localEulerAngles.z.ToString();
		    rowData.Add(rowDataTemp);

			var colors = InternalEditorUtility.ReadScreenPixel(new Vector2(vec2Position.x, (vec2Position.y + y_offset_up)), (int)sizeX_plane, (int)sizeY_plane);
			var result = new Texture2D((int)sizeX_plane, (int)sizeY_plane, TextureFormat.RGB24, false);
			result.SetPixels(colors);
			var bytes = result.EncodeToPNG();
			DestroyImmediate(result);
			File.WriteAllBytes(Path.Combine(imagePath, "plane" + screenshotIndex + ".png"), bytes);
			screenshotIndex++;
			AssetDatabase.Refresh();

		    Debug.Log("Pose is " + rowDataTemp[0] + ", " + rowDataTemp[1] + ", " + rowDataTemp[2] + ", " + rowDataTemp[3] + ", " + rowDataTemp[4] + ", " + rowDataTemp[5]);
	        
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

	}
}
 
#endif