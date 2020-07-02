using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyActivate : PowerActivate
{
    private FishGeneratorParameters generatorParameters;
    private float initialMaxScale, initialMaxFishPerSecond, initialSecondsDelay;
    GameObject player;
    public override void activatePower()
    {
        base.activatePower();
        generatorParameters = GameObject.FindObjectOfType<FishGeneratorParameters>();
        player = GameObject.FindGameObjectWithTag("Player");
        initialMaxScale = generatorParameters.MaxScale;
        initialMaxFishPerSecond = generatorParameters.MaxFishPerSecond;
        initialSecondsDelay = generatorParameters.SecondsDelay;
        generatorParameters.MaxFishPerSecond = initialMaxFishPerSecond*2;
        generatorParameters.MaxScale = player.GetComponent<Properties>().ScaleFactor;
        generatorParameters.SecondsDelay /= 2;
        generatorParameters.MultiplyPowerUpActivated = true;
    }

    public override void deactivatePower()
    {
        base.deactivatePower();
        generatorParameters.MaxScale = initialMaxScale;
        generatorParameters.MaxFishPerSecond = initialMaxFishPerSecond;
        generatorParameters.SecondsDelay = initialSecondsDelay;
        generatorParameters.MultiplyPowerUpActivated = false;
    }
}
