using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementObj : MonoBehaviour
{
    public Camera cam;
    public bool filled;
    public int color;
    public int placement;
    public GameObject occupyFloat;
    private Vector3 screenPoint;
    private Vector3 offset;
    bool stuck = true;
    bool hover = false;
    bool cando = false;
    

    private void Awake()
    {
        color = 4;
        cam = GameObject.Find("MainCam").GetComponent<Camera>();
    }
    private void Update()
    {
        
    }
    /*   private void Update()
       {
           screenPoint = cam.WorldToScreenPoint(transform.position);
           offset = transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
           Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
           Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
           if (filled)

           {
              if ( Vector3.Distance(transform.position, curPosition) >= 1f){
                   stuck = true;
               }
           }
       }*/

    private void OnTriggerEnter(Collider other)
    {
       
            if (other.CompareTag("float"))
            {
             //   Vector3 direction = -gameObject.transform.position + other.GetComponent<Rigidbody>().transform.position;
//other.GetComponent<Rigidbody>().AddForce(direction.normalized * 500f);
                  hover = true;
                   //other.transform.position = gameObject.transform.position;
                  
                filled = true;
                    color = other.gameObject.GetComponent<FloatBox>().color;

                

            }
            else
            {
                color = 4;
           //     other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
              //  other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("float"))
        {
            hover = false;
            color = 4;
            //filled = false;
        }
    }
    
}
