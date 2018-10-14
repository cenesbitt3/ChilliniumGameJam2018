using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour {

    public GameObject lifePos1, lifePos2, lifePos3, lifeObject;
    Manager managerScript;
    ButtonManager buttonScript;
    TimerCreation timerScript;
    Score scoreScript;
    public int lives = 3;
    public bool dead = false;

    public void Awake()
    {
        managerScript = FindObjectOfType<Manager>();
        buttonScript = FindObjectOfType<ButtonManager>();
        timerScript = FindObjectOfType<TimerCreation>();
        scoreScript = FindObjectOfType<Score>();

    }

    public void UpdateLives(int position) {
        switch (position) {
            case 0:
                Destroy(lifePos1.transform.Find("Atom"));
                break;
            case 1:
                Destroy(lifePos2.transform.Find("Atom"));
                break;
            case 2:
                Destroy(lifePos3.transform.Find("Atom"));
                break;
        }
    }

    public void LoseLife() {
        Debug.Log("We have enter Lose a life function");
        if (lives <= 1)
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
    }
}
