﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    [SerializeField]
    private TankBoundaries tankBoundaries;
    [SerializeField]
    private GameObject[] powerUps;
    private float xPos, yPos;
    void Start()
    {
        StartCoroutine(generatePowerUps());
    }

    IEnumerator generatePowerUps()
    {
        while (true)
        {
            //generate random values
            xPos = Random.Range(tankBoundaries.LeftBoundary(), tankBoundaries.RightBoundary());
            yPos = Random.Range(tankBoundaries.BottomBoundary(), tankBoundaries.TopBoundary());
            int n = Random.Range(0,powerUps.Length);

            //instantiate random powerUp
            GameObject powerUp = Instantiate(powerUps[n], new Vector3(xPos, yPos, -4), Quaternion.identity);

            //Destroy(powerUp);

            yield return new WaitForSeconds(10);
        }
        
    }

}
