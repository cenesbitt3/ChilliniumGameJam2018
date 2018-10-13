using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour {

    public GameObject[] places = new GameObject[9];
    bool isFilled;

    placementManger pmanger;

    int[] colorChoice = new int[9];
    int[] filledChoice = new int[9];
    bool[] filled = new bool[9];
    GameObject shape;
    Spawner spawner;
    Manager managerScript;

    public void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
        pmanger = FindObjectOfType<placementManger>();
        managerScript = FindObjectOfType<Manager>();
        spawner.Spawn();
        for (int i = 0; i < places.Length; i++) {
            colorChoice[i] = Random.Range(0, 3);

            filledChoice[i] = Random.Range(0, 2);

            if (filledChoice[i] == 1)
            {
                isFilled = true; // switvh to false later
               // places[i].SetActive(false);
                //continue;
            }
            else if(filledChoice[i] == 1){
                isFilled = true;
                places[i].SetActive(true);
            }
            filled[i] = isFilled;
            MeshRenderer mesh = places[i].GetComponent<MeshRenderer>();

            switch (colorChoice[i]) {
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
            enemyPlace.FillValues(colorChoice[i], i, isFilled);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScreenCollider")) {
            gameObject.transform.parent = null;
            // Run check the the classes
            for (int i = 0; i < pmanger.colors.Length; i++) {
                if (pmanger.colors[i] == colorChoice[i])
                {
                    Debug.Log("working");
                }
            }
        }
    }

    public void Update()
    {
      // if()
    }
}
