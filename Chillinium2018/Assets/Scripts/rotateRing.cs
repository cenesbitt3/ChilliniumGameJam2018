using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRing : MonoBehaviour {

    public float RotationSpeed = 5f;
   // public float RotationSpeed = 5f;

    public int howManyAtoms;

        switch (howManyAtoms) {
            case 0:
                transform.Rotate(Vector3.right * (6.25f * Time.deltaTime));
                Debug.Log("Speed or ring is 10");
                break;
            case 1:
                transform.Rotate(Vector3.right * (6f * Time.deltaTime));
                break;
            case 2:
                transform.Rotate(Vector3.right * (5.75f * Time.deltaTime));
                break;
            case 3:
                transform.Rotate(Vector3.right * (5.25f * Time.deltaTime));
                break;
            case 4:
                transform.Rotate(Vector3.right * (5f * Time.deltaTime));
                break;
            case 5:
                transform.Rotate(Vector3.right * (5f * Time.deltaTime));
                break;
            case 6:
                transform.Rotate(Vector3.right * (4.75f * Time.deltaTime));
                break;
            case 7:
                transform.Rotate(Vector3.right * (4.25f * Time.deltaTime));
                break;
            case 8:
                transform.Rotate(Vector3.right * (4f * Time.deltaTime));
                break;
            case 9:
                transform.Rotate(Vector3.right * (3.75f * Time.deltaTime));
                break;
        }
    }
/*
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
    }*/
}

 //  
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