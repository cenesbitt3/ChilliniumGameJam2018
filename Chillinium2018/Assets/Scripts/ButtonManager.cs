using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour {
    public GameObject instructionScreen, creditsScreen, quitButton, gameOverScreen;
    public GameObject scoreText, highScoreText, optionsScreen, optionsButton, otherHighScore, resetButton;
    public GameObject slider, inGameUIPanel, StartScreenPanel;
    PlayerLives livesScript;
    Score scoreScript;
    PostProcesssorController processingScript;
    TimerCreation timerScriprt;
    public GameObject playerGrid;
    public Slider volumeSlider;

    public void Awake()
    {
        livesScript = FindObjectOfType<PlayerLives>();
        scoreScript = FindObjectOfType<Score>();
        processingScript = FindObjectOfType<PostProcesssorController>();
        timerScriprt = FindObjectOfType<TimerCreation>();
    }

    public void InstructionsButton() {
        // Time.timeScale = 0f;
        CloseUI();
        instructionScreen.SetActive(true);
    }

    public void CloseUI() {
        instructionScreen.SetActive(false);
        creditsScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        optionsScreen.SetActive(false);
        inGameUIPanel.SetActive(false);
        StartScreenPanel.SetActive(false);
        quitButton.SetActive(false);
    }

    public void OtherHighScore() {
        Text text = otherHighScore.GetComponent<Text>();
        text.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void ExitInstructions() {
        CloseUI();
        StartScreenPanel.SetActive(true);
        quitButton.SetActive(true);
    }

    public void QuitGameButton() {
        Application.Quit();
    }

    public void CreditsButton() {
        CloseUI();
        creditsScreen.SetActive(true);
    }

    public void ExitCreditButton() {
        CloseUI();
        instructionScreen.SetActive(true);
    }

    public void TurnOnGameOver() {
        gameOverScreen.gameObject.SetActive(true);
        quitButton.SetActive(true);
    }

    public void RestartButton() {
        if (!processingScript.hueSet)
        {
            processingScript.hueChnage = 0;
            processingScript.ChangeHueProfileOne();
        }
        scoreScript.score = 0;
        scoreScript.UpdateText();
        livesScript.dead = false;
        livesScript.lives = 3;
        gameOverScreen.gameObject.SetActive(false);
        quitButton.SetActive(false);
        inGameUIPanel.SetActive(true);
        livesScript.UpdateText();
        timerScriprt.playerGrid.SetActive(false);
    }

    public void OptionsButton() {
        CloseUI();
        OtherHighScore();
        optionsScreen.SetActive(true);
    }

    public void ExitOptionsButton() {
        CloseUI();
        StartScreenPanel.SetActive(true);
        quitButton.SetActive(true);
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
        string newtext = otherHighScore.GetComponent<Text>().text;
        newtext = "HighScore: 0"; 
    }

    public void SliderChange() {
        AudioListener.volume = volumeSlider.value;
    }

    public void SetHueButton(int hue) {
        switch (hue) {
            case 1:
                processingScript.ChangeHueProfileOne();
                break;
            case 2:
                processingScript.ChangeHueProfileTwo();
                break;
            case 3:
                processingScript.ChangeHueProfileThree();
                break;
            case 4:
                processingScript.ChangeHueProfileFour();
                break;
        }
    }

}
