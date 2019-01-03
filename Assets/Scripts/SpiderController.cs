using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{

    public float moveSpeed;
    public bool canMove;
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (canMove)
        {
            rigidbody.velocity = new Vector3(-moveSpeed, rigidbody.velocity.y, 0);
        }
    }


    private void OnBecameVisible()
    {
        canMove = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="KillPlane")
        {
            gameObject.SetActive(false) ;
        }
    }

    private void OnEnable()
    {
        canMove = false;
    }
}
