using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class FreezeActivate : PowerActivate
{
    private GameObject[] activeEnemyFish;
    private FishGenerator generator;

    public override void activatePower()
    {
        base.activatePower();
        generator = FindObjectOfType<FishGenerator>();
        activeEnemyFish = GameObject.FindGameObjectsWithTag("Fish");
        foreach(GameObject fish in activeEnemyFish)
        {
            fish.GetComponent<FishMovement>().freeze();
        }
        generator.freeze();
        Debug.Log("FREEZE ACTIVATED");
    }

    public override void deactivatePower()
    {
        base.deactivatePower();
        foreach (GameObject fish in activeEnemyFish)
        {
            fish.GetComponent<FishMovement>().unfreeze();
        }
        generator.unfreeze();
        Debug.Log("FREEZE DEACTIVATED");
    }
}
