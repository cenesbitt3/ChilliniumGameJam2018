using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloatBox : MonoBehaviour
{
    Rigidbody myRB;
    float min = 20f;
    float max = 40f;
    public Camera cam;
    bool drag = false;
    private Vector3 screenPoint;
    private Vector3 offset;
    bool placement = false;
    // float camRayLength = 10000;
    int CubeMask;
    GameObject parent;
    bool dragged = false;
    void Awake()
    {
        cam = GameObject.Find("MainCam").GetComponent<Camera>();
        CubeMask = LayerMask.GetMask("Float");
        myRB = gameObject.GetComponent<Rigidbody>();
        myRB.AddForce(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
        myRB.AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));

    }


    private void Update()
    {
       /* if (Input.GetButtonUp("Fire1"))
        {
            if (placement)
            {
                try
                {
                    if (placement)
                    {

                            gameObject.transform.position = parent.transform.position;
                            myRB.constraints = RigidbodyConstraints.FreezePosition;
                   
                    }
                }
                catch
                {

                }
               

            }
            else
            {
                transform.parent = null;
                myRB.constraints = RigidbodyConstraints.None;
                myRB.constraints = RigidbodyConstraints.FreezePositionZ;
            }
        }*/
    }
    void OnMouseDown()
    {
        screenPoint = cam.WorldToScreenPoint(transform.position);
        offset = transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        placement = false;
     //   transform.parent = null;
    //    myRB.constraints = RigidbodyConstraints.None;
     //   myRB.constraints = RigidbodyConstraints.FreezePositionZ;

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
        
       transform.position = Vector3.Lerp(transform.position, curPosition, 50f * Time.deltaTime);

        drag = true;
        placement = false;
       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("placement"))
        {
           // if (drag) { 
              //  gameObject.transform.position = other.transform.position;
            myRB.constraints = RigidbodyConstraints.FreezePosition;
                gameObject.transform.position = other.transform.position;
                placement = true;
       // }
            
        }
        else
        {
            placement = false;
            transform.parent = null;
            myRB.constraints = RigidbodyConstraints.None;
            myRB.constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("placement"))
        {
            placement = false;
            transform.parent = null;
            myRB.constraints = RigidbodyConstraints.None;
            myRB.constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }



    private void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.CompareTag("wall") || other.gameObject.CompareTag("float"))
        {
            Vector3 dir = other.contacts[0].point - transform.position;
            dir = -dir.normalized;
            myRB.AddForce(dir * 100f);
            //myRB.AddForce(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
            //myRB.AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
        }
    }
    private void OnMouseOver()
    {

    }
}
