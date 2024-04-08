using System;
using System.IO;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class SocketClient : MonoBehaviour
{
    private Thread clientThread;
    private TcpClient tcpClient;
    private bool isConnected = false;
    Vector3 pos_vect, rot_vect;
    private float scale = 6.0f;

    // Define a concurrent queue to store received pose values
    private ConcurrentQueue<(Vector3 position, Vector3 rotation)> poseQueue = new ConcurrentQueue<(Vector3, Vector3)>();


    // Use this for initialization
    void Start()
    {
        // Create and start a new thread for the socket connection to avoid blocking the main thread
        clientThread = new Thread(ConnectToServer);
        clientThread.IsBackground = true;
        clientThread.Start();
    }

    void ConnectToServer()
    {
        try
        {
            // Connect to the C++ server
            tcpClient = new TcpClient("127.0.0.1", 12345);
            isConnected = true;

            // Receive data from the server
            using (NetworkStream stream = tcpClient.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            {
                while (isConnected && tcpClient.Connected)
                {
                    // Read the pose values from the server
                    float posX = reader.ReadSingle();
                    float posY = reader.ReadSingle();
                    float posZ = reader.ReadSingle();
                    float rotX = reader.ReadSingle();
                    float rotY = reader.ReadSingle();
                    float rotZ = reader.ReadSingle();

                    // Process the received pose values (e.g., update a GameObject's position and rotation)

                    poseQueue.Enqueue((new Vector3(-posY * scale, posX * scale, -posZ * scale), new Vector3(rotY, -rotX, rotZ)));
                    // poseQueue.Enqueue((new Vector3(posX * scale, posY * scale, -posZ * scale), new Vector3(rotX, rotY, rotZ)));

                    
                    //Debug.Log($"Position: {posX}, {posY}, {posZ}; Rotation: {rotX}, {rotY}, {rotZ}");
                    //pos_vect = ParseVectorPos(posX, posY, posZ);
                    //rot_vect = ParseVectorRot(rotX, rotY, rotZ);
                    //SetPose(pos_vect, rot_vect);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error connecting to server: {e.Message}");
        }
    }

    void Update()
    {
        // Check if there are any pose values in the queue
        if (poseQueue.TryDequeue(out (Vector3 position, Vector3 rotation) pose))
        {
            // Update the GameObject's position and rotation with the received pose values
            transform.localPosition = pose.position;
            transform.localRotation = Quaternion.Euler(pose.rotation);
        }

    }

    public Vector3 ParseVectorPos(float x, float y, float z)
    {
        Vector3 vector = new Vector3();

        vector.x = x * 100;
        vector.y = y * 100;
        vector.z = z * 100;

        return vector;
    }

    public Vector3 ParseVectorRot(float x, float y, float z)
    {
        Vector3 vector = new Vector3();

        vector.x = x;
        vector.y = y;
        vector.z = z;

        return vector * 180 / Mathf.PI;
    }

    void SetPose(Vector3 vect_pos, Vector3 vect_rot)
    {
        transform.localPosition = vect_pos;
        transform.localRotation = Quaternion.Euler(vect_rot);
    }

    // Cleanup when the script is disabled or the application is closed
    void OnDisable()
    {
        if (tcpClient != null)
        {
            isConnected = false;
            tcpClient.Close();
            tcpClient = null;
        }

        if (clientThread != null)
        {
            clientThread.Join();
            clientThread = null;
        }
    }
}

