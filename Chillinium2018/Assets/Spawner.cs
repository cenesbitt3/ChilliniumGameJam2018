using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public EnemyGrid curGrid;
    public GameObject AtomPrefab;

	void Start () {
        curGrid = FindObjectOfType<EnemyGrid>();
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
    public void Spawn()
    {
        for (int i = 0; i <= 9; i++)
        {
            GameObject box = Instantiate(AtomPrefab, new Vector3(Random.Range(-5, 5), Random.Range(-12, 3), 10.5f), AtomPrefab.transform.rotation);

        }
    }
}
