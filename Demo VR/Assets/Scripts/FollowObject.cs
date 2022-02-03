using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform ObjectToFollow;
    public Transform FollowingObject;

    // Start is called before the first frame update
    void Start()
    {
        if (ObjectToFollow == null)
        {
            FollowingObject = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FollowingObject.position = ObjectToFollow.position;
    }
}
