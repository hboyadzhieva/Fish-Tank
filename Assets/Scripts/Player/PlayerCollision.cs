using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Renderer renderer;
    private float size;
    public static event Action<GameObject> onPlayerEatSmallerFish;
    public event Action onPlayerEatBiggerFish;

    void Start()
    {
        renderer = gameObject.GetComponentInChildren<Renderer>();
        size = renderer.bounds.size.x * renderer.bounds.size.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish"))
        {
            float playerScaleFactor = gameObject.GetComponent<Properties>().ScaleFactor;
            float enemyFishScaleFactor = other.gameObject.GetComponent<Properties>().ScaleFactor;
            if (playerScaleFactor >= enemyFishScaleFactor)
            {
                onPlayerEatSmallerFish?.Invoke(other.gameObject);
                Destroy(other.gameObject);
            }
            else
            {
                onPlayerEatBiggerFish += endGame;
                onPlayerEatBiggerFish?.Invoke();
                Destroy(this.gameObject);
            }
        }
        else if (other.CompareTag("Power"))
        {
            other.gameObject.GetComponent<PowerActivate>().activatePower();
        }
       
    }

    private void endGame()
    {
        FindObjectOfType<GameManager>().gameOver();
    }

}
