using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapzone : MonoBehaviour
{
    //need trigger collider to work

    [SerializeField] private Transform offset;

    [Header("Settings")]
    public bool awake = true;
    public bool visibleWhenSnappedObject = false;

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
        if (other)
        {
            if (!other.GetComponent<OVRGrabbable>().isGrabbed && canSnap)
            {
                item = other.transform;
                Snap();
            }
        }
    }

    private void Snap()
    {
        if (item)
        {
            item.position = this.transform.position;
            rg = item.GetComponent<Rigidbody>();

            if (!visibleWhenSnappedObject)
                this.GetComponent<MeshRenderer>().enabled = false;

            if (rg)
                rg.isKinematic = true;

            canSnap = false;
        }
    }

    private void Update()
    {
        if (item)
        {
            if (item.GetComponent<OVRGrabbable>().isGrabbed)
            {
                canSnap = true;
                this.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
