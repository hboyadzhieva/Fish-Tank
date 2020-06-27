using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private float speed;
    private bool fromLeftToRight;
    private TankBoundaries tankBoundaries;
    private float height;
    private float width;
    private BoxCollider2D collider;
    private Animator animator;

    public float Speed { get => speed; set => speed = value; }
    public bool FromLeftToRight { get => fromLeftToRight; set => fromLeftToRight = value; }
    public TankBoundaries TankBoundaries { get => tankBoundaries; set => tankBoundaries = value; }

    private void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        height = collider.bounds.size.y;
        width = collider.bounds.size.x;
    }
    void Update()
    {
        Move();
        DestroyFish();
    }

    private void Move()
    {
        Vector3 horizontalMovement;
        if (FromLeftToRight)
        {
            horizontalMovement = new Vector3(1f, 0f, 0f);
        }
        else
        {
            horizontalMovement = new Vector3(-1f, 0f, 0f);
        }
        transform.position += horizontalMovement * Time.deltaTime * Speed;
    }

    private void DestroyFish()
    {
        float maxHorizontal = tankBoundaries.RightBoundary() + width / 2;
        float minHorizontal = tankBoundaries.LeftBoundary() - width / 2;
        if (fromLeftToRight && transform.position.x > maxHorizontal) {
            Destroy(gameObject);
        }
        if(!fromLeftToRight && transform.position.x < minHorizontal)
        {
            Destroy(gameObject);
        }
    }



}
