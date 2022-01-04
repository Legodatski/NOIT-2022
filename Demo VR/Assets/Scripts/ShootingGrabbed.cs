using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGrabbed : MonoBehaviour
{
    public SimpleShoot simpleShoot;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;

    // Start is called before the first frame update
    void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController()))
        {
            simpleShoot.TriggerShoot();
        }   
    }
}
