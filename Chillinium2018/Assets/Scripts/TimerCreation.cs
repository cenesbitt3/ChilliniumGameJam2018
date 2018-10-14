using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCreation : MonoBehaviour {

    public float timer = 5.0f;
    public GameObject creationPosition, playerGrid;
    public GameObject grid, trialGrid;
    public Transform ring;

    bool readyToSpawn = false;
    bool firstTrial = true;
    PlayerLives livesScript;

    public void Awake()
    {
        livesScript = FindObjectOfType<PlayerLives>();
    }

    public void Update()
    {
        if (readyToSpawn)
        {
            //playerGrid.SetActive(true);
            //if (firstTrial)
            //{
                //GameObject firstGrid = Instantiate(trialGrid, creationPosition.transform.position, creationPosition.transform.rotation);
                //firstGrid.transform.parent = ring;
                //if (!firstTrial)
                //{
                    if (!livesScript.dead)
                    {
                        if (!GameObject.FindGameObjectWithTag("Grid"))
                        {
                            GameObject newGrid = Instantiate(grid, creationPosition.transform.position, creationPosition.transform.rotation);
                            newGrid.transform.parent = ring;
                            //Destroy(GameObject.Find("IntroText_3"));
                        }
                    }
                //}
                //firstTrial = false;
            //}
        }

    }

    public void SetReadyToSpawn(bool ready) {
        readyToSpawn = ready;
    }
}
