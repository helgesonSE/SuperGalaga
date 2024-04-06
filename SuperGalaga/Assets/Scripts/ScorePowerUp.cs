using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "PowerUp/ScorePowerUp")]
public class ScorePowerUp : PowerUp
{

    public float amount;
    public override void Apply(GameObject other)
    {

        PointManager pointManager = other.GetComponent<PointManager>();
        if (pointManager != null)
        {
            pointManager.IncreasePoints(amount);
        }
        else
        {
            Debug.LogWarning("PointManager component not found on the GameObject: " + other.name);
        }

    }
}
