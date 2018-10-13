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
    public Spawner spawner;
    Manager managerScript;

    public void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
        pmanger = FindObjectOfType<placementManger>();
        managerScript = FindObjectOfType<Manager>();
        CreateInstructions();
    }

    public void CreateInstructions()
    {
        
       // spawner.Spawn();
        for (int i = 0; i < places.Length; i++) {
            

            filledChoice[i] = Random.Range(0, 2);

            if (filledChoice[i] == 1)
            {
                isFilled = false;
                colorChoice[i] = 4;
                places[i].SetActive(false);
                continue;
            }
            else if(filledChoice[i] != 1){
                isFilled = true;
                colorChoice[i] = Random.Range(0, 3);
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
            if (isFilled)
            {
               // Debug.Log("ok");
                spawner.referenceToPlace.Add(places[i]);
                
            }
        }
        spawner.Spawn2();

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScreenCollider")) {
            gameObject.transform.parent = null;
            // Run check the the classes
            for (int i = 0; i < pmanger.colors.Length; i++) {
                if (pmanger.colors[i] == colorChoice[i])
                {
                    Debug.Log("working" + i + pmanger.colors[i] + colorChoice[i]);
                }
                Debug.Log("working" + i + pmanger.colors[i] + colorChoice[i]);
            }
        }
    }

    public void Update()
    {
      // if()
    }
}
