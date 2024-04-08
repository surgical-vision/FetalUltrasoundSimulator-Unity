using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Text;
using System.IO;

namespace UnityVolumeRendering
{
	public class SetStdPlaneGT : MonoBehaviour
	{	
		// Vector3 pose_vect = new Vector3(90.0f, 70.8f, 0.0f); // GT
		Vector3 pose_vect = new Vector3(90.0f, 103.5f, 0.0f); // Pred

		// Start is called before the first frame update
		void Start()
		{
			transform.localRotation = Quaternion.Euler(pose_vect);
		}
 	}
}
