using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreMenu : MonoBehaviour
{
    public List<string> highscoreList = new List<string> { "JÅH - 60000", "EFL - 37000", "FAR - 36000", "OSK - 35000", "KOS - 34000", "SAM - 33000" };
    public GameObject ScoreRowPrefab;
    public float verticalOffset = 0.9f; // Adjust this value to set the vertical distance between rows

    // Start is called before the first frame update
    void Start()
    {
        if (MainMenu.Highscores.Count > 0)
        {
            for (int i = 0; i < Math.Min(MainMenu.Highscores.Count, 6); i++)
            {
                GameObject rowObject = Instantiate(ScoreRowPrefab, transform); // Instantiate a new ScoreRow prefab

                TextMeshProUGUI textMeshPro = rowObject.GetComponentInChildren<TextMeshProUGUI>(); // Get the TextMeshPro component from the instantiated prefab

                textMeshPro.text = MainMenu.Highscores[i].Name + " - " + MainMenu.Highscores[i].Score.ToString(); // Set the text of the TextMeshPro component to the corresponding string from the high score list

                float yOffset = i * verticalOffset; // Position the instantiated row vertically with the desired offset
                rowObject.transform.localPosition += new Vector3(0f, -yOffset, 0f);
            }
        }
    }
}
