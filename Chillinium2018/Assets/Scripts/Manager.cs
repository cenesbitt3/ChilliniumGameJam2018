﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Manager : MonoBehaviour {

    public Material[] mats = new Material[3];
    public GameObject introText, posToCreate, ring, convergenceSpot;
    public ParticleSystem redExplosion, greenExplosion;
    public Animator anim;
    public AudioClip beginSong;
    public AudioClip GameOver;
    public AudioClip Main;
    

    public List<Component> postProcessors = new List<Component>();

    bool startOfGame = false;
    bool readyToPlay = false;
    GameObject holderGameObject;
    ButtonManager buttonManagerScript;
    PlayerLives lifeScript;
    public GameObject cam;

    public void Awake()
    {
        buttonManagerScript = FindObjectOfType<ButtonManager>();
        lifeScript = FindObjectOfType<PlayerLives>();
    }

    public void Update()
    {
        if (!startOfGame) {
            
                holderGameObject = Instantiate(introText, posToCreate.transform.position, posToCreate.transform.rotation);
                holderGameObject.transform.parent = ring.transform;
                startOfGame = true;
           
        }

        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Mouse2)) {
            if (readyToPlay) {
                holderGameObject.transform.parent = ring.transform;
                buttonManagerScript.instructionButton.SetActive(false);
                buttonManagerScript.quitButton.SetActive(false);
                buttonManagerScript.optionsButton.SetActive(false);
                buttonManagerScript.livesText.SetActive(true);
                buttonManagerScript.heart.SetActive(true);
                buttonManagerScript.slider.SetActive(true);
                anim.SetBool("GO", true);
                cam.GetComponent<AudioSource>().clip = Main;
                cam.GetComponent<AudioSource>().Play();
            }
        }
    }

    public void SetReadyToPlay(bool ready) {
        readyToPlay = ready;
        Debug.Log("We are ready to press any button and play");
        
    }
}
