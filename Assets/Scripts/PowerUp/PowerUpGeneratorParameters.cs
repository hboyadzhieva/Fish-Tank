using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGeneratorParameters : MonoBehaviour
{
    private float secondsDelayBtwPowerUps;
    private float secondsBeforePowerUpDissapears;
    public float SecondsDelayBtwPowerUps { get => secondsDelayBtwPowerUps; set => secondsDelayBtwPowerUps = value; }
    public float SecondsBeforePowerUpDissapears { get => secondsBeforePowerUpDissapears; set => secondsBeforePowerUpDissapears = value; }
}
