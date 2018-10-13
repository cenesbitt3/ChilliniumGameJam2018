using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public GameObject instructionScreen, exitInstructionButton, creditsScreen, instructionButton, quitButton, creditsButton, exitCreditButton, gameOverScreen, restartButton;

    public void InstructionsButton() {
        Time.timeScale = 0f;
        instructionScreen.SetActive(true);
        exitInstructionButton.SetActive(true);
        creditsButton.SetActive(true);
        instructionButton.SetActive(false);
        quitButton.SetActive(false);

    }

    public void ExitInstructions() {
        Time.timeScale = 1f;
        instructionScreen.SetActive(false);
        exitInstructionButton.SetActive(false);
        creditsButton.SetActive(false);
        instructionButton.SetActive(true);
        quitButton.SetActive(true);

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
        gameOverScreen.gameObject.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);

    }


}
