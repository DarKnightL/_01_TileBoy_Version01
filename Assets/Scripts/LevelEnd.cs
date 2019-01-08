using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    public string levelToLoad;


    private LevelManager levelManager;
    private CameraController cameraController;
    private Player player;

    private bool movePlayer;

    public float waitToMove;
    public float waitToLoad;

    public Sprite flagOpen;
    private SpriteRenderer spriteRenderer;

    public string levelToUnlock;


	void Start () {
       
        levelManager = FindObjectOfType<LevelManager>();
        cameraController = FindObjectOfType<CameraController>();
        player = FindObjectOfType<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	
	void Update () {
		if (movePlayer)
        {
            player.rigidbody.velocity = new Vector3(player.moveSpeed, player.rigidbody.velocity.y, 0f);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spriteRenderer.sprite = flagOpen;
            StartCoroutine("LevelEndCo");

        }
    }


    public IEnumerator LevelEndCo()
    {
        player.canMove = false;
        cameraController.followTarget = false;
        levelManager.invincible = true;
        player.rigidbody.velocity = Vector3.zero;

        PlayerPrefs.SetInt("coinCount", levelManager.coinCount);
        PlayerPrefs.SetInt("playerLives", levelManager.currentLives);
       


        levelManager.levelMusicSound.Stop();
        levelManager.gameOverSound.Play();

        PlayerPrefs.SetInt(levelToUnlock,1);

        yield return new WaitForSeconds(waitToMove);
        movePlayer = true;
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(levelToLoad);
        
    }

  

}
