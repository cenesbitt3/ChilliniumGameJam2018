using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCreation : MonoBehaviour {

    public float timer = 5.0f;
    public GameObject creationPosition;
    public GameObject grid;
    public Transform ring;

    public void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Grid")) {
            GameObject newGrid = Instantiate(grid, creationPosition.transform.position, creationPosition.transform.rotation);
            newGrid.transform.parent = ring;
        }
    }
}
