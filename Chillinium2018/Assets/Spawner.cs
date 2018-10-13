using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public EnemyGrid curGrid;
    public GameObject AtomPrefabRed;
    public GameObject AtomPrefabBlue;
    public GameObject AtomPrefabGreen;

    public List<GameObject> referenceToPlace = new List<GameObject>();

    GameObject holderGameObject;

	void Start () {
        //curGrid = FindObjectOfType<EnemyGrid>();
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
    public void Spawn()
    {/*
        for (int i = 0; i <= ; i++)
        {
            GameObject box = Instantiate(AtomPrefabRed, new Vector3(Random.Range(-5, 5), Random.Range(-12, 3), 10.5f), AtomPrefabRed.transform.rotation);
            //box.color = spawn[i].color;
            
        }*/
    }

    public void Spawn2() {
        for (int i = 0; i < referenceToPlace.Count; i++)
        {
            EnemyPlacementManager enemyPlace = referenceToPlace[i].GetComponent<EnemyPlacementManager>();
            switch (enemyPlace.GetColor()) {
                case 0:
                    holderGameObject = Instantiate(AtomPrefabRed, new Vector3(Random.Range(-5, 5), Random.Range(-12, 3), 10.5f), AtomPrefabRed.transform.rotation);
                    break;
                case 1:
                    holderGameObject = Instantiate(AtomPrefabGreen, new Vector3(Random.Range(-5, 5), Random.Range(-12, 3), 10.5f), AtomPrefabGreen.transform.rotation);
                    break;
                case 2:
                    holderGameObject = Instantiate(AtomPrefabBlue, new Vector3(Random.Range(-5, 5), Random.Range(-12, 3), 10.5f), AtomPrefabBlue.transform.rotation);
                    break;
            }
        }
        // Clear the list
        referenceToPlace.Clear();
    }
}
