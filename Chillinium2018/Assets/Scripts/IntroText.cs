﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour {
    Manager managerScript;
    TimerCreation timerScript;
    ButtonManager buttonManagerScript;

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
            gameObject.transform.parent = null;
            managerScript.SetReadyToPlay(true);
            buttonManagerScript.instructionButton.SetActive(true);
            buttonManagerScript.quitButton.SetActive(true);
        }
        else if (other.gameObject.tag == "Destroyer") {
            Destroy(gameObject);
            timerScript.SetReadyToSpawn(true);
        }
    }
}
