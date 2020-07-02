using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private int currentLives;
    private GameObject life1, life2, life3;

    public static event Action onGameOver;

    public int CurrentLives { get => currentLives; set => currentLives = value; }

    void Start()
    {
        CurrentLives = 3;
        life1 = GameObject.Find("LivesUI/LiveImage1");
        life2 = GameObject.Find("LivesUI/LiveImage2");
        life3 = GameObject.Find("LivesUI/LiveImage3");
        life1.GetComponent<Image>().enabled = true; 
        life2.GetComponent<Image>().enabled = true; 
        life3.GetComponent<Image>().enabled = true;
        PlayerCollision.onPlayerEatBiggerFish += loseLife;
        onGameOver += endGame;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentLives == 2)
        {
            life3.GetComponent<Image>().enabled = false;
        }
        else if(CurrentLives == 1)
        {
            life2.GetComponent<Image>().enabled = false;
        }
        else if(CurrentLives == 0)
        {
            life1.GetComponent<Image>().enabled = false;
            onGameOver?.Invoke();
        }
    }

    private void loseLife() {
        CurrentLives--;
    }

    private void OnDisable()
    {
        PlayerCollision.onPlayerEatBiggerFish -= loseLife;
    }

    private void endGame()
    {
        FindObjectOfType<GameManager>().gameOver();
    }

}
