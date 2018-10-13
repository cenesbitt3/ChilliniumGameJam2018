using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public Material[] mats = new Material[3];
    public GameObject introText, posToCreate, ring, convergenceSpot;
    public ParticleSystem atomExplosion;

    bool startOfGame = false;
    bool readyToPlay = false;
    GameObject holderGameObject;
    ButtonManager buttonManagerScript;

    public void Awake()
    {
        buttonManagerScript = FindObjectOfType<ButtonManager>();
    }

    public void Update()
    {
        if (!startOfGame) {
            try
            {
                holderGameObject = Instantiate(introText, posToCreate.transform.position, posToCreate.transform.rotation);
                holderGameObject.transform.parent = ring.transform;
                startOfGame = true;
            }
            catch
            {

            }
        }

        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Mouse2)) {
            if (readyToPlay) {
                holderGameObject.transform.parent = ring.transform;
                buttonManagerScript.instructionButton.SetActive(false);
                buttonManagerScript.quitButton.SetActive(false);
            }
        }
    }

    public void SetReadyToPlay(bool ready) {
        readyToPlay = ready;
        Debug.Log("We are ready to press any button and play");
        
    }
}
