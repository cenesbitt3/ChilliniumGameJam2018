using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementObj : MonoBehaviour
{
    public Camera cam;
    public bool filled = false;
    public int color;
    public int placement;
    public GameObject occupyFloat;
    private Vector3 screenPoint;
    private Vector3 offset;
    bool stuck = true;
   public bool hover = false;
    bool cando = false;
    Collider col;
    public Material firstMat;
    public Material secondMat;
    public Material thirdMat;
    public bool selected = false;
     

    private void Awake()
    {
        color = 4;
        cam = GameObject.Find("MainCam").GetComponent<Camera>();
        col = GetComponent<Collider>();
    }
    private void Update()
    {
        
        if (selected)
        {
            gameObject.GetComponent<Renderer>().material = secondMat;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = firstMat;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (filled)
        {
            return;
        }


            if (other.CompareTag("float"))
            {
             //   Vector3 direction = -gameObject.transform.position + other.GetComponent<Rigidbody>().transform.position;
            //other.GetComponent<Rigidbody>().AddForce(direction.normalized * 500f);
                  
                   //other.transform.position = gameObject.transform.position;
                  
               // filled = true;
                   // color = other.gameObject.GetComponent<FloatBox>().color;

            }
            else
            {
               // color = 4;
           //     other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
              //  other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("float"))
        {
           
            //color = 4;
            filled = false;
        }
    }
    public void Hover()
    {
        gameObject.GetComponent<Renderer>().material = secondMat;
    }
    void HitByRay()
    {
        selected = true;
    }
    private void LateUpdate()
    {
        selected = false;
    }

}
