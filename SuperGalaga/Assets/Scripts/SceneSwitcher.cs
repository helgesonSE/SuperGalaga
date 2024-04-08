using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    static float delay;
    static bool isGameEnding = false;
    static string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public static void EndGame(bool gameWon)
    {

        isGameEnding = true;
        delay = Time.time + 3;
        if (gameWon)
            SceneManager.LoadScene("GameWinMenu");
        else
            SceneManager.LoadScene("GameEndMenu");
    }

    private void Update()
    {
        if (isGameEnding && Time.time >= delay)
        {
            SceneManager.LoadScene(sceneToLoad);
            isGameEnding = false;

        }
    }

}
