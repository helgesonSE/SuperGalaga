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
    public float[] swirlSpeeds;
    [SerializeField]
    public float[] swirlRadii;
    [SerializeField]
    public float timeToNextEnemy;
    [SerializeField]
    public float timeToNextWave;

    [HideInInspector] public int enemiesLeft;

}
