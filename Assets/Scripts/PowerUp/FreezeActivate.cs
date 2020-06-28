using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class FreezeActivate : PowerActivate
{
    private GameObject[] activeEnemyFish;
    private FishGeneratorParameters generatorParameters;

    public override void activatePower()
    {
        base.activatePower();
        generatorParameters = FindObjectOfType<FishGeneratorParameters>();
        activeEnemyFish = GameObject.FindGameObjectsWithTag("Fish");
        foreach(GameObject fish in activeEnemyFish)
        {
            fish.GetComponent<FishMovement>().freeze();
        }
        generatorParameters.FreezePowerUpActivated = true;
        Debug.Log("FREEZE ACTIVATED");
    }

    public override void deactivatePower()
    {
        base.deactivatePower();
        foreach (GameObject fish in activeEnemyFish)
        {
            if (fish != null) {
                fish.GetComponent<FishMovement>().unfreeze();
            }
        }
        generatorParameters.FreezePowerUpActivated = false;
        Debug.Log("FREEZE DEACTIVATED");
    }
}
