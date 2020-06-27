using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    [SerializeField]
    private GameObject gameOverMenu;

    public void gameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverMenu.SetActive(true);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
