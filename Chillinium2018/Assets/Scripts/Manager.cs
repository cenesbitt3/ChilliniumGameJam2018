using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public Material[] mats = new Material[3];


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) {
            // Start moving
        }
    }
}
