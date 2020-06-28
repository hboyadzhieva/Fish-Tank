using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyActivate : PowerActivate
{
    public override void activatePower()
    {
        base.activatePower();
        Debug.Log("MULTIPLY ACTIVATED");
    }

    public override void deactivatePower()
    {
        base.deactivatePower();
        Debug.Log("MULTIPLY DEACTIVATED");
    }
}
