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

    public bool invisible;

    public Text lifeText;
    public int maxLives;
    private int currentLives;
    private int coinBonusLivesCount;

    public GameObject gameOverScreen;


    private int coinCount;
    private Player player;
    private bool respawning;

    public int bonusLifeThreshold;

    private ResetOnRespawn[] objectsToReset;

    void Start()
    {
        currentLives = maxLives;
        lifeText.text = "X " + currentLives;

        player = FindObjectOfType<Player>();
        scoreText.text = "Score:" + coinCount;
        healthCount = maxHealth;

        objectsToReset = FindObjectsOfType<ResetOnRespawn>();
    }


    void Update()
    {
        if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
        if (coinBonusLivesCount>= bonusLifeThreshold)
        {
            currentLives += 1;
            lifeText.text = "X " + currentLives;
            coinBonusLivesCount -= bonusLifeThreshold;
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
        coinCount = 0;//FINISH coinCounts return to zero;
        coinBonusLivesCount = 0;
        scoreText.text = "Score:" + coinCount;
        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);

        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].ResetStatus();
            objectsToReset[i].gameObject.SetActive(true);
        }
    }


    public void Respawn()
    {
        currentLives -= 1;
        lifeText.text = "X " + currentLives;
        if (currentLives > 0)
        {
            StartCoroutine("RespawnCo");
        }
        else
        {
            player.gameObject.SetActive(false);
            gameOverScreen.gameObject.SetActive(true);
        }
    }


    public void AddCoin(int CoinToAdd)
    {
        coinCount += CoinToAdd;
        coinBonusLivesCount += CoinToAdd;
        scoreText.text = "Score:" + coinCount;
    }


    public void HurtPlayer(int damageToTake)
    {
        if (!invisible)
        {
            healthCount -= damageToTake;
            player.KnockBack();
            UpdateHeartMeter();
        }

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

    public void AddLife(int livesToAdd) {
        currentLives += livesToAdd;
        lifeText.text = "X " + currentLives;
    }


    public void AddHealth(int healthToGive) {
        healthCount += healthToGive;
        if (healthCount>maxHealth)
        {
            healthCount = maxHealth;
        }
        UpdateHeartMeter();
    }
}
