﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour {

    public GameObject[] places = new GameObject[9];

    int colorChoice;
    int filledChoice;
    bool filled;
    GameObject shape;

    Manager managerScript;

    public void Awake()
    {
        managerScript = FindObjectOfType<Manager>();

        for (int i = 0; i < places.Length; i++) {
            colorChoice = Random.Range(0, 3);
            filledChoice = Random.Range(0, 2);

            if (filledChoice == 1)
            {
                filled = false;
                places[i].SetActive(false);
                continue;
            }
            else if(filledChoice == 1){
                filled = true;
                places[i].SetActive(true);
            }

            MeshRenderer mesh = places[i].GetComponent<MeshRenderer>();

            switch (colorChoice) {
                case 0: // Red material
                    mesh.material = managerScript.mats[0];
                    break;
                case 1: // Green material
                    mesh.material = managerScript.mats[1];
                    break;
                case 2: // Blue material
                    mesh.material = managerScript.mats[2];
                    break;
            }
            EnemyPlacementManager enemyPlace = places[i].GetComponent<EnemyPlacementManager>();
            enemyPlace.FillValues(colorChoice, i, filled);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScreenCollider")) {
            gameObject.transform.parent = null;
            // Run check the the classes

        }
    }

    public void Update()
    {
      // if()
    }
}