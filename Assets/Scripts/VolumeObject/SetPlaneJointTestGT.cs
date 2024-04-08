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
	public class SetPlaneJointTestGT : MonoBehaviour
	{	
		List<string> rows = new List<string>();
		Vector3 pos_vect, rot_vect;
		private int waitForMilliSeconds = 100;


		// Start is called before the first frame update
		void Start()
		{
		    LoadCSV();
		}

	    public async Task MyAsyncMethod()
		{
		    await Task.Delay(waitForMilliSeconds);
		}

		public async void LoadCSV()
		{
		    //read in data file
		    StreamReader reader = new StreamReader("Assets/Tests/pose/experiments_2/case2/gt_test.csv");

		    while (!reader.EndOfStream)
		    {
		        rows.Add(reader.ReadLine());
		    }
		    
		    reader.Close();

		    for(int i = 1; i < (rows.Count)-1; i++)
		    {
		        //delimiter csv has ','
		        var column = rows[i].Split(',');
		        pos_vect = ParseVectorPos(column[0], column[1], column[2]);
		        rot_vect = ParseVectorRot(column[3], column[4], column[5]);
		        SetPose(pos_vect, rot_vect);

		        await MyAsyncMethod();
		    }
		}

		public Vector3 ParseVectorPos(string x, string y, string z)
		{
		    Vector3 vector = new Vector3();

		    vector.x = float.Parse(x);
		    vector.y = float.Parse(y);
		    vector.z = float.Parse(z);

		    return vector;
		}

		public Vector3 ParseVectorRot(string x, string y, string z)
		{
		    Vector3 vector = new Vector3();

		    vector.x = float.Parse(x);
		    vector.y = float.Parse(y);
		    vector.z = float.Parse(z);

		    // return vector * 180/Mathf.PI;

			return vector;
		}

		void SetPose(Vector3 vect_pos, Vector3 vect_rot)
	    {	    	
	    	transform.localPosition = vect_pos;
	    	transform.localRotation = Quaternion.Euler(vect_rot);
	    }
	}
}
