using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    private LevelManager levelManager;
    private Player player;
    public int damageToGive;


    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
    }


    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelManager.HurtPlayer(damageToGive);
        }
    }
}
