using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapzone : MonoBehaviour
{
    //need trigger collider to work

    [SerializeField] private Transform offset;
    public bool awake = true;

    private bool canSnap = false;
    private Transform item;
    private Rigidbody rg;

    void Start()
    {
        if (!offset)
        {
            offset = this.transform;
        }

        if (awake)
            canSnap = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<OVRGrabbable>().isGrabbed && canSnap)
        {
            item = other.transform;
            rg = item.GetComponent<Rigidbody>();
            Snap();
        }
    }

    private void Snap()
    {
        if (item)
        {
            item.position = this.transform.position;

            if (rg)
                rg.isKinematic = true;

            canSnap = false;
        }
    }

    private void Update()
    {
        if (item.GetComponent<OVRGrabbable>().isGrabbed)
        {
            canSnap = true;
        }
    }
}
