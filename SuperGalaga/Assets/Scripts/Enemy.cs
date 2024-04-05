using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private float initialY;

    private WaveSpawner waveSpawner;

    public float movementSpeed;

    public float movementRadius;

    public MotionType motionType;

    private float time; // Used for delay so that the enemy doesn't start moving immediately

    private void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
        transform.Rotate(0, 0, 90);// Rotate the enemy to face the player
        initialY = transform.position.y;
    }

    void Update()
    {
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
        if (collision.gameObject.tag == "Boundary" && collision.gameObject.name == "Boundary")
        {
            Destroy(gameObject);
            waveSpawner.waves[waveSpawner.waveIndex].enemiesLeft--;
        }
    }
}