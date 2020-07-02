using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    [SerializeField]
    private float scaleFactor;
    private float speed;
    private bool fromLeftToRight;
    private float heigth;
    private float width;

    private BoxCollider2D boxCollider;

    public float ScaleFactor { get => scaleFactor; set => scaleFactor = value; }
    public float Speed { get => speed; set => speed = value; }
    public bool FromLeftToRight { get => fromLeftToRight; set => fromLeftToRight = value; }
    public float Width { get => width; private set => width = value; }
    public float Heigth { get => heigth; private set => heigth = value; }

    private void Start()
    {
        boxCollider = GetComponentInParent<BoxCollider2D>();
        Width = boxCollider.bounds.size.x;
        Heigth = boxCollider.bounds.size.y;
    }

    public bool fishTooBig()
    {
        TankBoundaries boundaries = FindObjectOfType<TankBoundaries>();
        return Width > (boundaries.RightBoundary() - boundaries.LeftBoundary());
    }
}
