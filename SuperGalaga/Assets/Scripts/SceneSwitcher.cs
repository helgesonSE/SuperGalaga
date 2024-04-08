using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    static float delay;
    static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public static void PlayerDeath()
    {
        gameOver = true;
        delay = Time.time + 3;
    }

    private void Update()
    {
        if (gameOver && Time.time >= delay)
            SceneManager.LoadScene("GameEndMenu");
    }
}
