using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public bool IsConnected = false;
    bool CorrectPlace = false;

    public void SetCorrectPlaceTrue() => CorrectPlace = true;
    public void SetCorrectPlaceFalse() => CorrectPlace = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ak47" && CorrectPlace)
        {
            Debug.Log("Connected - " + gameObject.name);
            IsConnected = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ak47" && CorrectPlace)
        {
            IsConnected = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    { 
        if (collision.gameObject.tag == "Ak47" && CorrectPlace)
        {
            Debug.Log("Disonnected - " + gameObject.name);
            //IsConnected = false;
        }
    }
}
