using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private TankBoundaries tankBoundaries;
    private Animator animator;
    private Properties properties;

    private void Start()
    { 
        animator = gameObject.GetComponent<Animator>();
        properties = gameObject.GetComponent<Properties>();
        tankBoundaries = FindObjectOfType<TankBoundaries>();
    }
    void Update()
    {
        Move();
        DestroyFish();
    }

    private void Move()
    {
        Vector3 horizontalMovement;
        if (properties.FromLeftToRight)
        {
            horizontalMovement = new Vector3(1f, 0f, 0f);
        }
        else
        {
            horizontalMovement = new Vector3(-1f, 0f, 0f);
        }
        transform.position += horizontalMovement * Time.deltaTime * properties.Speed;
    }

    private void DestroyFish()
    {
        float maxHorizontal = tankBoundaries.RightBoundary() + properties.Width / 2;
        float minHorizontal = tankBoundaries.LeftBoundary() - properties.Width / 2;
        if (properties.FromLeftToRight && transform.position.x > maxHorizontal) {
            Destroy(gameObject);
        }
        if(!properties.FromLeftToRight && transform.position.x < minHorizontal)
        {
            Destroy(gameObject);
        }
    }



}
