using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ComputeDistance : MonoBehaviour 
{   
    // Quaternion rot_sp = Quaternion.Euler(75.60995f, 108.8286f, 109.074f);
    // Quaternion rot_pred = Quaternion.Euler(13.3195f, 263.6981f, 303.7804f);

    // void Awake()
    // {
    //     Quaternion relative = Quaternion.Inverse(rot_sp) * rot_pred;
    //     Debug.Log(relative);
    //     // Debug.Log(string.Format("Distance between {10 and {1} is: {2}", rot_sp, rot_pred, relative));
    // }
    public Transform target;

    void Update()
    {
        float angle = Quaternion.Angle(transform.rotation, target.rotation);
        Debug.Log(angle);
    }
}