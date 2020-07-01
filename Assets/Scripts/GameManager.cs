using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject powerUI;
    [SerializeField]
    private GameObject scoreUI;
    [SerializeField]
    FishGeneratorParameters fishGeneratorParameters;
    [SerializeField]
    private float secondsOfDifficultyGameChange;


    public void gameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverUI.SetActive(true);
            gameOverUI.GetComponentInChildren<FinalScore>().FinalScoreResult = FindObjectOfType<Score>().CurrentScore;
            powerUI.SetActive(false);
            scoreUI.SetActive(false);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        scoreUI.SetActive(true);
        powerUI.SetActive(false);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void gameTimelineParameters()
    {

    }
}
