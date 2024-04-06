using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public GameObject explosionPrefab;
    private PointManager pointManager;
    private WaveSpawner waveSpawner;

    //its fixad
    // Start is called before the first frame update
    void Start()
    {

        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
        waveSpawner = GameObject.FindObjectOfType<WaveSpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            waveSpawner.waves[waveSpawner.waveIndex].enemiesLeft--;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }

    }

}
