using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour {

    public GameObject[] places = new GameObject[9];
    public float convergenceSpeed = 6.0f;
    bool isFilled;


    placementManger pmanger;

    public int[] colorChoice = new int[9];
    int[] filledChoice = new int[9];
    bool[] filled = new bool[9];
    GameObject shape;
    public Spawner spawner;
    Manager managerScript;
    ButtonManager buttonManagerScript;
    PostProcesssorController hueScript;
    Score scoreScript;
    PlayerLives livesScript;
    int winNum;
    bool passed = false;
    bool failed = false;
    bool changeScore = true;
    int hueChange = -1;
    public GameObject plane;
    public Mesh square;
    public Mesh sphere;
    public Mesh diamond;
    public Mesh yourMesh;
    bool first = true;

    public void Awake()
    {
        yourMesh = gameObject.GetComponent<Mesh>();
        spawner = FindObjectOfType<Spawner>();
        pmanger = FindObjectOfType<placementManger>();
        managerScript = FindObjectOfType<Manager>();
        buttonManagerScript = FindObjectOfType<ButtonManager>();
        hueScript = FindObjectOfType<PostProcesssorController>();
        scoreScript = FindObjectOfType<Score>();
        livesScript = FindObjectOfType<PlayerLives>();
        CreateInstructions();
        winNum = 0;
    }
    
    public void CreateInstructions()
    {
        
       // spawner.Spawn();
        for (int i = 0; i < places.Length; i++) {
            

            filledChoice[i] = Random.Range(0, 2);

            if (filledChoice[i] == 1)
            {
                isFilled = false;
                colorChoice[i] = 4;
                places[i].SetActive(false);
                continue;
            }
            else if(filledChoice[i] != 1){
                isFilled = true;
                if (pmanger.tutorialNum >= 18)
                {
                    colorChoice[i] = Random.Range(0, 3);
                }
                else
                {
                    colorChoice[i] = 1;
                    pmanger.tutorialNum++;
                }
                switch (colorChoice[i])
                {
                    case 0:
                        gameObject.transform.GetChild(i).GetComponent<MeshFilter>().mesh = diamond;
                        break;
                    case 1:
                        gameObject.transform.GetChild(i).GetComponent<MeshFilter>().mesh = sphere;
                        break;
                    case 2:
                        gameObject.transform.GetChild(i).GetComponent<MeshFilter>().mesh = square;
                        break;
                    default:
                        break;

                }
                places[i].SetActive(true);
            }
           // first = false;
            filled[i] = isFilled;
            MeshRenderer mesh = places[i].GetComponent<MeshRenderer>();
            TrailRenderer trail = places[i].GetComponent<TrailRenderer>();

            switch (colorChoice[i])
            {
                case 0: // Red material
                    mesh.material = managerScript.mats[0];
                    trail.material = managerScript.mats[0];
                    
                    break;
                case 1: // Green material
                    mesh.material = managerScript.mats[1];
                    trail.material = managerScript.mats[1];
                    
                    break;
                case 2: // Blue material
                    mesh.material = managerScript.mats[2];
                    trail.material = managerScript.mats[2];
                   
                    break;
            }

            EnemyPlacementManager enemyPlace = places[i].GetComponent<EnemyPlacementManager>();
            enemyPlace.FillValues(colorChoice[i], i, isFilled);
            if (isFilled)
            {
               // Debug.Log("ok");
                spawner.referenceToPlace.Add(places[i]);
                
            }
        }
        first = false;
        spawner.Spawn2();
        
    }
    public void Explode()
    {
        GameObject[] floats = GameObject.FindGameObjectsWithTag("float");
        foreach (GameObject g in floats)
        {
            Rigidbody rb = g.GetComponent<Rigidbody>();  
            rb.AddExplosionForce(300.0f, transform.position, 5.0f);

        }
        foreach (GameObject g in floats)
        {
            Destroy(g, .5f);
        }
        managerScript.greenExplosion.Play();
       // Debug.Log("Time to create the next instructions");

        hueScript.AddToHue();
        
        Destroy(this.gameObject);
    }
    public void Update()
    {
        float step = convergenceSpeed * Time.deltaTime;

        if (passed) {
            hueChange++;
            if (hueChange == 4) {
                hueChange = 0;
            }
            //GameObject plane = transform.GetChild(transform.childCount - 1).gameObject;
            Destroy(plane);
            gameObject.transform.DetachChildren();
           
            GameObject[] floats = GameObject.FindGameObjectsWithTag("float");
            foreach (GameObject g in floats) {
                Rigidbody rb = g.GetComponent<Rigidbody>();
                try
                {
                    rb.constraints = RigidbodyConstraints.None;
                    rb.isKinematic = false;
                }
                catch
                {

                }
                rb.gameObject.GetComponent<SphereCollider>().radius = .4f;
                Vector3 direction = transform.position - rb.gameObject.transform.position;
                rb.AddForce(direction.normalized * 20, ForceMode.Impulse);
                Invoke("Explode", 1f);
               
                
            }
            if (changeScore) {
                scoreScript.AddToScore();
                changeScore = false;
            }

            foreach (GameObject g in floats) {
                Destroy(g,3f);
            }
            

        }

        if (failed) {
            Destroy(this.gameObject);
            GameObject[] floats = GameObject.FindGameObjectsWithTag("float");
            foreach (GameObject g in floats)
            {
                Rigidbody rb = g.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                rb.AddExplosionForce(10.0f, managerScript.convergenceSpot.transform.position, 10.0f);

            }
             foreach (GameObject g in floats)
            {
               Destroy(g);
            }
            managerScript.redExplosion.Play();
            Destroy(this.gameObject);
            // lose a life
            livesScript.LoseLife();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScreenCollider")) {
            
            gameObject.transform.parent = null;
            
            // Run check the the classes
            for (int i = 0; i < pmanger.colors.Length; i++) {
                if (pmanger.colors[i] == colorChoice[i])
                {
                    winNum++;
                   // Debug.Log("working" + i + pmanger.colors[i] + colorChoice[i]);
                }
                //Debug.Log("working" + i + pmanger.colors[i] + colorChoice[i]);
            }
            if (winNum == 9)
            {
                passed = true;
                changeScore = true;
                //Debug.Log(" true");
            }
            else
            {
                failed = true;
               // Debug.Log(" false");
            }
        }
    }
    }

   
      

