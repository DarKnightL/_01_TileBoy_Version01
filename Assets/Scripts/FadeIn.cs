using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    private Image blackScreen;

    public float fadeTime;

	void Start () {
        blackScreen = GetComponent<Image>();
	}
	
	
	void Update () {
        blackScreen.CrossFadeAlpha(0, fadeTime, false);
        if (blackScreen.color.a==0f)
        {
            blackScreen.gameObject.SetActive(false);
        }
	}
}
