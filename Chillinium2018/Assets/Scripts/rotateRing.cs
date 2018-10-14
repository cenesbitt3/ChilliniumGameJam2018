using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRing : MonoBehaviour {

    public float RotationSpeed = 5f;

	
	
	void Update () {
        transform.Rotate(Vector3.right * (RotationSpeed * Time.deltaTime));
    }
}
