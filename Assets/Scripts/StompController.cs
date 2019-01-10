using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompController : MonoBehaviour
{

    public GameObject deathExplosion;
    public float bounceForce;

    private Rigidbody2D rigidbody;


    void Start()
    {
        rigidbody = transform.parent.GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            Instantiate(deathExplosion, other.transform.position, Quaternion.identity);
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, bounceForce, 0f);
        }
        if (other.tag=="Boss")
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, bounceForce, 0f);
            other.transform.parent.GetComponent<BossController>().takeDamage = true;
        }
    }
}
