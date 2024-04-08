using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public float speed;

    [HideInInspector] private float initialY;

    private WaveSpawner waveSpawner;

    [HideInInspector] public float movementSpeed;

    [HideInInspector] public float movementRadius;

    [HideInInspector] public MotionType motionType;

    public GameObject projectilePrefab; // The projectile that this enemy shoots

    public float fireRate = 1f; // Time in seconds between shots

    private float nextFireTime = 0f;

    public bool canShoot = false; // Whether or not this enemy can shoot

    private float time; // Used for delay so that the enemy doesn't start moving immediately

    private void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
        transform.Rotate(0, 0, 90);// Rotate the enemy to face the player
        initialY = transform.position.y;
    }
    protected virtual void Shoot()
    {
        // Create a shot at the enemy's position
        Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
    }

    protected virtual void Update()
    {
        void Shoot()
        {
            // Create a shot at the enemy's position
            Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
        }
        // Check if it's time to shoot again, and if this enemy can shoot
        if (canShoot && Time.time >= nextFireTime)
        {
            // Shoot and update the next time to shoot
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        switch (motionType)// Switch between different motion types
        {
            case MotionType.Straight:

                float newY = initialY + speed * Time.deltaTime;

                float newX = transform.position.x - speed * Time.deltaTime;

                transform.position = new Vector3(newX, newY, transform.position.z);

                break;

            case MotionType.Swirl:

                time += Time.deltaTime;

                float x = Mathf.Cos(time * movementSpeed) * movementRadius;

                float y = Mathf.Sin(time * movementSpeed) * movementRadius;

                transform.Translate(new Vector3(x, y, 0) * Time.deltaTime);

                break;

            case MotionType.ZigZag:

                time += Time.deltaTime;

                float xZigZag = transform.position.x - speed * Time.deltaTime;

                float yZigZag = initialY + Mathf.Sin(time * movementSpeed) * movementRadius;

                float zZigZag = transform.position.z;

                transform.position = new Vector3(xZigZag, yZigZag, zZigZag);

                break;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary" && collision.gameObject.name == "Boundary (1)")
        {
            Destroy(gameObject);
            waveSpawner.waves[waveSpawner.waveIndex].enemiesLeft--;
            Boss boss = GetComponentInParent<Boss>();
            if (boss != null)
            {
                boss.spawnedEnemies.Remove(this);
            }
        }
    }
}
