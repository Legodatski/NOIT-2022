using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsAssembly : MonoBehaviour
{
    public List<Part> parts;
    public List<GameObject> partHolders;

    private void Start()
    {
        foreach (var holder in partHolders)
            holder.SetActive(false);

        partHolders[0].SetActive(true);
    }


    private void FixedUpdate()
    {
        partHolders[1].SetActive(parts[0].IsConnected);
        partHolders[2].SetActive(parts[1].IsConnected);
        partHolders[3].SetActive(parts[2].IsConnected);
    }
}
