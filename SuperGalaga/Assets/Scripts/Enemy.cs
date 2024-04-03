using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private WaveSpawner waveSpawner;

    public float swirlSpeed;

    public float swirlRadius;

    public MotionType motionType;

    private float time; // Used for delay so that the enemy doesn't start moving immediately

    private void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
        transform.Rotate(0, 0, 90);// Rotate the enemy to face the player
    }

    void Update()
    {
        switch (motionType)// Switch between different motion types
        {
            case MotionType.Straight:

                transform.Translate(Vector2.up * speed * Time.deltaTime); 

                break;

            case MotionType.Swirl:
                time += Time.deltaTime;

                float x = transform.position.x - speed * Time.deltaTime;

                float y = Mathf.Sin(time * swirlSpeed) * swirlRadius; // Adjust the multiplier for different swirl patterns (Adjustable in the editor)

                float z = transform.position.z;

                transform.position = new Vector3(x, y, z);

                break;

            case MotionType.ZigZag:

                time += Time.deltaTime;

                float xZigZag = transform.position.x - speed * Time.deltaTime;

                float yZigZag = Mathf.Sin(time * swirlSpeed) * swirlRadius; // Adjust the multiplier for different zigzag patterns (Adjustable in the editor)

                float zZigZag = transform.position.z;

                transform.position = new Vector3(xZigZag, yZigZag, zZigZag);

                break;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);

            waveSpawner.waves[waveSpawner.waveIndex].enemiesLeft--;
        }
    }
}
