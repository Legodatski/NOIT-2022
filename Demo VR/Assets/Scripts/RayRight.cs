using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRight : MonoBehaviour
{
    public Material ray;

    public void DisableRay() => ray.color = Color.clear;
    public void EnableRay() => ray.color = Color.white;
}
