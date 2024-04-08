using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameOverMenu : MonoBehaviour
{
    public TMP_InputField PlayerSignature;
    public string Score;
    // Start is called before the first frame update
    void Start()
    {
        var playerScore = GameObject.Find("PlayerScore").GetComponentInChildren<TextMeshProUGUI>();
        playerScore.text = Score = PointManager.Score.ToString();
        Debug.Log(playerScore.text);
    }
    public void EnterSignature(TMP_InputField playerSignature)
    {

        if (playerSignature.text != null || Score != null || playerSignature.text != "Enter name")
        {
            MainMenu.Highscores.Add(new Highscore { Name = playerSignature.text, Score = Convert.ToInt32(Score) });
            MainMenu.Highscores = MainMenu.Highscores
                .OrderByDescending(r => r.Score)
                .ToList();

            using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/highscores.txt"))
            {
                foreach (var scoreRow in MainMenu.Highscores)
                {
                    writer.WriteLine(scoreRow.Name + "\t" + scoreRow.Score);
                }
            }
        }

        SceneManager.LoadScene("Menu");
    }
}
