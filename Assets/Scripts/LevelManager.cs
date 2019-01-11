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

    public bool invincible;

    public Text lifeText;
    public int maxLives;
    public int currentLives;
    private int coinBonusLivesCount;

    public GameObject gameOverScreen;
    public AudioSource coinSound;
    public AudioSource gameOverSound;
    public AudioSource levelMusicSound;

    public int coinCount;
    private Player player;
    private bool respawning;

    public int bonusLifeThreshold;

    public bool respawnCoActive;

    private ResetOnRespawn[] objectsToReset;

    void Start()
    {
        player = FindObjectOfType<Player>();
        scoreText.text = "Score:" + coinCount;
        healthCount = maxHealth;

        if (PlayerPrefs.HasKey("coinCount"))
        {
            coinCount = PlayerPrefs.GetInt("coinCount");
            scoreText.text = "Score:" + coinCount;
        }

        if (PlayerPrefs.HasKey("playerLives"))
        {
            currentLives = PlayerPrefs.GetInt("playerLives");
            lifeText.text = "X " + currentLives;
        }
        else
        {
            currentLives = maxLives;
        }
    }


    void Update()
    {
        if (healthCount <= 0 )
        {
            Respawn();
            
        }
        if (coinBonusLivesCount >= bonusLifeThreshold)
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
        respawnCoActive = true;
 

        yield return new WaitForSeconds(waitToRespawn);


        respawnCoActive = false;
   
        healthCount = maxHealth;
        respawning = false;
        UpdateHeartMeter(); //Initialize the HP
        coinCount = 0;//FINISH coinCounts return to zero;
        coinBonusLivesCount = 0;
        scoreText.text = "Score:" + coinCount;
        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);

        if (GetComponent<ResetOnRespawn>() != null)
        {
            for (int i = 0; i < objectsToReset.Length; i++)
            {
                objectsToReset[i].gameObject.SetActive(true);
                objectsToReset[i].ResetStatus();
            }
        }
        

    }


    public void Respawn()
    {
        if (!respawning)
        {
            currentLives -= 1;
            lifeText.text = "X " + currentLives;
            if (currentLives > 0)
            {
                respawning = true;
                StartCoroutine("RespawnCo");
            }
            else
            {
                levelMusicSound.Stop();
                gameOverSound.Play();
                player.gameObject.SetActive(false);
                gameOverScreen.gameObject.SetActive(true);
            }
        }
        
       
    }


    public void AddCoin(int CoinToAdd)
    {
        coinSound.Play();
        coinCount += CoinToAdd;
        coinBonusLivesCount += CoinToAdd;
        scoreText.text = "Score:" + coinCount;
    }


    public void HurtPlayer(int damageToTake)
    {
        if (!invincible)
        {
            healthCount -= damageToTake;
            player.KnockBack();
            player.hitHurtSound.Play();
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

    public void AddLife(int livesToAdd)
    {
        currentLives += livesToAdd;
        coinSound.Play();
        lifeText.text = "X " + currentLives;
    }


    public void AddHealth(int healthToGive)
    {
        healthCount += healthToGive;
        coinSound.Play();
        if (healthCount > maxHealth)
        {
            healthCount = maxHealth;
        }
        UpdateHeartMeter();
    }
}
