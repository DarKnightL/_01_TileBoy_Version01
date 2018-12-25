using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public float jumpSpeed;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rigidbody;
    private bool isGrounded;

    private Animator anim;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        InputControl();
        AnimControl();
    }


    void InputControl()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rigidbody.velocity = new Vector3(moveSpeed, rigidbody.velocity.y, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rigidbody.velocity = new Vector3(-moveSpeed, rigidbody.velocity.y, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpSpeed, 0);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }


    void AnimControl()
    {
        anim.SetFloat("speed", Mathf.Abs(rigidbody.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }


}
