using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    public PowerUp powerup;
    [HideInInspector] public float speed = 1f;
    [HideInInspector] private float initialY;


    void Start()
    {
        transform.Rotate(0, 0, 90);
        initialY = transform.position.y;
    }
    void Update()
    {
        float newY = initialY + speed * Time.deltaTime;

        float newX = transform.position.x - speed * Time.deltaTime;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        powerup.Apply(other.gameObject);

    }


}
