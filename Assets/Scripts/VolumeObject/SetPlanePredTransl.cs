using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace UnityVolumeRendering
{
	public class SetPlanePredTransl : MonoBehaviour
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
		    StreamReader reader = new StreamReader("Assets/Tests/translation/1_coord/3a/predicted_test.csv");

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