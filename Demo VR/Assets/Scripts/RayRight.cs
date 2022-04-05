using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRight : MonoBehaviour
{
    public Material ray;

    public void DisableRay() => ray.color = new Color(0.5f, 0.5f, 0.5f, 0f);
    public void EnableRay() => ray.color = Color.white;
}
