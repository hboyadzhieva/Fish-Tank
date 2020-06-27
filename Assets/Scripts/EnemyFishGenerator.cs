using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyFishGenerator : MonoBehaviour
{
    private float xPos;
    private float yPos;
    private float speed;
    private bool fromLeftToRight;
    private float scale;

    private float minSpeed = 1, maxSpeed = 5;
    private float minScale = 1, maxScale = 7;
    
    [SerializeField]
    private TankBoundaries tankBoundaries;
    [SerializeField]
    private GameObject[] fish;

    void Start()
    {
        StartCoroutine(createFish());
    }

    IEnumerator createFish()
    {
        while (true)
        {
            // generate random values for scale, speed, direction of movement, and type of fish
            fromLeftToRight = Random.Range(0f, 1f) > 0.5f;
            xPos = fromLeftToRight ? tankBoundaries.LeftBoundary() : tankBoundaries.RightBoundary();
            xPos = fromLeftToRight ? tankBoundaries.LeftBoundary() : tankBoundaries.RightBoundary();
            yPos = Random.Range(tankBoundaries.BottomBoundary(), tankBoundaries.TopBoundary());
            int n = Random.Range(0, fish.Length-1);
            scale = Random.Range(minScale, maxScale);
            speed = Random.Range(minSpeed, maxSpeed);

            // instantiate random fish
            GameObject currentFish = Instantiate(fish[n], new Vector3(xPos, yPos, -4), Quaternion.identity);
            
            //set parameters to instantiated fish
            FishMovement movement = (FishMovement)currentFish.GetComponent("FishMovement");
            movement.FromLeftToRight = fromLeftToRight;
            movement.Speed = speed;
            movement.TankBoundaries = tankBoundaries;
            //currentFish.GetComponent<BoxCollider2D>().size *= scale;
           
            currentFish.transform.localScale = fromLeftToRight ? new Vector3(scale, scale, 1) : new Vector3(-scale, scale, 1);
            //currentFish.AddComponent<BoxCollider2D>();

            yield return new WaitForSeconds(3);
        }
    }
    


}
