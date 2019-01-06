using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    public float followAhead;
    public float smoothing;

    public bool followTarget;

    private Vector3 targetPosition;


    void Start()
    {
        followTarget = true;
    }


    void Update()
    {
        if (followTarget)
        {
            targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
            if (target.transform.localScale.x > 0f)
            {
                targetPosition = new Vector3(target.transform.position.x + followAhead, transform.position.y, transform.position.z);
            }
            else
            {
                targetPosition = new Vector3(target.transform.position.x - followAhead, transform.position.y, transform.position.z);
            }
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }


}
