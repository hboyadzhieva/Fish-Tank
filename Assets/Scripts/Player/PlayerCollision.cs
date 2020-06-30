using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private float size;
    public static event Action<GameObject> onPlayerEatSmallerFish;
    public static event Action onPlayerEatBiggerFish;

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
                onPlayerEatBiggerFish?.Invoke();
            }
        }
        else if (other.CompareTag("Power"))
        {
            other.gameObject.GetComponent<PowerActivate>().activatePower();
            Destroy(other.gameObject);
        }
       
    }

}
