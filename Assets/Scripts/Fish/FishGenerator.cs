using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishGenerator : MonoBehaviour
{
    private float xPos, yPos, speed, scale;
    private bool fromLeftToRight;
    
    [SerializeField]
    private TankBoundaries tankBoundaries;
    [SerializeField]
    private GameObject[] fish;
    [SerializeField]
    private FishGeneratorParameters parameters;

    void Start()
    {
        StartCoroutine(createFish());
    }

    IEnumerator createFish()
    {
        while (true)
        {
            if (!parameters.FreezePowerUpActivated)
            {
                for (int i = 0; i <= parameters.MaxFishPerSecond; i++)
                {
                    // generate random values for scale, speed, direction of movement, and type of fish
                    fromLeftToRight = Random.Range(0f, 1f) > 0.5f;
                    xPos = fromLeftToRight ? tankBoundaries.LeftBoundary() : tankBoundaries.RightBoundary();
                    yPos = Random.Range(tankBoundaries.BottomBoundary(), tankBoundaries.TopBoundary());
                    int n = Random.Range(0, fish.Length - 1);
                    scale = Random.Range(parameters.MinScale, parameters.MaxScale);
                    speed = Random.Range(parameters.MinSpeed, parameters.MaxSpeed);

                    // instantiate random fish
                    GameObject currentFish = Instantiate(fish[n], new Vector3(xPos, yPos, -4), Quaternion.identity);

                    //set parameters to instantiated fish
                    Properties fishProperties = currentFish.GetComponent<Properties>();
                    fishProperties.FromLeftToRight = fromLeftToRight;
                    fishProperties.Speed = speed;
                    fishProperties.ScaleFactor = scale;

                    currentFish.transform.localScale = fromLeftToRight ? new Vector3(-scale, scale, 1) : new Vector3(scale, scale, 1);
                }
            }
            yield return new WaitForSeconds(1);
        }
    }


}
