using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public FloatVariable points;
    static public float Score;

    public float PowerUpTime = 15f;

    public TMP_Text scoreText;

    public float Points => points.value;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + Score;
        points.value = 50f;
    }

    public void UpdateScore()
    {

        Score += points.value;
        scoreText.text = "Score: " + Score;
    }
    public void PowerUp15sec(float amount)
    {
        StartCoroutine(IncreasePoints(amount));

    }

    IEnumerator IncreasePoints(float amount)
    {
        points.value += amount;
        yield return new WaitForSeconds(PowerUpTime);
        points.value -= amount;
    }

}
