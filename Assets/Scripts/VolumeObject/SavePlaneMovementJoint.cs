using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditorInternal;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Globalization;
using UnityEngine.InputSystem;

namespace UnityVolumeRendering
{
	public class SavePlaneMovementJoint: MonoBehaviour
	{		
		private List<string[]> rowData = new List<string[]>();
		private string filePath = "AcquiredData/Poses/poses_unity.csv";
		private string imagePath = "AcquiredData";
		
		// // Phantom data
		// private float initial_rot_x = 260f, initial_rot_y = 0f, initial_rot_z = -10f; 
		// // private float final_rot_x = 280.1f, final_rot_y = 180f, final_rot_z = 10.1f; 
		// private float final_rot_x = 280.1f, final_rot_y = 360f, final_rot_z = 10.1f; 
		// private float update_rot_x = 5f, update_rot_y = 7.9f, update_rot_z = 5f;
		// private float initial_pos_x = -0.01f, initial_pos_y = -0.005f, initial_pos_z = -0.3f; 
		// private float final_pos_x = 0.011f, final_pos_y = 0.0051f, final_pos_z = 0.31f; 
		// private float update_pos_x = 0.01f, update_pos_y = 0.005f, update_pos_z = 0.15f;

		// private float initial_rot_x = 250f, initial_rot_y = 0f, initial_rot_z = -10f; 
		// private float final_rot_x = 280f, final_rot_y = 180f, final_rot_z = 10; 
		// private float update_rot_x = 10f, update_rot_y = 30.0f, update_rot_z = 10f;
		// private float initial_pos_x = -0.01f, initial_pos_y = -0.005f, initial_pos_z = -0.2f; 
		// private float final_pos_x = 0.011f, final_pos_y = 0.0051f, final_pos_z = 0.26f; 
		// private float update_pos_x = 0.01f, update_pos_y = 0.005f, update_pos_z = 0.15f;

		// Real data
		private float initial_rot_x = -10f, initial_rot_z = 0f, initial_rot_y = -10f; 
		private float final_rot_x = 10.1f, final_rot_z = 180.1f, final_rot_y = 10.1f; 
		// private float final_rot_x = 10.1f, final_rot_z = 360.0f, final_rot_y = 10.1f; 
		private float update_rot_x = 5f, update_rot_z = 7.9f, update_rot_y = 5f;
		private float initial_pos_x = -0.01f, initial_pos_z = -0.005f, initial_pos_y = -0.15f; 
		private float final_pos_x = 0.011f, final_pos_z = 0.0051f, final_pos_y = 0.16f; 
		private float update_pos_x = 0.01f, update_pos_z = 0.005f, update_pos_y = 0.1f;

//		private int waitForMilliSeconds = 200;
      private int waitForMilliSeconds = 150;
//		private int waitForMilliSeconds = 20;

        private float y_offset_up = 21.0f;
		private float y_offset_down = 100.0f;

		private float x_offset_left = 5.0f;

		// private float y_offset_up = 27.0f;
		// private float y_offset_down = 100.0f;

		// Standard tests

		// private int screenshotIndex = 0; // 23 w train
		// private int screenshotIndex = 22029; // 21 w
		// private int screenshotIndex = 44058; // 22 w
		// private int screenshotIndex = 66087; // 23 w
		// private int screenshotIndex = 88116; // 24 w
		private int screenshotIndex = 110145; // 25 w

	    // Start is called before the first frame update
	    void Start()
	    {
	    	// Creating First row of titles manually
	    	string[] rowDataTemp = new string[7];
			rowDataTemp[0] = "id";
	        rowDataTemp[1] = "pos_x";
	        rowDataTemp[2] = "pos_y";
	        rowDataTemp[3] = "pos_z";
	        rowDataTemp[4] = "rot_x";
	        rowDataTemp[5] = "rot_y";
	        rowDataTemp[6] = "rot_z";
	        rowData.Add(rowDataTemp);

	        EditorApplication.ExecuteMenuItem("Volume Rendering/Slice acquisition");

			SetPose();

	    }

