using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour {

    public GameObject[] places = new GameObject[9];

    int colorChoice;
    int shapeChoice;
    bool filled;
    GameObject shape;

    Manager managerScript;

    public void Awake()
    {
        managerScript = FindObjectOfType<Manager>();

        for (int i = 0; i < places.Length; i++) {
            colorChoice = Random.Range(0, 3);
            shapeChoice = Random.Range(1, 3);


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
        }
    }

    public void Update()
    {
        gameObject.transform.Translate(Vector3.forward * -1.0f * Time.deltaTime);
    }
}
