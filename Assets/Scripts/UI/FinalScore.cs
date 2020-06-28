using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    private int finalScore;
    private int highScore;
    
    public int FinalScoreResult { get => finalScore; set => finalScore = value; }
    public int HighScoreResult { get => highScore; set => highScore = value; }

    void Start()
    {
        saveScore();
        HighScoreResult = PlayerPrefs.GetInt("HighScore", 0);
        TextMeshProUGUI[] scoreBoardChildren = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        foreach(TextMeshProUGUI child in scoreBoardChildren){
            int counter = 0;
            if (child.name == "FinalScoreResult") { child.text = FinalScoreResult.ToString(); counter++; }
            if (child.name == "HighScoreResult") { child.text = HighScoreResult.ToString(); counter++; }
            if (counter >= 2) break;
        }
    }

    private void saveScore()
    {
        if(FinalScoreResult > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", FinalScoreResult);
        }
    }

}
