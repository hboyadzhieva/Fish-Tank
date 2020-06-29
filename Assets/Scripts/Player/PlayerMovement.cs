using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1, 5)]
    private float speed = 3;
    private readonly float movementThreshold = 0.1f;

    private TankBoundaries tankBoundaries;
    private Animator animator;
    private Properties properties;

    private Vector3 currentScale;
    private Vector3 initialScale;
    private Vector3 initialPosition;

   
    void OnEnable()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        tankBoundaries = FindObjectOfType<TankBoundaries>();
        properties = GetComponent<Properties>();
        currentScale = transform.localScale;
        properties.Speed = speed;
        properties.ScaleFactor = Abs(transform.localScale.x);
        PlayerCollision.onPlayerEatSmallerFish += updateLocalScale;
        Lives.onGameOver += disablePlayer;
    }

    private void OnDisable()
    {
        PlayerCollision.onPlayerEatSmallerFish -= updateLocalScale;
        Lives.onGameOver -= disablePlayer;
    }

    void Update()
    {
        moveHorizontal();
        moveVertical();
        resolveLookDirection();
        setMoveAnimation();
    }

    private void moveHorizontal()
    {
        Vector3 horizontalMovement;
        float maxHorizontal = tankBoundaries.RightBoundary() + properties.Width/2;
        float minHorizontal = tankBoundaries.LeftBoundary() - properties.Width/2;
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
        float maxVertical = tankBoundaries.TopBoundary() - properties.Heigth / 2;
        float minVertical = tankBoundaries.BottomBoundary() + properties.Heigth / 2;
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
            transform.localScale = new Vector3(-Sign(horizontalAxis) * Abs(currentScale.x), currentScale.y, currentScale.z);
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
        float scale = Abs(other.transform.localScale.x)/10;
        if(Sign(currentScale.x) == 1)
        {
            transform.localScale += new Vector3(scale, scale, currentScale.z);
        }
        else
        {
            transform.localScale += new Vector3(-scale, scale, currentScale.z);
        }
        currentScale = transform.localScale;
        properties.ScaleFactor = Abs(currentScale.x);
    }
    
    private void disablePlayer()
    {
        gameObject.SetActive(false);
    }
}
