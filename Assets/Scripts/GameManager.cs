using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    bool gameIsPaused = false;

    private float restartDelay = 1f;
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject powerUI;
    [SerializeField]
    private GameObject scoreUI;
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    FishGeneratorParameters fishGeneratorParameters;
    [SerializeField]
    PowerUpGeneratorParameters powerUpGeneratorParameters;
    [SerializeField]
    Properties playerProperties;

    //beginning of the game parameters
    [SerializeField]
    [Range(0.1f, 1f)]
    private float minFishScale;
    [SerializeField]
    [Range(1f, 2f)]
    private float maxFishScale;
    [SerializeField]
    [Range(1, 3)]
    private float minFishSpeed;
    [SerializeField]
    [Range(3, 5)]
    private float maxFishSpeed;
    [SerializeField]
    [Range(1, 5)]
    private int maxFishPerSecond;
    [SerializeField]
    [Range(10, 20)]
    private float secondsBtwPowerUps;
    [SerializeField]
    [Range(0.2f, 5f)]
    private float secondsBtwFish;
    [SerializeField]
    [Range(2, 4)]
    private float secondsForPowerUp;
    [SerializeField]
    private float secondsOfDifficultyGameChange;

    private void Start()
    {
        powerUI.SetActive(false);
        scoreUI.SetActive(true);
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
        playerProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<Properties>();
        fishGeneratorParameters.MinScale = minFishScale * playerProperties.ScaleFactor;
        fishGeneratorParameters.MaxScale = maxFishScale * playerProperties.ScaleFactor;
        fishGeneratorParameters.MinSpeed = minFishSpeed;
        fishGeneratorParameters.MaxSpeed = maxFishSpeed;
        fishGeneratorParameters.SecondsDelay = secondsBtwFish;
        fishGeneratorParameters.MaxFishPerSecond = maxFishPerSecond;
        powerUpGeneratorParameters.SecondsDelayBtwPowerUps = secondsBtwPowerUps;
        powerUpGeneratorParameters.SecondsBeforePowerUpDissapears = secondsForPowerUp;
        StartCoroutine(levelUp());
    }

    private void Update()
    {
        if (!fishGeneratorParameters.MultiplyPowerUpActivated)
        {
            fishGeneratorParameters.MinScale = minFishScale * playerProperties.ScaleFactor;
            fishGeneratorParameters.MaxScale = maxFishScale * playerProperties.ScaleFactor;
            fishGeneratorParameters.SecondsDelay = secondsBtwFish;
            fishGeneratorParameters.MaxFishPerSecond = maxFishPerSecond;
        }
        fishGeneratorParameters.MinSpeed = minFishSpeed;
        fishGeneratorParameters.MaxSpeed = maxFishSpeed;
        if (playerProperties.fishTooBig())
        {
            Debug.Log("NOW");
        }

    }

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

    public void pause()
    {
        if (!gameIsPaused)
        {
            gameIsPaused = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void resume()
    {
        if (gameIsPaused)
        {
            gameIsPaused = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator levelUp()
    {
        yield return new WaitForSeconds(secondsOfDifficultyGameChange);
        maxFishScale += 0.5f;
        maxFishSpeed += 0.5f;
        minFishSpeed += 0.5f;
        maxFishPerSecond = (int) Mathf.Round(maxFishPerSecond + 0.5f);

    }


}
