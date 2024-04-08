using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static List<Highscore> Highscores = new List<Highscore>();
    public void Start()
    {
        Highscores.Clear();
        var highScores = File.ReadAllText(Application.persistentDataPath + "/highscores.txt");
        string[] scores = highScores.Split('\n');

        for (int i = 0; i < scores.Length -1; i++) 
        { 
            if (scores[i] != "" || scores[i] != null)
            {
                string[] scoreParts = scores[i].Split("\t");
                Debug.Log(scoreParts[0] + "XXX" + scoreParts[1]);

                Highscores.Add( new Highscore { Name = scoreParts[0], Score = Convert.ToInt32(scoreParts[1]) });
            }           
        }
    }
    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
