using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnRespawn : MonoBehaviour
{

    private Vector3 startPosition;
    private Quaternion startQuaternion;
    private Vector3 startLocalScale;
    private Rigidbody2D rigidbody;


    void Start()
    {
        startPosition = transform.position;
        startQuaternion = transform.rotation;
        startLocalScale = transform.localScale;
        if (GetComponent<Rigidbody2D>() != null)
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
    }


    void Update()
    {

    }

    public void ResetStatus()
    {
        transform.position = startPosition;
        transform.rotation = startQuaternion;
        transform.localScale = startLocalScale;
        if (GetComponent<Rigidbody2D>() != null)
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}
