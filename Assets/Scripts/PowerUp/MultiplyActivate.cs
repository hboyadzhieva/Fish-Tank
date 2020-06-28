using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyActivate : PowerActivate
{
    private FishGeneratorParameters generatorParameters;
    private float initialMaxScale, initialMaxFishPerSecond;
    GameObject player;
    public override void activatePower()
    {
        base.activatePower();
        generatorParameters = GameObject.FindObjectOfType<FishGeneratorParameters>();
        player = GameObject.FindGameObjectWithTag("Player");
        initialMaxScale = generatorParameters.MaxScale;
        initialMaxFishPerSecond = generatorParameters.MaxFishPerSecond;
        generatorParameters.MaxFishPerSecond = 3;
        generatorParameters.MaxScale = player.GetComponent<Properties>().ScaleFactor;
        generatorParameters.MultiplyPowerUpActivated = true;
        Debug.Log("MULTIPLY ACTIVATED");
    }

    public override void deactivatePower()
    {
        base.deactivatePower();
        generatorParameters.MaxScale = initialMaxScale;
        generatorParameters.MaxFishPerSecond = initialMaxFishPerSecond;
        generatorParameters.MultiplyPowerUpActivated = false;
        Debug.Log("MULTIPLY DEACTIVATED");
    }
}
