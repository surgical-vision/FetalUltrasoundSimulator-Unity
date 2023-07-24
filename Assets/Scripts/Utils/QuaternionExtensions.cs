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
//     public static class QuaternionExtensions
//     {
//         public static float ComputeXAngle(this quaternion q)
//         {
//             float sinr_cosp = 2 * (q.value.w * q[0] + q[1] * q[2]);
//             float cosr_cosp = 1 - 2 * (q[0] * q[0] + q[1] * q[1]);
//             return Math.atan2(sinr_cosp, cosr_cosp);
//         }

//         public static float ComputeYAngle(this quaternion q)
//         {
//             float sinp = 2 * (q.value.w * q[1] - q[2] * q[0]);
//             if (Math.abs(sinp) >= 1)
//                 return Math.PI / 2 * Math.sign(sinp); // use 90 degrees if out of range
//             else
//                 return Math.asin(sinp);
//         }

//         public static float ComputeZAngle(this quaternion q)
//         {
//             float siny_cosp = 2 * (q.value.w * q[2] + q[0] * q[1]);
//             float cosy_cosp = 1 - 2 * (q[1] * q[1] + q[2] * q[2]);
//             return Math.atan2(siny_cosp, cosy_cosp);
//         }

//         public static float3 ComputeAngles(this quaternion q)
//         {
//             return new float3(ComputeXAngle(q), ComputeYAngle(q), ComputeZAngle(q));
//         }

//         public static Quaternion FromAngles(float3 angles)
//         {

//             float cy = Math.cos(angles.z * 0.5f);
//             float sy = Math.sin(angles.z * 0.5f);
//             float cp = Math.cos(angles.y * 0.5f);
//             float sp = Math.sin(angles.y * 0.5f);
//             float cr = Math.cos(angles.x * 0.5f);
//             float sr = Math.sin(angles.x * 0.5f);

//             float4 q;

//             q.w = cr * cp * cy + sr * sp * sy;
//             q.x = sr * cp * cy - cr * sp * sy;
//             q.y = cr * sp * cy + sr * cp * sy;
//             q.z = cr * cp * sy - sr * sp * cy;

//             return q;

//         }
//     }
// }