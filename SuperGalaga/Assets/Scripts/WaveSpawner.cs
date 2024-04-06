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

    public WaveTemp[] waves;

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
    }

   public IEnumerator SpawnWave()
{
    if (waveIndex < waves.Length)
    {
            // Get the default values
            MotionType defaultMotionType = waves[waveIndex].motionTypes.Length > 0 ? waves[waveIndex].motionTypes[0] : MotionType.Straight;
            float defaultSpeed = waves[waveIndex].speeds.Length > 0 ? waves[waveIndex].speeds[0] : 0;
            float defaultMovementSpeed = waves[waveIndex].movementSpeed.Length > 0 ? waves[waveIndex].movementSpeed[0] : 0;
            float defaultMovementRadius = waves[waveIndex].movementRadius.Length > 0 ? waves[waveIndex].movementRadius[0] : 0;

            for (int i = 0; i < waves[waveIndex].enemies.Length; i++)
        {

                Vector3 spawnPosition = waves[waveIndex].spawnPoint.transform.position + new Vector3(0, i * 1.0f, -4); // Change the multiplier to adjust the offset

                Enemy enemy = Instantiate(waves[waveIndex].enemies[i], spawnPosition, Quaternion.identity); // Spawn the enemy

                enemy.transform.parent = transform; // Set the parent of the enemy to the WaveSpawner

                Rigidbody2D rb = enemy.gameObject.AddComponent<Rigidbody2D>(); // Add a Rigidbody2D component to the enemy

                rb.gravityScale = 0; // Set the gravity scale to 0

                // Set the motion type of the enemy
                enemy.motionType = waves[waveIndex].motionTypes.Length > i ? waves[waveIndex].motionTypes[i] : defaultMotionType;

                // Set the speed of the enemy
                enemy.speed = waves[waveIndex].speeds.Length > i ? waves[waveIndex].speeds[i] : defaultSpeed;

                // Set the movement speed of the enemy
                enemy.movementSpeed = waves[waveIndex].movementSpeed.Length > i ? waves[waveIndex].movementSpeed[i] : defaultMovementSpeed;

                // Set the movement radius of the enemy
                enemy.movementRadius = waves[waveIndex].movementRadius.Length > i ? waves[waveIndex].movementRadius[i] : defaultMovementRadius;


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

    public float[] movementSpeed;

    public float[] movementRadius;

    public float timeToNextEnemy;

    public float timeToNextWave;

    [HideInInspector] public int enemiesLeft;
}



