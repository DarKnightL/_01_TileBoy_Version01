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
    public Vector3 respawnPosition;
    public GameObject stompBox;

    public float knockBackForce;
    public float knockBackLength;
    public float knockBackCounter;

    public float invincibleLength;
    public float invincibleCounter;

    public AudioSource jumpSound;
    public AudioSource hitHurtSound;

    private LevelManager levelManager;
    public Rigidbody2D rigidbody;
    private bool isGrounded;

    public bool canMove;

    private bool onPlatform;
    public float onPlatformSpeedModifier;
    private float activeMoveSpeed;

    private Animator anim;


    void Start()
    {
        canMove = true;
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPosition = transform.position;
        levelManager = FindObjectOfType<LevelManager>();
        activeMoveSpeed = moveSpeed;
    }


    void Update()
    {
        InputControl();
        AnimControl();
    }


    void InputControl()
    {
        if (knockBackCounter <= 0&& canMove)
        {
            if (onPlatform)
            {
                activeMoveSpeed = moveSpeed * onPlatformSpeedModifier;
             
            }
            else
            {
                activeMoveSpeed = moveSpeed;
            }

            levelManager.invincible = false;
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                rigidbody.velocity = new Vector3(activeMoveSpeed, rigidbody.velocity.y, 0);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                rigidbody.velocity = new Vector3(-activeMoveSpeed, rigidbody.velocity.y, 0);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                jumpSound.Play();
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpSpeed, 0);
            }
        }
        if (knockBackCounter > 0)
        {

            knockBackCounter -= Time.deltaTime;
            if (rigidbody.transform.localScale.x > 0)
            {
                rigidbody.velocity = new Vector3(-knockBackForce, knockBackForce, 0f);
            }
            else
            {
                rigidbody.velocity = new Vector3(knockBackForce, knockBackForce, 0f);
            }
        }

        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
        else if (invincibleCounter <= 0)
        {
            levelManager.invincible = false;
        }


        if (rigidbody.velocity.y >= 0)
        {
            stompBox.SetActive(false);
        }
        else
        {
            stompBox.SetActive(true);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }


    void AnimControl()
    {
        anim.SetFloat("speed", Mathf.Abs(rigidbody.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            levelManager.Respawn();
        }
        if (other.tag == "CheckPoint")
        {
            respawnPosition = other.transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            onPlatform = true;
            transform.SetParent(other.transform);
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            onPlatform = false;
            transform.SetParent(null);
        }
    }


    public void KnockBack()
    {
        invincibleCounter = invincibleLength;
        levelManager.invincible = true;
        knockBackCounter = knockBackLength;
    }

}
