using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    private WaveSpawner waveSpawner;
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    public float moveSpeed;
    public int MaxLive = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            moveSpeed *= -1;
        }
        if (collision.gameObject.tag == "Boundary" && (collision.gameObject.name == "Niceship(Clone)" || collision.gameObject.name == "Niceship2(Clone)"))
        {
            Destroy(collision.gameObject);
            waveSpawner.waves[waveSpawner.waveIndex].enemiesLeft--;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives -= 1;
            if (lives >= 0 && lives < livesUI.Length)
            {
                livesUI[lives].enabled = false;
            }

            if (lives <= 0)
            {
                SceneSwitcher.EndGame(false);
                Destroy(gameObject);
            }
        }


        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives -= 1;
            if (lives >= 0 && lives < livesUI.Length)
            {
                livesUI[lives].enabled = false;
            }

            if (lives <= 0)
            {
                SceneSwitcher.EndGame(false);
                Destroy(gameObject);
            }
        }
    }
    public void UpdateLivesUI()
    {
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives;

        }
    }

    public void FillUpLives(int ExtraLives)
    {
        lives = ExtraLives;
        lives = Mathf.Clamp(lives, 0, MaxLive);
        UpdateLivesUI();
    }


}
