using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour {

    public bool levelUnlocked;

    public Sprite bottomDoorOpen;
    public Sprite topDoorOpen;
    public Sprite bottomDoorClosed;
    public Sprite topDoorClosed;
    public SpriteRenderer bottomDoor;
    public SpriteRenderer topDoor;


    public string levelToLoad;


	void Start () {

        PlayerPrefs.SetInt("GameScene_01", 1);

        if (PlayerPrefs.GetInt(levelToLoad)==1)
        {
            levelUnlocked = true;
        }
        else
        {
            levelUnlocked = false;
        }
        

        if (levelUnlocked)
        {
            bottomDoor.sprite = bottomDoorOpen;
            topDoor.sprite = topDoorOpen;
        }
        else
        {
            bottomDoor.sprite = bottomDoorClosed;
            topDoor.sprite = topDoorClosed;
        }
	}
	
	
	void Update () {
		
	}


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag=="Player"&&levelUnlocked)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

}
