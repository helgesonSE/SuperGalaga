using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PowerUp/LivesPowerUp")]
public class LivesPowerUp : PowerUp
{
    public int extraLife;
    public override void Apply(GameObject player)
    {
        PlayerLives playerLives = player.GetComponent<PlayerLives>();
        if (playerLives != null && player.CompareTag("Player")) 
        {
            playerLives.FillUpLives(extraLife);

        }
        else
        {
            Debug.LogWarning("PlayerLives component not found on the GameObject: " + player.name);
        }
    }

}
