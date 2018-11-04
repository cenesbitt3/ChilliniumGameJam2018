using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRing : MonoBehaviour {

    public float RotationSpeed = 5f;

    public int howManyAtoms;
    
	
	
	void Update () {

        switch (howManyAtoms) {
            case 0:
                transform.Rotate(Vector3.right * (6.25f * Time.deltaTime));
                break;
            case 1:
                transform.Rotate(Vector3.right * (12f * Time.deltaTime));
                break;
            case 2:
                transform.Rotate(Vector3.right * (10f * Time.deltaTime));
                break;
            case 3:
                transform.Rotate(Vector3.right * (7.5f * Time.deltaTime));
                break;
            case 4:
                transform.Rotate(Vector3.right * (5f * Time.deltaTime));
                break;
            case 5:
                transform.Rotate(Vector3.right * (5f * Time.deltaTime));
                break;
            case 6:
                transform.Rotate(Vector3.right * (4.75f * Time.deltaTime));
                Debug.Log("Speed or ring is 4.75f");
                break;
            case 7:
                transform.Rotate(Vector3.right * (4.5f * Time.deltaTime));
                break;
            case 8:
                transform.Rotate(Vector3.right * (4.25f * Time.deltaTime));
                break;
            case 9:
                transform.Rotate(Vector3.right * (4f * Time.deltaTime));
                break;
        }
    }
}
