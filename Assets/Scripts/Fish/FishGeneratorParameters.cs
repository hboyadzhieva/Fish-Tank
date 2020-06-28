using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGeneratorParameters : MonoBehaviour
{
    private float minSpeed = 1, maxSpeed = 5;
    private float minScale, maxScale;
    private float maxFishPerSecond = 1;
    private bool freezePowerUpActivated = false;
    private bool multiplyPowerUpActivated = false;

    private Properties playerProperties;

    private void Start()
    {
        playerProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<Properties>();
        minScale = playerProperties.ScaleFactor * 0.5f;
        maxScale = playerProperties.ScaleFactor * 1.5f;
    }

    private void Update()
    {
        if (!MultiplyPowerUpActivated)
        {
            maxScale = playerProperties.ScaleFactor * 1.5f;
        }
    }

    public float MinSpeed { get => minSpeed; set => minSpeed = value; }
    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    public float MinScale { get => minScale; set => minScale = value; }
    public float MaxScale { get => maxScale; set => maxScale = value; }
    public float MaxFishPerSecond { get => maxFishPerSecond; set => maxFishPerSecond = value; }
    public bool FreezePowerUpActivated { get => freezePowerUpActivated; set => freezePowerUpActivated = value; }
    public bool MultiplyPowerUpActivated { get => multiplyPowerUpActivated; set => multiplyPowerUpActivated = value; }
}