	    public async Task MyAsyncMethod()
		{
		    await Task.Delay(waitForMilliSeconds);
		}

	    // Update is called once per frame
	    public async void SetPose()
	    {
	    	var activeWindow = EditorWindow.focusedWindow;
			var vec2Position = activeWindow.position.position;
            var sizeX = activeWindow.position.width;
            var sizeY = activeWindow.position.height;
            var sizeX_plane = sizeX - sizeX * 0.5f;
            var sizeY_plane = sizeY - y_offset_down;
            // var sizeX_plane = sizeX;
            // var sizeY_plane = sizeY;

			// Debug.Log(vec2Position);                     
			// Debug.Log(sizeX);
			// Debug.Log(sizeY);
			// Debug.Log(sizeX_plane);
			// Debug.Log(sizeY_plane);
			await MyAsyncMethod();
			
			//  for(float idx_rot_z = initial_rot_z; idx_rot_z < final_rot_z; idx_rot_z += update_rot_z)
	    	//  {
	    	//  	for(float idx_rot_x = initial_rot_x; idx_rot_x < final_rot_x; idx_rot_x += update_rot_x)
	    	//  	{
			//      	for(float idx_rot_y = initial_rot_y; idx_rot_y < final_rot_y; idx_rot_y += update_rot_y)
			//      	{
	    	for(float idx_rot_y = initial_rot_y; idx_rot_y < final_rot_y; idx_rot_y += update_rot_y)
	    	{
	    		for(float idx_rot_x = initial_rot_x; idx_rot_x < final_rot_x; idx_rot_x += update_rot_x)
	    		{
			    	for(float idx_rot_z = initial_rot_z; idx_rot_z < final_rot_z; idx_rot_z += update_rot_z)
			    	{
			    		Vector3 temprot = new Vector3(idx_rot_x, idx_rot_y, idx_rot_z);
	    				transform.localRotation = Quaternion.Euler(temprot);

						Debug.Log(temprot);

				    	for(float idx_pos_y = initial_pos_y; idx_pos_y < final_pos_y; idx_pos_y += update_pos_y)
				    	{
				    		for(float idx_pos_x = initial_pos_x; idx_pos_x < final_pos_x; idx_pos_x += update_pos_x)
				    		{
						    	for(float idx_pos_z = initial_pos_z; idx_pos_z < final_pos_z; idx_pos_z += update_pos_z)
						    	{
				    				Vector3 temppos = new Vector3(idx_pos_x, idx_pos_y, idx_pos_z);
						    		transform.localPosition = temppos;
									
									string img_name = "plane" + (screenshotIndex+1) + ".png";

					    			// You can add up the values in as many cells as you want
							        string[] rowDataTemp = new string[7];
									rowDataTemp[0] = img_name.ToString();
							        rowDataTemp[1] = temppos.x.ToString();
								    rowDataTemp[2] = temppos.y.ToString();
								    rowDataTemp[3] = temppos.z.ToString();
								    rowDataTemp[4] = temprot.x.ToString();
								    rowDataTemp[5] = temprot.y.ToString();
								    rowDataTemp[6] = temprot.z.ToString();
							        rowData.Add(rowDataTemp);

							        var colors = InternalEditorUtility.ReadScreenPixel(new Vector2((vec2Position.x + x_offset_left), (vec2Position.y + y_offset_up)), (int)sizeX_plane, (int)sizeY_plane);
				                    var result = new Texture2D((int)sizeX_plane, (int)sizeY_plane, TextureFormat.RGB24, false);
				                    result.SetPixels(colors);
				                    var bytes = result.EncodeToPNG();
				                    DestroyImmediate(result);
				                    File.WriteAllBytes(Path.Combine(imagePath, "plane" + (screenshotIndex) + ".png"), bytes);
									Debug.Log(screenshotIndex);
									screenshotIndex++;
				                    AssetDatabase.Refresh();

							        await MyAsyncMethod();
							    }
							}
						}
					}
				}
	    	}

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