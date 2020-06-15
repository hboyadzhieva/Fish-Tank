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
    private float currentScale;

   
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();

        height = collider.bounds.size.y;
        width = collider.bounds.size.x;
        currentScale = transform.localScale.x;
    }

    void Update()
    {
        moveHorizontal();
        moveVertical();
        ResolveLookDirection();
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

    private void ResolveLookDirection()
    {
        if (Abs(Input.GetAxis("Horizontal")) > movementThreshold) {
            Debug.Log(Input.GetAxis("Horizontal"));
            transform.localScale = new Vector3(Sign(Input.GetAxis("Horizontal"))*currentScale, currentScale, 1f);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
