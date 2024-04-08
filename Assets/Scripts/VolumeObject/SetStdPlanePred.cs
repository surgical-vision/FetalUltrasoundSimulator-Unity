using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Text;
using System.IO;

namespace UnityVolumeRendering
{
	public class SetStdPlanePred : MonoBehaviour
	{	
		Vector3 pose_vect = new Vector3(90.0f, 0.23f, 103.6698f); // Pred

		// GT
		//Quaternion pose_quat = new Quaternion(0.576383f, 0.409613f, 0.409613f, 0.576383f); // PYTHON
		// Quaternion pose_quat = new Quaternion(-0.576383f, -0.409613f, -0.409613f, -0.576383f); // MATLAB

		// Pred
		Quaternion pose_quat = new Quaternion(0.436053f, 0.557143f, 0.554756f, 0.437831f); // PYTHON x,y,z,w
		// Quaternion pose_quat = new Quaternion(-0.436053f, -0.557143f, -0.554756f, -0.437831f); // MATLAB

		void Update()
		{
			// transform.rotation = SetQuaternion(pose_quat[0], pose_quat[1], pose_quat[2], pose_quat[3]);
			// Vector3 pose_vect = ComputeAngles(pose_quat);
			transform.localRotation = Quaternion.Euler(pose_vect);
		}

		private static Quaternion SetQuaternion(float x, float y, float z, float w)
		{
			Quaternion newQuaternion = new Quaternion();
	        newQuaternion.Set(x, y, z, w);

	        return newQuaternion;
		}

		public static Vector3 ComputeAngles(Quaternion q)
	    {

	    	float x_angle;
	    	float y_angle;
	    	float z_angle;

	    	// X Angle

	    	float sinr_cosp = 2 * (q[2] * q[0] + q[1] * q[2]);
        	float cosr_cosp = 1 - 2 * (q[0] * q[0] + q[1] * q[1]);
        	x_angle = Mathf.Atan2(sinr_cosp, cosr_cosp);

	    	// Y Angle

	        float sinp = 2 * (q[2] * q[1] - q[2] * q[0]);
	        if (Mathf.Abs(sinp) >= 1)
	            y_angle = Mathf.PI / 2 * Mathf.Sign(sinp); // use 90 degrees if out of range
	        else
	            y_angle = Mathf.Asin(sinp);

	    	// Z angle

	        float siny_cosp = 2 * (q[2] * q[2] + q[0] * q[1]);
	        float cosy_cosp = 1 - 2 * (q[1] * q[1] + q[2] * q[2]);
	        z_angle = Mathf.Atan2(siny_cosp, cosy_cosp);

	        Debug.Log(x_angle * Mathf.Rad2Deg);
	        Debug.Log(y_angle * Mathf.Rad2Deg);
	        Debug.Log(z_angle * Mathf.Rad2Deg);

	        return new Vector3(x_angle * Mathf.Rad2Deg, y_angle * Mathf.Rad2Deg, z_angle * Mathf.Rad2Deg);
	    }


	}

}