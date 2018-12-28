using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite flagOpen;
    public Sprite flagClosed;

    private SpriteRenderer spriteRenderer;
    private bool checkPointActive;


	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	

	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            spriteRenderer.sprite = flagOpen;
            checkPointActive = true;
        }
    }

}
