using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public GameObject instructionImage, exitInstructionButton, Introtext, ring;

    public void InstructionsButton() {
        Time.timeScale = 0f;
        instructionImage.SetActive(true);
        exitInstructionButton.SetActive(true);

    }

    public void ExitInstructions() {
        Time.timeScale = 1f;
        instructionImage.SetActive(false);
        exitInstructionButton.SetActive(false);
    }

    public void ExitGameButton() {
        Application.Quit();
    }
}
