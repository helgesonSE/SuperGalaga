using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public FloatVariable points;
    public float score;

    public TMP_Text scoreText;

    public float Points => points.value;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore()
    {

        score += points.value;
        scoreText.text = "Score: " + score;
    }
    public void IncreasePoints(float amount)
    {
        points.value += amount;
        // UpdateScore();
    }
}
