using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    public float moveSpeed;
    public int MaxLive = 5;

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
        lives += ExtraLives;
        lives = Mathf.Clamp(lives, 0, MaxLive);
        UpdateLivesUI();
    }


}
