using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBoundaries : MonoBehaviour
{

    private Vector2 screenMaxBounds;
    private Vector2 screenMinBounds;
    void Start()
    {
        screenMaxBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenMinBounds = -screenMaxBounds;
    }

    public float TopBoundary() {
        return screenMaxBounds.y;
    }

    public float RightBoundary() {
        return screenMaxBounds.x;
    }

    public float BottomBoundary()
    {
        return screenMinBounds.y;
    }

    public float LeftBoundary()
    {
        return screenMinBounds.x;
    }

}
