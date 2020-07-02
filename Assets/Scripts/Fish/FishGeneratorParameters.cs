using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGeneratorParameters : MonoBehaviour
{
    private float minSpeed, maxSpeed;
    private float minScale, maxScale;
    private float secondsDelay;
    private float maxFishPerSecond;
    private bool freezePowerUpActivated = false;
    private bool multiplyPowerUpActivated = false;

    public float MinSpeed { get => minSpeed; set => minSpeed = value; }
    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    public float MinScale { get => minScale; set => minScale = value; }
    public float MaxScale { get => maxScale; set => maxScale = value; }
    public float MaxFishPerSecond { get => maxFishPerSecond; set => maxFishPerSecond = value; }
    public bool FreezePowerUpActivated { get => freezePowerUpActivated; set => freezePowerUpActivated = value; }
    public bool MultiplyPowerUpActivated { get => multiplyPowerUpActivated; set => multiplyPowerUpActivated = value; }
    public float SecondsDelay { get => secondsDelay; set => secondsDelay = value; }
}
