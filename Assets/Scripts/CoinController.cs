using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    private LevelManager levelManager;
    public int coinValue=100;
	
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            levelManager.AddCoin(coinValue);
            transform.gameObject.SetActive(false);
        }
    }
}
