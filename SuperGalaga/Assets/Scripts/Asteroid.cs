using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Transform asteroidSprite;

    float rotationSpeed;
    float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(6f, 15f);
        scrollSpeed = Random.Range(7f, 20f);
        asteroidSprite = transform.Find("Sprite");
        asteroidSprite.Rotate(0, 0, Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        asteroidSprite.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime, Space.World);
    }
}
