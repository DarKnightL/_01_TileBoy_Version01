using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public string levelSelect;
    public string mainMenu;

    public GameObject pauseScreen;


    private LevelManager levelManager;
    private Player player;


    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
    }


    void Update()
    {
        if (Time.timeScale == 1)
        {
            PauseGameFunction();
        }
        else
        {
            ResumeGame();
        }
    }


    public void LevelSelect()
    {
        PlayerPrefs.SetInt("coinCount", 0);
        PlayerPrefs.SetInt("playerLives", levelManager.maxLives);
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1;

    }


    public void ResumeGame()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            player.canMove = true;
            levelManager.levelMusicSound.Play();
        }
    }



    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1;
    }


    public void PauseGameFunction()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            player.canMove = false;
            levelManager.levelMusicSound.Pause();
        }
    }
}
