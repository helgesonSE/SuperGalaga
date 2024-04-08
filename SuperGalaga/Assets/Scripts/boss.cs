using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss : Enemy
{
    public int hp; // Health points of the boss
    public GameObject specialProjectilePrefab; // The special projectile that the boss shoots
    private Coroutine specialShootCoroutine;
    public Enemy[] enemiesToSpawn; // Enemies that the boss can spawn
    public List<Enemy> spawnedEnemies = new List<Enemy>();
    public Vector2[] spawnPositions = new Vector2[]
{
    new Vector2(5.26f, -3.94f),
    new Vector2(9f, 3.94f),
    new Vector2(5.22f, -2.26f),
    new Vector2(9f, -2.26f),
    new Vector2(5.22f, 0.22f),
    new Vector2(9f, 0.22f),
    new Vector2(5.19f, 4.46f),
    new Vector2(9f, 4.46f),
};



    // Method to reduce the boss's HP
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            SceneSwitcher.EndGame(true);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        transform.Rotate(0, 0, 90);// Rotate the enemy to face the player
        specialShootCoroutine = StartCoroutine(SpecialShoot());
    }

    private IEnumerator SpecialShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(6); // Wait for 10 seconds

            GameObject chargeUpProjectile = Instantiate(specialProjectilePrefab, transform.position + new Vector3(-2, 0, 0), Quaternion.identity);
            chargeUpProjectile.transform.parent = transform; // Link the "charge up" projectile to the boss
            chargeUpProjectile.transform.localScale = new Vector3(1f, 1, 1); // Shrink the "charge up" projectile on the X-axis

            yield return new WaitForSeconds(2); // Wait for 1 second

            Destroy(chargeUpProjectile); // Destroy the "charge up" projectile

            GameObject specialProjectile = Instantiate(specialProjectilePrefab, transform.position + new Vector3(-6, 0, 0), Quaternion.identity);
            specialProjectile.transform.parent = transform; // Link the special projectile to the boss

            yield return new WaitForSeconds(4); // Wait for 3 seconds

            Destroy(specialProjectile); // Destroy the special projectile
        }
    }



    // Override the Shoot method to shoot at the player
    protected override void Shoot()
    {
        // Create a shot at the boss's position
        Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
    }

    private bool isSpawning = false;

    public IEnumerator SpawnEnemies()
    {
        isSpawning = true;

        if (hp > 0 && spawnPositions.Length > 0) // Check if spawnPositions is not empty
        {
            foreach (Enemy enemy in enemiesToSpawn)
            {
                int randomIndex = Random.Range(0, spawnPositions.Length); // Get a random index
                Vector2 spawnPosition = spawnPositions[randomIndex]; // Use the random index to select a spawn position
                Enemy spawnedEnemy = Instantiate(enemy, new Vector3(spawnPosition.x, spawnPosition.y, -4), Quaternion.identity);
                spawnedEnemies.Add(spawnedEnemy);
                //Rigidbody2D rb = enemy.gameObject.AddComponent<Rigidbody2D>(); // Add a Rigidbody2D component to the enemy
                spawnedEnemy.motionType = MotionType.Straight; // Set the motion type to Straight
                spawnedEnemy.speed = 2f; // Set the speed of the enemy
                yield return new WaitForSeconds(3); // Wait for 3 seconds
            }
        }

        isSpawning = false;
    }

    protected override void Update()
    {
        base.Update(); // Call the base class's Update method

        if (!isSpawning)
        {
            StartCoroutine(SpawnEnemies()); // Start the SpawnEnemies coroutine
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TakeDamage(1); // Reduce the boss's HP by 1
            Destroy(collision.gameObject); // Destroy the projectile
        }
    }
}