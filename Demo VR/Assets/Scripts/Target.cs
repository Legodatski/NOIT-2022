using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject particle;
    public int timer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            particle.SetActive(true);
            Invoke("Destroy", timer);
        }
    }

    void Destroy() => particle.SetActive(false);
}
