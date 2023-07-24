using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UnityVolumeRendering
{
	public class SavePlaneMovementRot : MonoBehaviour
	{		
		private List<string[]> rowData = new List<string[]>();
		private string filePath = "AcquiredData/Poses/rot_unity.csv";
		private string imagePath = "AcquiredData";

		// Phantom data
//		private float initial_x = 274f, initial_y = 277f, initial_z = 239f;
//		private float final_x = 294f, final_y = 297f, final_z = 259f;
//		private float update_x = 1.9f, update_y = 1.9f, update_z = 1.9f;

		 // Real data
		 private float initial_x = -10f, initial_y = -10f, initial_z = -10f;
		 private float final_x = 10f, final_y = 10f, final_z = 10f;
		 private float update_x = 1.9f, update_y = 1.9f, update_z = 1.9f;

//		private int screenshotIndex = 20699; // 23 w train
		// private int screenshotIndex = 42728; // 21 w
		// private int screenshotIndex = 64757; // 22 w
		// private int screenshotIndex = 86786; // 23 w
		// private int screenshotIndex = 108815; // 24 w
		private int screenshotIndex = 130844; // 25 w

		private int waitForMilliSeconds = 150;

		private float y_offset_up = 21.0f;
		private float y_offset_down = 100.0f;	
		private float x_offset_left = 5.0f;

		// private float y_offset_up = 27.0f;	

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

			 for(float idx_z = initial_z; idx_z < final_z; idx_z += update_z)
	    	 {
	    	 	for(float idx_x = initial_x; idx_x < final_x; idx_x += update_x)
	    	 	{
			     	for(float idx_y = initial_y; idx_y < final_y; idx_y += update_y)
			     	{
//	    	for(float idx_y = initial_y; idx_y < final_y; idx_y += update_y)
//	    	{
//	    		for(float idx_x = initial_x; idx_x < final_x; idx_x += update_x)
//	    		{
//			    	for(float idx_z = initial_z; idx_z < final_z; idx_z += update_z)
//			    	{
                        // fid + mask
//			    		Vector3 temppos = new Vector3(0.00056807f, -0.03007857f, 0.00000000568f);
//			    		Vector3 temppos = new Vector3(-0.009185502f, -0.04544367f, 0.0000000171f);
//                      Vector3 temppos = new Vector3(-0.06404233f, -0.05048668f, 0.0000000227f);
//                      Vector3 temppos = new Vector3(0.01195209f, -0.02230702f, 0.0000000142f);
//                      Vector3 temppos = new Vector3(0.006750353f, -0.009929137f, 0.00000000142f);
//                      Vector3 temppos = new Vector3(-0.04907335f, -0.03533575f, 0.0000000284f);

                        // mask
                        // Vector3 temppos = new Vector3(-0.001834f, -0.04117f, 0.00000000171f); // 21 w
//                        Vector3 temppos = new Vector3(-0.000326381f, -0.03774175f, 0.00000000568f); // 22 w
//                        Vector3 temppos = new Vector3(-0.003135422f, -0.01624128f, 0.0000000142f); // 23 w
//                        Vector3 temppos = new Vector3(0.1231229f, -0.04153748f, -0.009072967f); // 24 w
//                        Vector3 temppos = new Vector3(-0.01205512f, -0.04471118f, 0.0000000171f); // 25 w

                        // auto
//                        Vector3 temppos = new Vector3(-0.09287726f, 0.08838181f, 0.0f); // 21 w
//                        Vector3 temppos = new Vector3(-0.05471065f, -0.01720305f, 0.0000000142f); // 22 w
//                        Vector3 temppos = new Vector3(-0.06362161f, 0.03501292f, -0.00000000568f); // 23 w
//                        Vector3 temppos = new Vector3(-0.01472867f, 0.06499161f, -0.0000000114f); // 24 w
//                        Vector3 temppos = new Vector3(0.01544668f, 0.01682039f, -0.00000000284f); // 25 w

                        // dsr
                    //    Vector3 temppos = new Vector3(0.01600835f, -0.02180013f , -0.001083975f); // 21 w
                    //    Vector3 temppos = new Vector3(0.03682338f, -0.06960947f, 0.1021186f); // 22 w
                    //    Vector3 temppos = new Vector3(0.02662186f, -0.0320496f, 5.65E-09f); // 23 w
                    //    Vector3 temppos = new Vector3(0.01602831f, -0.04997408f, 0.02329378f); // 24 w
                       Vector3 temppos = new Vector3(0.01903886f, -0.06036158f, 0.02050867f); // 25 w

			    		transform.localPosition = temppos;

			    		Vector3 temprot = new Vector3(idx_x, idx_y, idx_z);
	    				transform.localRotation = Quaternion.Euler(temprot);

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
	                    File.WriteAllBytes(Path.Combine(imagePath, "plane" + screenshotIndex + ".png"), bytes);
	                    Debug.Log(screenshotIndex);
						screenshotIndex++;
	                    AssetDatabase.Refresh();

				        await MyAsyncMethod();
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
#endif
