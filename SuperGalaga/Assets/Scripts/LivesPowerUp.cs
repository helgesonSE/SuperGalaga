using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PowerUp/LivesPowerUp")]
public class LivesPowerUp : PowerUp
{
    public int extraLife;
    public override void Apply(GameObject other)
    {
        PlayerLives playerLives = other.GetComponent<PlayerLives>();
        if (playerLives != null)
        {
            playerLives.FillUpLives();

        }
        else
        {
            Debug.LogWarning("PlayerLives component not found on the GameObject: " + other.name);
        }
    }

}
