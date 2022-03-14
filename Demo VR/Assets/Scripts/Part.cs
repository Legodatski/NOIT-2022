using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public bool IsConnected = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ak47")
        {
            Debug.Log("Connected - " + gameObject.name);
            IsConnected = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ak47")
        {
            IsConnected = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Ak47")
        {
            Debug.Log("Disonnected - " + gameObject.name);
            IsConnected = false;
        }
    }
}
