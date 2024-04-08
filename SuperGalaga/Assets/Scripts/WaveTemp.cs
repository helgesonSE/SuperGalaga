using UnityEngine;

[System.Serializable]
public class SubWave
{
    public PowerUp[] powerUps;
    public GameObject[] powerUpSpawnPoints;
    public Asteroid[] asteroids;
    public GameObject asteroidSpawnPoint;
    public Enemy[] enemies;
    public MotionType[] motionTypes;
    public float[] speeds;
    public float[] movementSpeed;
    public float[] movementRadius;
    public GameObject spawnPoint;
    public float enemyVerticalSpacing = 1.0f;
    public float enemyHorizontalSpacing = 1.0f;
    public float timeToNextSubWave;
    public float timeToNextEnemy;
    public GameObject[] spawnPoints;

}

public class WaveTemp : MonoBehaviour
{
    [SerializeField]
    public SubWave[] subWaves;
    [SerializeField]
    public float timeToNextWave;
    [HideInInspector] public int enemiesLeft;
}
