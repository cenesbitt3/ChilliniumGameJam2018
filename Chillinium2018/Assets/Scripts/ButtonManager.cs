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
       // Time.timeScale = 0f;
        instructionScreen.SetActive(true);
        exitInstructionButton.SetActive(true);
        creditsButton.SetActive(true);
        instructionButton.SetActive(false);
        quitButton.SetActive(false);
        slider.SetActive(false);
        heart.SetActive(false);
        livesText.SetActive(false);
        optionsButton.SetActive(false);

    }

    public void OtherHighScore() {
        Text text = otherHighScore.GetComponent<Text>();
        text.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void ExitInstructions() {
        //Time.timeScale = 1f;
        instructionScreen.SetActive(false);
        exitInstructionButton.SetActive(false);
        creditsButton.SetActive(false);
        instructionButton.SetActive(true);
        quitButton.SetActive(true);
        slider.SetActive(true);
        heart.SetActive(true);
        livesText.SetActive(true);
        optionsButton.SetActive(true);
    }

    public void QuitGameButton() {
        Application.Quit();
    }

    public void CreditsButton() {
        instructionScreen.SetActive(false);
        creditsScreen.SetActive(true);
        exitCreditButton.SetActive(true);
        exitInstructionButton.SetActive(false);
        creditsButton.SetActive(false);
    }

    public void ExitCreditButton() {
        creditsScreen.SetActive(false);
        exitCreditButton.SetActive(false);
        InstructionsButton();
    }

    public void TurnOnGameOver() {
        //Time.timeScale = 0f;
        gameOverScreen.gameObject.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        scoreText.SetActive(true);
        highScoreText.SetActive(true);
        timerScriprt.playerGrid.SetActive(false);

    }

    public void RestartButton() {
        //Time.timeScale = 1f;
        processingScript.hueChnage = 0;
        processingScript.ChangeHueProfileOne();
        scoreScript.score = 0;
        scoreScript.UpdateText();
        livesScript.dead = false;
        livesScript.lives = 3;
        gameOverScreen.gameObject.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
        scoreText.SetActive(false);
        highScoreText.SetActive(false);
        livesScript.UpdateText();
        timerScriprt.playerGrid.SetActive(false);
        //playerGrid.GetComponent<MeshRenderer>().enabled = false;
    }

    public void OptionsButton() {
        // Time.timeScale = 0f;
        OtherHighScore();
        optionsButton.SetActive(false);
        quitButton.SetActive(false);
        instructionButton.SetActive(false);
        exitOptionButton.SetActive(true);
        resetButton.SetActive(true);
        otherHighScore.SetActive(true);
        blankScreen.SetActive(true);
        slider.SetActive(false);
        heart.SetActive(false);
        livesText.SetActive(false);

    }

    public void ExitOptionsButton() {
       // Time.timeScale = 1f;
        blankScreen.SetActive(false);
        resetButton.SetActive(false);
        otherHighScore.SetActive(false);
        exitOptionButton.SetActive(false);
        optionsButton.SetActive(true);
        quitButton.SetActive(true);
        instructionButton.SetActive(true);
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
        string newtext = otherHighScore.GetComponent<Text>().text;
        newtext = "HighScore: 0"; 
    }


}
