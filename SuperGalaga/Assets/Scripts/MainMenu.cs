using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
    // Start is called before the first frame update
    //public void StartGame()
    //{
    //    SceneManager.LoadScene("Level1");
    //    SceneManager.LoadScene("Level2");
    //}
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
