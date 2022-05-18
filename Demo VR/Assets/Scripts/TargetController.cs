using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    public GameObject bulletImpact;
    public GameObject textToDelete;
    public GameObject youWon;
    public Text scoreField;
    public int score = 0;
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.gameObject.tag);
        Debug.Log(collision.gameObject.name);
        if (collision.collider.tag == "bullet")
        { 
            GameObject impactInstance = Instantiate(bulletImpact, collision.transform.position, bulletImpact.transform.rotation);
            score++;
            Destroy(collision.gameObject);

            if (score >= 100)
            {
                scoreField.text = "ти победи!";
                textToDelete.SetActive(false);
                youWon.SetActive(true);
            }
            else
            {
                scoreField.text = score.ToString();
            }
        }
    }
}
