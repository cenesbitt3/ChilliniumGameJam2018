using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour {

    public GameObject lifePos1, lifePos2, lifePos3, lifeObject;
    Manager managerScript;

    public void Awake()
    {
        managerScript = FindObjectOfType<Manager>();
        Instantiate(lifeObject, lifePos1.transform.position, Quaternion.identity);
        Instantiate(lifeObject, lifePos2.transform.position, Quaternion.identity);
        Instantiate(lifeObject, lifePos3.transform.position, Quaternion.identity);

    }

    public void UpdateLives(int position) {
        switch (position) {
            case 0:
                Destroy(lifePos1.transform.Find("Atom"));
                break;
            case 1:
                Destroy(lifePos2.transform.Find("Atom"));
                break;
            case 2:
                Destroy(lifePos3.transform.Find("Atom"));
                break;
        }
    }
}
