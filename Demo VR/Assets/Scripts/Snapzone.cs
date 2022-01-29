using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapzone : MonoBehaviour
{
    //need trigger collider to work

    [SerializeField] private Transform offset;
    [SerializeField] List<LayerMask> layersToSnap;

    private bool canSnap = false;
    private Transform item;
    private Rigidbody rg;

    [Header("Settings")]
    public bool awake = true;
    public bool visibleWhenSnappedOnject = false;

    void Start()
    {
        if (!offset)
        {
            offset = this.transform;
        }

        if (awake)
            canSnap = true;

        if (layersToSnap.Count == 0)
        {
            layersToSnap.Add(7);
            //Objects on layer 7 can be grab from the player
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<OVRGrabbable>().isGrabbed && canSnap && layersToSnap.Contains(other.gameObject.layer))
        {
            item = other.transform;
            Snap();
        }
    }

    private void Snap()
    {
        if (item)
        {
            item.position = this.transform.position;
            rg = item.GetComponent<Rigidbody>();

            if (!visibleWhenSnappedOnject)
                this.GetComponent<MeshRenderer>().enabled = false;

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
