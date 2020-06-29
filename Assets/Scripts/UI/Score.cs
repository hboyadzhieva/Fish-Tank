using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{ 
    private int currentScore;
    public int CurrentScore { get => currentScore; set => currentScore = value; }


    void Start()
    {
        currentScore = 0;
        PlayerCollision.onPlayerEatSmallerFish += updateScore;
    }

    void updateScore(GameObject other)
    {
        currentScore += Mathf.RoundToInt(other.GetComponent<Properties>().ScaleFactor*100);
        gameObject.GetComponent<TextMeshProUGUI>().text = currentScore.ToString();
    }

    private void OnDisable()
    {
        PlayerCollision.onPlayerEatSmallerFish -= updateScore;
    }
}
