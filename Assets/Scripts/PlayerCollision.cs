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
        float playerScaleFactor = gameObject.GetComponent<Properties>().ScaleFactor;
        float enemyFishScaleFactor = gameObject.GetComponent<Properties>().ScaleFactor;
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

    private void endGame()
    {
        FindObjectOfType<GameManager>().gameOver();
    }
}
