using System.Collections;
using System.Diagnostics;
using UnityEngine;
public enum MotionType // Global enum so that Enemy.cs and WaveSpawner can access it
{
    Straight,
    Swirl,
    ZigZag,

}


public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown; // Time between waves

    public WaveTemp[] waves;

    public int waveIndex = 0;

    private bool readyToCountDown;


    private void Start()
    {
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++) // Set the number of enemies left in each wave to the number of enemies in the wave
        {
            int totalEnemies = 0;
            foreach (var subWave in waves[i].subWaves)
            {
                totalEnemies += subWave.enemies.Length;
            }
            waves[i].enemiesLeft = totalEnemies;
        }
    }
    private void Update()
    {
        if (readyToCountDown) // If the wave is ready to countdown, start the countdown
        {
            countdown -= Time.deltaTime;
        }

        if (waveIndex < waves.Length && countdown <= 0 && readyToCountDown) // If the countdown reaches 0, spawn the wave
        {
            readyToCountDown = false;
            countdown = waves[waveIndex].timeToNextWave;
            StartCoroutine(SpawnWave());
        }

        if (waveIndex < waves.Length && waves[waveIndex].enemiesLeft == 0) // If all enemies in the wave are destroyed, move to the next wave
        {
            readyToCountDown = true;
            waveIndex++;
        }

        if (waveIndex >= waves.Length)
        {
            SceneSwitcher.EndGame(true);
        }
    }
    public IEnumerator SpawnWave()
    {
        if (waveIndex < waves.Length)
        {
            WaveTemp wave = waves[waveIndex];

            for (int i = 0; i < wave.subWaves.Length; i++)
            {
                var subWave = wave.subWaves[i];

                for (int j = 0; j < subWave.powerUps.Length && j < subWave.powerUpSpawnPoints.Length; j++)
                {
                    var powerUp = subWave.powerUps[j];
                    GameObject spawnPoint = subWave.powerUpSpawnPoints[j];

                    if (spawnPoint != null && powerUp != null && powerUp.prefab != null)
                    {
                        Vector3 spawnPosition = spawnPoint.transform.position;
                        Instantiate(powerUp.prefab, spawnPosition, Quaternion.identity);
                    }
                }

                MotionType defaultMotionType = subWave.motionTypes.Length > 0 ? subWave.motionTypes[0] : MotionType.Straight;
                float defaultSpeed = subWave.speeds.Length > 0 ? subWave.speeds[0] : 0;
                float defaultMovementSpeed = subWave.movementSpeed.Length > 0 ? subWave.movementSpeed[0] : 0;
                float defaultMovementRadius = subWave.movementRadius.Length > 0 ? subWave.movementRadius[0] : 0;

                for (int j = 0; j < subWave.enemies.Length; j++)
                {
                    Vector3 spawnPosition = subWave.spawnPoint.transform.position + new Vector3(j * subWave.enemyHorizontalSpacing, j * subWave.enemyVerticalSpacing, -4); // Calculate the spawn position with spacing

                    Enemy enemy = Instantiate(subWave.enemies[j], spawnPosition, Quaternion.identity); // Spawn the enemy

                    enemy.transform.parent = transform; // Set the parent of the enemy to the WaveSpawner

                    Rigidbody2D rb = enemy.gameObject.AddComponent<Rigidbody2D>(); // Add a Rigidbody2D component to the enemy

                    rb.gravityScale = 0; // Set the gravity scale to 0

                    // Set the motion type of the enemy
                    enemy.motionType = subWave.motionTypes.Length > j ? subWave.motionTypes[j] : defaultMotionType;

                    // Set the speed of the enemy
                    enemy.speed = subWave.speeds.Length > j ? subWave.speeds[j] : defaultSpeed;

                    // Set the movement speed of the enemy
                    enemy.movementSpeed = subWave.movementSpeed.Length > j ? subWave.movementSpeed[j] : defaultMovementSpeed;

                    // Set the movement radius of the enemy
                    enemy.movementRadius = subWave.movementRadius.Length > j ? subWave.movementRadius[j] : defaultMovementRadius;

                    yield return new WaitForSeconds(subWave.timeToNextEnemy);
                }

                for (int j = 0; j < subWave.asteroids.Length; j++) // Add this loop
                {
                    Vector3 spawnPosition = subWave.asteroidSpawnPoint.transform.position + new Vector3(j * subWave.enemyHorizontalSpacing, j * subWave.enemyVerticalSpacing, -4); // Use the asteroid spawn point

                    Asteroid asteroid = Instantiate(subWave.asteroids[j], spawnPosition, Quaternion.identity); // Spawn the asteroid

                    asteroid.transform.parent = transform; // Set the parent of the asteroid to the WaveSpawner

                    yield return new WaitForSeconds(subWave.timeToNextEnemy);
                }

                yield return new WaitForSeconds(subWave.timeToNextSubWave); // Wait for the next subwave
            }
        }
    }



}