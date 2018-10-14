using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text highScore;
    public int score = 0;

    public void Start()
    {
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Use this for initialization
    public void AddToScore() {
        score++;
        UpdateText();
        Debug.Log("Score: " + score);
    }
	
	// Update is called once per frame
	public void UpdateText () {
        scoreText.text = "Score: "+ score;
	}

    public void UpdateHighScore() {
        if (score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = "HighScore: " + score;
        }
    }
}
