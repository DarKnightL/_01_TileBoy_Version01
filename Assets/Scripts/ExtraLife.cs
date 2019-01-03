using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour {

    public int livesToGive;

    private LevelManager levelManager;

      
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            levelManager.AddLife(livesToGive);
            gameObject.SetActive(false);
        }
    }
}
