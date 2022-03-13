using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public XRshooting XRshooting;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ak47")
        {
            XRshooting.Reload();
            Debug.Log("Reload");
        }
    }
}
