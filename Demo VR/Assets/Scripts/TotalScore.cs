using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public List<TargetController> targetControllers = new List<TargetController>();
    private int totalPoints = 0;
    public Text points;

    // Update is called once per frame
    void Update()
    {
        if (totalPoints < 100)
            points.text = totalPoints.ToString();
        else
            points.text = "Ти победи!!!";

    }

    void GetPoints()
    {
        foreach (var item in targetControllers)
        {
            totalPoints += item.score;
        }
    }
}
