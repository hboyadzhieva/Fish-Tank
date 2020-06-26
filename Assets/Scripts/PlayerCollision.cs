﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Renderer renderer;
    private float size;
    public event Action<GameObject> onPlayerEatSmallerFish;
    public event Action onPlayerEatBiggerFish;

    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        size = renderer.bounds.size.x * renderer.bounds.size.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Renderer enemyRenderer = other.gameObject.GetComponent<Renderer>();
        float enemyFishSize = enemyRenderer.bounds.size.x * enemyRenderer.bounds.size.y;
        Debug.Log(enemyFishSize + " enemy fish size; " + size + " size");
        if (size >= enemyFishSize)
        {
            Debug.Log(other.gameObject);
            onPlayerEatSmallerFish += playerGrowUp;
            onPlayerEatSmallerFish?.Invoke(other.gameObject);
            Destroy(other.gameObject);
        }
        else
        {
            onPlayerEatBiggerFish?.Invoke();
            Destroy(this.gameObject);
        }
    }

    private void playerGrowUp(GameObject other)
    {
        float scale = other.GetComponent<BoxCollider2D>().bounds.size.x;
        gameObject.transform.localScale += new Vector3(scale, scale, 0);
    }
}