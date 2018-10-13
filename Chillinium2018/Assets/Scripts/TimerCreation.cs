using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCreation : MonoBehaviour {

    public float timer = 3.0f;
    public GameObject creationPosition;
    public GameObject grid;

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            Instantiate(grid, creationPosition.transform.position, Quaternion.identity);
            timer = 3.0f;
        }
    }
}
