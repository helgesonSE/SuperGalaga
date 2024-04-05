using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject Projectile12;
    public float fireRate = 1f; // Tid i sekunder mellan skott

    private float nextFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // Kontrollera om det är dags att skjuta igen
        if (Time.time >= nextFireTime)
        {
            // Skjut och uppdatera nästa gång att skjuta
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Skapa ett skott vid spawnerns position
        Instantiate(Projectile12, transform.position, Quaternion.identity);
    }
}
