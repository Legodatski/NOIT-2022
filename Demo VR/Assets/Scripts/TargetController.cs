using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    public GameObject bulletImpact;
    public Text scoreField;
    private int score = 0;
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.gameObject.tag);
        Debug.Log(collision.gameObject.name);
        if (collision.collider.tag == "bullet")
        { 
            GameObject impactInstance = Instantiate(bulletImpact, collision.transform.position, new Quaternion(0, 0, 0, 0));
            score++;
            Destroy(collision.gameObject);

            scoreField.text = score.ToString();
        }
    }
}
