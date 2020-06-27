using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1, 5)]
    private float speed = 3;
    private readonly float movementThreshold = 0.1f;

    [SerializeField]
    private TankBoundaries tankBoundaries;
    private BoxCollider2D collider;
    private Animator animator;

    private float height;
    private float width;
    private Vector3 currentScale;

   
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponentInChildren<Animator>();

        height = collider.bounds.size.y;
        width = collider.bounds.size.x;
        currentScale = transform.localScale;
        PlayerCollision.onPlayerEatSmallerFish += updateLocalScale;
    }

    void Update()
    {
        moveHorizontal();
        moveVertical();
        resolveLookDirection();
        setMoveAnimation();
       // currentScale = transform.localScale.x;
    }

    private void moveHorizontal()
    {
        Vector3 horizontalMovement;
        float maxHorizontal = tankBoundaries.RightBoundary() + width/2;
        float minHorizontal = tankBoundaries.LeftBoundary() - width/2;
        if (transform.position.x > maxHorizontal)
        {
            horizontalMovement = new Vector3(minHorizontal, transform.position.y, transform.position.z);
            transform.position = horizontalMovement;
        }
        else if (transform.position.x < minHorizontal) {
            horizontalMovement = new Vector3(maxHorizontal, transform.position.y, transform.position.z);
            transform.position = horizontalMovement;
        }
        else
        {
            horizontalMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += horizontalMovement * Time.deltaTime * speed;
        }
        
    }

    private void moveVertical()
    {
        Vector3 verticalMovement;
        float maxVertical = tankBoundaries.TopBoundary() - height / 2;
        float minVertical = tankBoundaries.BottomBoundary() + height / 2;
        if (transform.position.y > maxVertical) {
            verticalMovement = new Vector3(transform.position.x, maxVertical, transform.position.z);
            transform.position = verticalMovement;
        }
        else if (transform.position.y < minVertical)
        {
            verticalMovement = new Vector3(transform.position.x, minVertical, transform.position.z);
            transform.position = verticalMovement;
        }
        else
        {
            verticalMovement = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
            transform.position += verticalMovement * Time.deltaTime * speed;
        }
    }

    private void resolveLookDirection()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (Abs(horizontalAxis)>movementThreshold)
        {
            transform.localScale = new Vector3(Sign(horizontalAxis) * Abs(currentScale.x), currentScale.y, currentScale.z);
            currentScale = transform.localScale;
        }
    }

    private void setMoveAnimation()
    {
        if(animator != null)
        {
            if(Abs(Input.GetAxis("Horizontal")) > movementThreshold){
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }

    void updateLocalScale(GameObject other)
    {
        float scale = Abs(other.transform.localScale.x);
        transform.localScale = new Vector3(currentScale.x*scale, currentScale.y*scale, currentScale.z );
        currentScale = transform.localScale;
    }
}
