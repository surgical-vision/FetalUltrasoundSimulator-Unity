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
	public class SetPlaneGTTransl : MonoBehaviour
	{	
		List<string> rows = new List<string>();
		Vector3 pose;
		private int waitForMilliSeconds = 50;

		// Start is called before the first frame update
		void Start()
		{	
			Vector3 rot = new Vector3(90.0f, 0.0f, 0.0f);
			transform.localRotation = Quaternion.Euler(rot);
		    LoadCSV();
		}

	    public async Task MyAsyncMethod()
		{
		    await Task.Delay(waitForMilliSeconds);
		}

		public async void LoadCSV()
		{
		    //read in data file
		    StreamReader reader = new StreamReader("Assets/Tests/translation/1_coord/3a/gt_test.csv");

		    while (!reader.EndOfStream)
		    {
		        rows.Add(reader.ReadLine());
		    }
		    reader.Close();

		    for(int i = 1; i < (rows.Count)-1; i++)
		    {
		        //delimiter csv has ','
		        var column = rows[i].Split(',');
		        pose = ParseVector3(column[0], column[1], column[2]);
		        SetPose(pose);

		        await MyAsyncMethod();
		    }
		}


		public Vector3 ParseVector3(string x, string y, string z)
		{
		    Vector3 vector = new Vector3();

		    vector.x = float.Parse(x);
		    vector.y = float.Parse(y);
		    vector.z = float.Parse(z);

		    return vector;
		}

		void SetPose(Vector3 pose)
	    {	    	
	    	transform.localPosition = pose;
	    }
 	}
}

// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.SceneManagement;
// using UnityEditor;
// using UnityEditorInternal;
// using System.Text;
// using System.IO;

// namespace UnityVolumeRendering
// {
// 	public class PoseGT_transl : MonoBehaviour
// 	{	
// 		List<string> rows = new List<string>();
// 		Vector3 pose;
// 		private float waitForSeconds = 0.005f;

// 		// Start is called before the first frame update
// 		void Start()
// 		{	
// 			Vector3 rot = new Vector3(90.0f, 0.0f, 0.0f);
// 			transform.rotation = Quaternion.Euler(rot);
// 		    LoadCSV();
// 		}

// 		void Update()
// 		{
// 			// StartCoroutine(Wait());
// 		}

//         IEnumerator Wait()
// 	    {
// 	    	//we start on line 0 because there is no header
// 		    for(int i = 0; i < rows.Count; i++)
// 		    {
// 		        //delimiter csv has ','
// 		        var column = rows[i].Split(',');
// 		        pose = ParseVector3(column[0], column[1], column[2]);
// 		        SetPose(pose);
// 		        Debug.Log(pose);
// 	       		yield return new WaitForSeconds(waitForSeconds);
// 			}
// 	    }

// 		public void LoadCSV()
// 		{
// 		    //read in data file
// 		    StreamReader reader = new StreamReader("Assets/Tests/translation/phantom/1b/gt_train.csv");

// 		    while (!reader.EndOfStream)
// 		    {
// 		        rows.Add(reader.ReadLine());
// 		    }
// 		    reader.Close();

// 		    StartCoroutine(Wait());
// 		}

		// public Vector3 ParseVector3(string x, string y, string z)
		// {
		//     Vector3 vector = new Vector3();

		//     vector.x = float.Parse(x);
		//     vector.y = float.Parse(y);
		//     vector.z = float.Parse(z);

		//     return vector;
		// }

		// void SetPose(Vector3 pose)
	 //    {	    	
	 //    	transform.position = pose;
	 //    }
//  	}
// }

