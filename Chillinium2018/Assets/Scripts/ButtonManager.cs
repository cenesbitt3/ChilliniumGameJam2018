using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    public GameObject instructionScreen, exitInstructionButton, creditsScreen, instructionButton, quitButton, creditsButton, exitCreditButton, gameOverScreen, restartButton;
    public GameObject scoreText, highScoreText, blankScreen, optionsButton, otherHighScore, resetButton, exitOptionButton, constantScoreText;
    public GameObject slider, heart, livesText;
    PlayerLives livesScript;
    Score scoreScript;
    PostProcesssorController processingScript;
    TimerCreation timerScriprt;
    public GameObject playerGrid;

    public void Awake()
    {
        livesScript = FindObjectOfType<PlayerLives>();
        scoreScript = FindObjectOfType<Score>();
        processingScript = FindObjectOfType<PostProcesssorController>();
        timerScriprt = FindObjectOfType<TimerCreation>();
    }

    public void InstructionsButton() {
        instructionScreen.SetActive(true);
        optionsButton.SetActive(false);
        quitButton.SetActive(false);
        instructionButton.SetActive(false);

    }

    public void OtherHighScore() {
        Text text = otherHighScore.GetComponent<Text>();
        text.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void ExitInstructions() {
        instructionScreen.SetActive(false);
        optionsButton.SetActive(true);
        quitButton.SetActive(true);
        instructionButton.SetActive(true);
    }

    public void QuitGameButton() {
        Application.Quit();
    }

    public void CreditsButton() {
        creditsScreen.SetActive(true);
    }

    public void ExitCreditButton() {
        creditsScreen.SetActive(false);
    }

    public void TurnOnGameOver() {
        gameOverScreen.gameObject.SetActive(true);
    }

    public void RestartButton() {
        processingScript.hueChnage = 0;
        processingScript.ChangeHueProfileOne();
        scoreScript.score = 0;
        scoreScript.UpdateText();
        livesScript.dead = false;
        livesScript.lives = 1;
        livesScript.UpdateText();
        timerScriprt.playerGrid.SetActive(false);

        gameOverScreen.gameObject.SetActive(false);
    }

    public void OptionsButton() {
        OtherHighScore();
        blankScreen.SetActive(true);
        optionsButton.SetActive(false);
        instructionButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void ExitOptionsButton() {
        blankScreen.SetActive(false);
        optionsButton.SetActive(true);
        instructionButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
        string newtext = otherHighScore.GetComponent<Text>().text;
        newtext = "HighScore: 0"; 
    }


}
