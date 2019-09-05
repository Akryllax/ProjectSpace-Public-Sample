using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AkrProtoLib;

public class NetworkManager : MonoBehaviour
{
    TcpClient tcpClient;
    Queue<string> outputStack;

    private void Awake()
    {
        Debug.Log("Starting network manager...");
        outputStack = new Queue<string>();

        tcpClient = new TcpClient();
        tcpClient.onStdout += WriteStdout;
        tcpClient.Connect("localhost", 11000);
    }

    void WriteStdout(string s)
    {
        string[] arr = s.Split('\n');
        foreach(string str in arr)
        {
            outputStack.Enqueue(str);
        }
    }

    // Update is called once per frame
    void Update()
    {
        while(outputStack.Count > 0)
        {
            string s = outputStack.Dequeue();
            Debug.Log(s);
        }
    }
}
