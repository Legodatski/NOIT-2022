using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public Transform magazineTr;
    public Transform dustCoverTr;
    public Transform gasBulletOutTr;
    public Transform recoilSpringTr;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Magazine":
                other.transform.position = magazineTr.position;
                break;
            case "DustCover":
                other.transform.position = dustCoverTr.position;
                break;
            case "GasBulletOut":
                other.transform.position = gasBulletOutTr.position;
                break;
            case "RecoilSpring":
                other.transform.position = recoilSpringTr.position;
                break;
        }
    }
}
