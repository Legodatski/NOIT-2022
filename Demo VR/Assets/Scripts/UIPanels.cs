using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UIPanels : MonoBehaviour
{
    public AudioSource sound;
    public List<GameObject> controls = new List<GameObject>();
    int currentElementIndex = 0;
    int firstElementIndex = 0;
    public GameObject ammoStock;
    public GameObject ammoStockLocation;
    public int lastElementIndex
    {
        get
        {
            return controls.Count - 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            GameObject impactInstance = Instantiate(ammoStock, ammoStockLocation.transform.position, new Quaternion(0, 0, 0, 0));
        }
        try
        {
            if(currentElementIndex < lastElementIndex)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    controls[currentElementIndex].SetActive(false);
                    controls[currentElementIndex + 1].SetActive(true);
                    currentElementIndex++;
                    sound.Play();
                }
            }
            if (currentElementIndex > firstElementIndex)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    controls[currentElementIndex].SetActive(false);
                    controls[currentElementIndex - 1].SetActive(true);
                    currentElementIndex--;
                    sound.Play();
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
