using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToContinue;
    public string firstLevel;

    public string[] levelNames;

    public int startingLives;

	void Start () {
		
	}

	
	void Update () {
		
	}


    public void NewGame() {
        SceneManager.LoadScene(firstLevel);
        for (int i = 0; i < levelNames.Length; i++)
        {
            PlayerPrefs.SetInt(levelNames[i],0);
            PlayerPrefs.SetInt("coinCount", 0);
            PlayerPrefs.SetInt("playerLives", startingLives);
        }
    }


    public void ContinueGame() {
        SceneManager.LoadScene(levelToContinue);
    }


    public void ExitGame() {
        Application.Quit();
    }
}
