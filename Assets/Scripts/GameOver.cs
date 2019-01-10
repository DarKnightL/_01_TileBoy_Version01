using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private LevelManager levelManager;

    public string mainMenu;
    public string levelSelect;
	
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	
	void Update () {
		
	}


    public void Restart() {
        PlayerPrefs.SetInt("coinCount", 0);
        PlayerPrefs.SetInt("playerLives", levelManager.maxLives);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void LevelSelect() {
        PlayerPrefs.SetInt("coinCount", 0);
        PlayerPrefs.SetInt("playerLives", levelManager.maxLives);
        SceneManager.LoadScene(levelSelect);
    }


    public void BackToMainMenu() {
        SceneManager.LoadScene(mainMenu);
    }
}
