using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpSystem : MonoBehaviour {

    private LevelManager levelManager;
    public int healthToGive;
	
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            levelManager.AddHealth(healthToGive);
            gameObject.SetActive(false);
        }
    }
}
