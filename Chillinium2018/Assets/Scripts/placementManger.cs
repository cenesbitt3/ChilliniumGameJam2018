using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementManger : MonoBehaviour {

    public GameObject[] placmentObjects;
    public GameObject[] housedAtoms;
    public int[] colors;
    public bool[] filled;
    public int[] placment;
    public int tutorialNum;
    private void Update()
    {
     /*   for(int i =0; i < placmentObjects.Length;i++)
        {
             colors[i] = placmentObjects[i].gameObject.GetComponent<placementObj>().color;
             filled[i] = placmentObjects[i].gameObject.GetComponent<placementObj>().filled;
              placment[i] = placmentObjects[i].gameObject.GetComponent<placementObj>().placement;
        }*/

    }
}
