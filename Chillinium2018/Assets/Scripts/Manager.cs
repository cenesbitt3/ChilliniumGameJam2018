using System.Collections;
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
    TimerCreation timerScript;

    public void Awake()
    {
        buttonManagerScript = FindObjectOfType<ButtonManager>();
        lifeScript = FindObjectOfType<PlayerLives>();
        timerScript = FindObjectOfType<TimerCreation>();
    }

    public void Update()
    {
        if (!startOfGame) {
            
                holderGameObject = Instantiate(introText, posToCreate.transform.position, posToCreate.transform.rotation);
                holderGameObject.transform.parent = ring.transform;
                startOfGame = true;
           
        }

        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Mouse2)) {
            
            holderGameObject.transform.parent = ring.transform;
            buttonManagerScript.StartScreenPanel.SetActive(false);
            buttonManagerScript.quitButton.SetActive(false);
            buttonManagerScript.inGameUIPanel.SetActive(true);
            anim.SetBool("GO", true);
            GameObject introtext = GameObject.FindWithTag("IntroText");
            Destroy(introtext);
            timerScript.playerGrid.SetActive(true);
            timerScript.SetReadyToSpawn(true);
            startOfGame = true;
            cam.GetComponent<AudioSource>().clip = Main;
            cam.GetComponent<AudioSource>().Play();
           
        }
    }

    public void SetReadyToPlay(bool ready) {
        readyToPlay = ready;
        Debug.Log("We are ready to press any button and play");
        
    }
}
