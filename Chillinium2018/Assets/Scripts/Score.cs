using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text highScore;
    public int score = 0;
    public Slider powerSlider;

    PlayerLives livesScript;

    public void Start()
    {
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        livesScript = FindObjectOfType<PlayerLives>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            powerSlider.value += 20;
            if (powerSlider.value >= 100)
            {
                // increase a life
                livesScript.GainLife();
                powerSlider.value = 0;
            }
        }
    }

    // Use this for initialization
    public void AddToScore() {
        powerSlider.value += 20;
        score++;
        UpdateText();
        powerBar.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 10f, transform.localScale.z);
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


        if (powerSlider.value == 100) {
            // increase a life
            livesScript.GainLife();
            powerSlider.value = 0;
        }