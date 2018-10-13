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

    public void Update()
    {
        if (!startOfGame) {
            holderGameObject = Instantiate(introText, posToCreate.transform.position, posToCreate.transform.rotation);
            holderGameObject.transform.parent = ring.transform;
            startOfGame = true;
        }

        if (Input.anyKeyDown) {
            if (readyToPlay) {
                holderGameObject.transform.parent = ring.transform;
            }
        }
    }

    public void SetReadyToPlay(bool ready) {
        readyToPlay = ready;
        Debug.Log("We are ready to press any button and play");
    }
}
