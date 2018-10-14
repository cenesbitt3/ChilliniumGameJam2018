using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour {

    public GameObject lifePos1, lifePos2, lifePos3, lifeObject;
    Manager managerScript;
    ButtonManager buttonScript;
    TimerCreation timerScript;
    Score scoreScript;
    public int lives = 1;
    public bool dead = false;
    public Text numLives;

    public void Awake()
    {
        managerScript = FindObjectOfType<Manager>();
        buttonScript = FindObjectOfType<ButtonManager>();
        timerScript = FindObjectOfType<TimerCreation>();
        scoreScript = FindObjectOfType<Score>();

    }

    public void UpdateText() {
        numLives.text = "x : " + lives;
    }

    public void LoseLife() {
        Debug.Log("We have enter Lose a life function");
        if (lives <= 0)
        {
            dead = true;
            timerScript.playerGrid.SetActive(false);
            scoreScript.UpdateHighScore();
            buttonScript.TurnOnGameOver();

        }
        else {
            lives--;
        }
        Debug.Log("I have " + lives+ " left");
        UpdateText();
    }

    public void GainLife() {
        lives++;
        UpdateText();
    }
}
