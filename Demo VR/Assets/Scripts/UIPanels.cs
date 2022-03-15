using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UIPanels : MonoBehaviour
{
    public List<GameObject> controls = new List<GameObject>();
    int i = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            controls[i].SetActive(false);
            controls[i + 1].SetActive(true);
            i++;
        }
    }
}
