using System.Collections;
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

    [SerializeField] private GameObject spawnPoint; // The point where the enemies will spawn

    public GameObject[] waveObjects;

    public Wave[] waves;

    public int waveIndex = 0;

    private bool readyToCountDown; 
    private void Start()
    {
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++) // Set the number of enemies left in each wave to the number of enemies in the wave
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }
    private void Update()
    {

        if (readyToCountDown) // If the wave is ready to countdown, start the countdown
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0 && readyToCountDown) // If the countdown reaches 0, spawn the wave
        {
            readyToCountDown = false;

            countdown = waves[waveIndex].timeToNextWave;

            StartCoroutine(SpawnWave());
        }

        if (waves[waveIndex].enemiesLeft == 0) // If all enemies in the wave are destroyed, move to the next wave
        {
            readyToCountDown = true;

            waveIndex++;
        }
    }

    public IEnumerator SpawnWave()
    {
        if (waveIndex < waves.Length)
        {
            for (int i = 0; i < waves[waveIndex].enemies.Length; i++)
            {
                // Calculate the spawn position with an offset
                Vector3 spawnPosition = spawnPoint.transform.position + new Vector3(0, i * 1.0f, 0); // Change the multiplier to adjust the offset

                Enemy enemy = Instantiate(waves[waveIndex].enemies[i], spawnPosition, Quaternion.identity); // Spawn the enemy

                enemy.transform.parent = transform; // Set the parent of the enemy to the WaveSpawner

                Rigidbody2D rb = enemy.gameObject.AddComponent<Rigidbody2D>(); // Add a Rigidbody2D component to the enemy

                rb.gravityScale = 0; // Set the gravity scale to 0

                enemy.motionType = waves[waveIndex].motionTypes[i]; // Set the motion type of the enemy

                enemy.speed = waves[waveIndex].speeds[i]; // Set the speed of the enemy

                enemy.swirlSpeed = waves[waveIndex].swirlSpeeds[i]; // Set the swirl speed of the enemy

                enemy.swirlRadius = waves[waveIndex].swirlRadii[i]; // Set the swirl radius of the enemy

                yield return new WaitForSeconds(waves[waveIndex].timeToNextEnemy);
            }
        }
    }
}
[System.Serializable]
public class Wave // Class to store wave data
{
    public Enemy[] enemies;

    public MotionType[] motionTypes;

    public float[] speeds;

    public float[] swirlSpeeds;

    public float[] swirlRadii;

    public float timeToNextEnemy;

    public float timeToNextWave;

    [HideInInspector] public int enemiesLeft;
}



