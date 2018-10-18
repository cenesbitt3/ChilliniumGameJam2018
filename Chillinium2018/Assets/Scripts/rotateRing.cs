using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRing : MonoBehaviour {

     float RotationSpeed;

    int numAtoms;
    
	
	
	void Update () {

       // GameObject[] atoms = GameObject.FindGameObjectsWithTag("float");
        transform.Rotate(Vector3.right * ((RotationSpeed) * Time.deltaTime));
    }

    public void ChangeSpeed(int change) {
        numAtoms = change;

        switch (numAtoms) {
            case 0:
                // We do not accept
                break;
            case 1:
                // RotationSpeed = fastest
                break;
            case 2:
                // RotationSpeed = fastest - 1;
                break;
            case 3:
                // RotationSpeed = fastest - 1;
                break;
            case 4:
                // RotationSpeed = fastest - 1;
                break;
            case 5:
                // RotationSpeed = fastest - 1;
                break;
            case 6:
                // RotationSpeed = fastest - 1;
                break;
            case 7:
                // RotationSpeed = fastest - 1;
                break;
            case 8:
                // RotationSpeed = fastest - 1;
                break;
            case 9:
                // RotationSpeed = fastest - 1;
                break;
            default:
                Debug.Log("I did not expect this to happen. Rotation speed swith");
                break;
        }
    }
}
