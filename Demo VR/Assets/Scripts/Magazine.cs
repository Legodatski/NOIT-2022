using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public XRshooting XRshooting;
    private int currentAmmo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "reload")
            XRshooting.Reload();
    }


    // Update is called once per frame
    void Update()
    {
    }
}
