using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapzone : MonoBehaviour
{
    [SerializeField] private Transform offset;
    public bool awake = true;

    private bool canSnap = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!offset)
        {
            offset = this.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<OVRGrabbable>().isGrabbed == false)
        {
            canSnap = true;
            other.transform.SetParent(null);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (awake && canSnap)
        {
            other.transform.position = offset.position;
            other.transform.rotation = offset.rotation;
        }

    }
}
