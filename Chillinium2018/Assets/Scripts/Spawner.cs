using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public EnemyGrid curGrid;
    public GameObject AtomPrefabRed;
    public GameObject AtomPrefabBlue;
    public GameObject AtomPrefabGreen;
    GameObject Center;
    float min = 50f;
    float max = 80f;
    placementManger pManger;

    public List<GameObject> referenceToPlace = new List<GameObject>();

    GameObject holderGameObject;

	void Start () {
        Center = GameObject.Find("Center");
        pManger =  FindObjectOfType<placementManger>();
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
        for (int i = 0; i < 9; i++){
            pManger.colors[i] = 4;
            pManger.filled[i] = false;
            
        }
            for (int i = 0; i < referenceToPlace.Count; i++)
        {
            EnemyPlacementManager enemyPlace = referenceToPlace[i].GetComponent<EnemyPlacementManager>();
            switch (enemyPlace.GetColor()) {
                case 0:
                    holderGameObject = Instantiate(AtomPrefabRed, Center.transform.position, AtomPrefabRed.transform.rotation);
                    holderGameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    holderGameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    //holderGameObject = Instantiate(AtomPrefabRed, new Vector3(Random.Range(-4, 4), Random.Range(-6, -12), 10.5f), AtomPrefabRed.transform.rotation);
                    break;
                case 1:
                    holderGameObject = Instantiate(AtomPrefabGreen, Center.transform.position, AtomPrefabGreen.transform.rotation);
                    holderGameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    holderGameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    // holderGameObject = Instantiate(AtomPrefabGreen, new Vector3(Random.Range(-4, 4), Random.Range(-6, -12), 10.5f), AtomPrefabGreen.transform.rotation);
                    break;
                case 2:
                    holderGameObject = Instantiate(AtomPrefabBlue, Center.transform.position, AtomPrefabBlue.transform.rotation);
                    holderGameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    holderGameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    // holderGameObject = Instantiate(AtomPrefabBlue, new Vector3(Random.Range(-4, 4), Random.Range(-6, -12), 10.5f), AtomPrefabBlue.transform.rotation);
                    break;
            }
        }
        // Clear the list
        referenceToPlace.Clear();
    }
    public void Spawn3()
    {
        for (int i = 0; i < 9; i++)
        {
            pManger.colors[i] = 4;
            pManger.filled[i] = false;

        }
        for (int i = 0; i < referenceToPlace.Count; i++)
        {
            EnemyPlacementManager enemyPlace = referenceToPlace[i].GetComponent<EnemyPlacementManager>();
            switch (enemyPlace.GetColor())
            {
                case 0:
                    holderGameObject = Instantiate(AtomPrefabRed, Center.transform.position, AtomPrefabRed.transform.rotation);
                    holderGameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    holderGameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    //holderGameObject = Instantiate(AtomPrefabRed, new Vector3(Random.Range(-4, 4), Random.Range(-6, -12), 10.5f), AtomPrefabRed.transform.rotation);
                    break;
                case 1:
                    holderGameObject = Instantiate(AtomPrefabRed, Center.transform.position, AtomPrefabRed.transform.rotation);
                    holderGameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    holderGameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    // holderGameObject = Instantiate(AtomPrefabGreen, new Vector3(Random.Range(-4, 4), Random.Range(-6, -12), 10.5f), AtomPrefabGreen.transform.rotation);
                    break;
                case 2:
                    holderGameObject = Instantiate(AtomPrefabRed, Center.transform.position, AtomPrefabRed.transform.rotation);
                    holderGameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    holderGameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
                    // holderGameObject = Instantiate(AtomPrefabBlue, new Vector3(Random.Range(-4, 4), Random.Range(-6, -12), 10.5f), AtomPrefabBlue.transform.rotation);
                    break;
            }
        }
        // Clear the list
        referenceToPlace.Clear();
    }
}
