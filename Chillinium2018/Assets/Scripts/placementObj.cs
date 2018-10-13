using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementObj : MonoBehaviour
{

    public bool filled;
    public int color;
    public int placement;
    public GameObject occupyFloat;

    private void Awake()
    {
        color = 4;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!filled) {
            if (other.CompareTag("float"))
            {
                // if (drag) { 
                //  gameObject.transform.position = other.transform.position;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                other.gameObject.transform.position = transform.position;
                filled = true;
                color = other.gameObject.GetComponent<FloatBox>().color;
    
            // }

            }
            else
            {
                color = 4;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("float"))
        {
            color = 4;
            filled = false;
        }
    }
}
