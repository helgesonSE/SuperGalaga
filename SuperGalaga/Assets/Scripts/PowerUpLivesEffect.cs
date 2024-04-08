using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLivesEffect : MonoBehaviour
{
    public PowerUp powerup;
    public float speed = 5f;
    [HideInInspector] private float initialY;
    private AudioSource audioSource;
    private CircleCollider2D circleCollider2D;
    private SpriteRenderer spriteRenderer;



    void Start()
    {
        transform.Rotate(0, 0, 90);
        initialY = transform.position.y;
        audioSource = GetComponent<AudioSource>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float newY = initialY + speed * Time.deltaTime;

        float newX = transform.position.x - speed * Time.deltaTime;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            circleCollider2D.enabled = false;
            spriteRenderer.enabled = false;
            powerup.Apply(other.gameObject);
        }
    }

}
