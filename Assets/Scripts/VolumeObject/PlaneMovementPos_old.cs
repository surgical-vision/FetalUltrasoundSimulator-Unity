using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UnityVolumeRendering
{
	public class PlaneMovementPos_old : MonoBehaviour
	{		
		private List<string[]> rowData = new List<string[]>();
		private int screenshotIndex = 1;
		private string filePath = "AcquiredData/Poses/pos_unity.csv";
		private float initial_x = -0.04f, initial_y = -0.001f, initial_z = -0.19f; // -0.19
		private float final_x = 0.042f, final_y = 0.001f, final_z = 0.19f; // 0.19
		private float update_x = 0.009f, update_y = 0.001f, update_z = 0.003f;
		private int waitForMilliSeconds = 1000;

	    // Start is called before the first frame update
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

	        SetPose();
	    }

	    public async Task MyAsyncMethod()
		{
		    await Task.Delay(waitForMilliSeconds);
		}

	    // Update is called once per frame
	   	public async void SetPose()
	    {
	    	for(float idx_x = initial_x; idx_x < final_x; idx_x += update_x)
	    	{
	    		// for(float idx_y = initial_y; idx_y < final_y; idx_y += update_y)
	    		// {
			    	for(float idx_z = initial_z; idx_z < final_z; idx_z += update_z)
			    	{
			    		// Vector3 temppos = new Vector3(idx_x, idx_y, idx_z);
			    		Vector3 temppos = new Vector3(idx_x, 0f, idx_z);
			    		transform.position = temppos;
			    		Quaternion temprot = transform.rotation;

		    			// You can add up the values in as many cells as you want
				        string[] rowDataTemp = new string[6];
				        rowDataTemp[0] = temppos.x.ToString();
					    rowDataTemp[1] = temppos.y.ToString();
					    rowDataTemp[2] = temppos.z.ToString();
					    rowDataTemp[3] = temprot.x.ToString();
					    rowDataTemp[4] = temprot.y.ToString();
					    rowDataTemp[5] = temprot.z.ToString();
				        rowData.Add(rowDataTemp);

				        await MyAsyncMethod();
					}
				// }
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