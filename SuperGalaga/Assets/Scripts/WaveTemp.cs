using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTemp : MonoBehaviour
{
    [SerializeField]
    public Enemy[] enemies;
    [SerializeField]
    public MotionType[] motionTypes;
    [SerializeField]
    public float[] speeds;
    [SerializeField]
    public float[] movementSpeed;
    [SerializeField]
    public float[] movementRadius;
    [SerializeField]
    public float timeToNextEnemy;
    [SerializeField]
    public float timeToNextWave;
    [SerializeField] 
    public GameObject spawnPoint;

    [HideInInspector] public int enemiesLeft;

}
