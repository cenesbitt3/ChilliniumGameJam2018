using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRing : MonoBehaviour {

    public float RotationSpeed = 5f;
    
	
	
	void Update () {

       // GameObject[] atoms = GameObject.FindGameObjectsWithTag("float");
        transform.Rotate(Vector3.right * ((RotationSpeed) * Time.deltaTime));
    }
}
