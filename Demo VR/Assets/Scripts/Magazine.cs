using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public XRshooting xr;

    public void Placed()
    {
        xr.currentAmmo = xr.maxAmmo;
    }
}
