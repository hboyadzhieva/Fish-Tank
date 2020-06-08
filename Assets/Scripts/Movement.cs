using UnityEngine;
using static UnityEngine.Mathf;

public class Movement : MonoBehaviour
{
    [SerializeField]
    [Range(1, 5)]
    private float speed = 3;

    [SerializeField]
    private TankBoundaries tankBoundaries;

    private BoxCollider2D collider;

    private float height;

    private float currentScale;

    private readonly float movementThreshold = 0.1f;
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        height = collider.bounds.size.y;
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
        if (transform.position.x > tankBoundaries.RightBoundary())
        {
            horizontalMovement = new Vector3(tankBoundaries.LeftBoundary(), transform.position.y, 0f);
            transform.position = horizontalMovement;
        }
        else if (transform.position.x < tankBoundaries.LeftBoundary()) {
            horizontalMovement = new Vector3(tankBoundaries.RightBoundary(), transform.position.y, 0f);
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
            verticalMovement = new Vector3(transform.position.x, maxVertical, 0f);
            transform.position = verticalMovement;
        }
        else if (transform.position.y < minVertical)
        {
            verticalMovement = new Vector3(transform.position.x, minVertical, 0f);
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
        }
    }
}
