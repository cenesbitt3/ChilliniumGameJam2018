using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour {
    Manager managerScript;
    TimerCreation timerScript;
    ButtonManager buttonManagerScript;

    public GameObject greenText;

    public void Awake()
    {
        managerScript = FindObjectOfType<Manager>();
        timerScript = FindObjectOfType<TimerCreation>();
        buttonManagerScript = FindObjectOfType<ButtonManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScreenCollider")
        {
            PressToPlay();
        }
        else if (other.gameObject.tag == "Destroyer") {
            Destroy(gameObject);
            timerScript.playerGrid.SetActive(true);
            timerScript.SetReadyToSpawn(true);
        }
    }

    public void PressToPlay() {
        gameObject.transform.parent = null;
        managerScript.SetReadyToPlay(true);
        buttonManagerScript.StartScreenPanel.SetActive(true);
        buttonManagerScript.quitButton.SetActive(true);
        greenText.SetActive(true);
    }
}
