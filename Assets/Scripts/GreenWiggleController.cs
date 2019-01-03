using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenWiggleController : MonoBehaviour
{

    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed;

    private Rigidbody2D rigidbody;
    private bool moveRight;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (transform.position.x >= rightPoint.position.x && moveRight)
        {
            moveRight = false;
        }
        if (transform.position.x < leftPoint.position.x && !moveRight)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            rigidbody.velocity = new Vector3(moveSpeed, rigidbody.velocity.y, 0);
        }
        else 
        {
            rigidbody.velocity = new Vector3(-moveSpeed, rigidbody.velocity.y, 0);
        }
    }
}
