using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public float waitToRespawn;
    public GameObject deathExplosion;
    public Text scoreText;
    public Image heart1, heart2, heart3;
    public Sprite fullHeart, halfHeart, emptyHeart;

    public int maxHealth = 6;
    public int healthCount;


    private int coinCount;
    private Player player;
    private bool respawning;

    void Start()
    {
        player = FindObjectOfType<Player>();
        scoreText.text = "Score:" + coinCount;
        healthCount = maxHealth;
    }


    void Update()
    {
        if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
    }


    public IEnumerator RespawnCo()
    {
        player.gameObject.SetActive(false);
        Instantiate(deathExplosion, player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(waitToRespawn);

        healthCount = maxHealth;
        respawning = false;
        UpdateHeartMeter(); //Initialize the HP
        //TODO coinCounts return to zero;
        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);
    }


    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }


    public void AddCoin(int CoinToAdd)
    {
        coinCount += CoinToAdd;
        scoreText.text = "Score:" + coinCount;
    }


    public void HurtPlayer(int damageToTake)
    {
        healthCount -= damageToTake;
        UpdateHeartMeter();
    }


    public void UpdateHeartMeter()
    {
        switch (healthCount)
        {
            case 6:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                return;

            case 5:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = halfHeart;
                return;

            case 4:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;
                return;

            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = halfHeart;
                heart3.sprite = emptyHeart;
                return;

            case 2:
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                return;

            case 1:
                heart1.sprite = halfHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                return;


            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                return;

            default:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                return;
        }

    }
}
