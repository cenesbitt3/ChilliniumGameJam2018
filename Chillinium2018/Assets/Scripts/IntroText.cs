using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour {
    Manager managerScript;
    TimerCreation timerScript;

    public void Awake()
    {
        managerScript = FindObjectOfType<Manager>();
        timerScript = FindObjectOfType<TimerCreation>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScreenCollider")
        {
            gameObject.transform.parent = null;
            managerScript.SetReadyToPlay(true);
        }
        else if (other.gameObject.tag == "Destroyer") {
            Destroy(gameObject);
            timerScript.SetReadyToSpawn(true);
        }
    }
}
