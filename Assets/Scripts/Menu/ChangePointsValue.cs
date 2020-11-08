using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePointsValue : MonoBehaviour
{
    Text pointsText;
    int value = 0;

    void Start()
    { 
        pointsText = GetComponent<Text>();
        pointsText.text = "0";
        Enemy.OnEnemyDie += ChangePoints;
    }
    public void ChangePoints()
    {
        value++;
        pointsText.text = value.ToString();
    }
}
