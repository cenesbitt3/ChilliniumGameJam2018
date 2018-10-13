using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCreation : MonoBehaviour {

    public float timer = 5.0f;
    public GameObject creationPosition;
    public GameObject grid;
    public Transform ring;

    bool readyToSpawn = false;

    public void Update()
    {
        if (readyToSpawn)
        {
            if (!GameObject.FindGameObjectWithTag("Grid"))
            {
                GameObject newGrid = Instantiate(grid, creationPosition.transform.position, creationPosition.transform.rotation);
                newGrid.transform.parent = ring;
            }
        }

    }

    public void SetReadyToSpawn(bool ready) {
        readyToSpawn = ready;
    }
}
