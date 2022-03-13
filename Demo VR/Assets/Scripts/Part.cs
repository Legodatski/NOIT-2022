using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    bool IsConnected = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ak47")
        {
            Debug.Log("Connected");
            IsConnected = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "AK47")
        {
            Debug.Log("Disonnected");
            IsConnected = false;
        }
    }

    public bool Connected() => IsConnected;
}
