using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloatBox : MonoBehaviour
{
    GameObject center;
    public int color;
    public Renderer mat;
    public Material red;
    public Material green;
    public Material blue;
    Rigidbody myRB;
    float min = 20f;
    float max = 40f;
    public Camera cam;
    public  bool drag = false;
    private Vector3 screenPoint;
    private Vector3 offset;
    bool placement = false;
    // float camRayLength = 10000;
    int CubeMask;
    GameObject parent;
    bool dragged = false;
    bool col= false;
    bool stuck;
    public GameObject pObject;
    public float force;
    void Awake()
    {
        center = GameObject.Find("Center");
        mat = gameObject.GetComponent<Renderer>();
        cam = GameObject.Find("MainCam").GetComponent<Camera>();
        CubeMask = LayerMask.GetMask("Float");
        myRB = gameObject.GetComponent<Rigidbody>();
        myRB.AddForce(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
        myRB.AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));

    }


    private void Update()
    {
      switch (color)
        {
            case 0:
                mat.material = red;
                break;
            case 1:
                mat.material = blue;
                break;
            case 2:
                mat.material = green;
                break;
            default:
                break;

        }
        if (!stuck)
        {
            myRB.constraints = RigidbodyConstraints.None;
              myRB.constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }
    void OnMouseDown()
    {
        if (!col)
        {
            stuck = false;
            screenPoint = cam.WorldToScreenPoint(transform.position);
            offset = transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            placement = false;
        }
     //   transform.parent = null;
    //    myRB.constraints = RigidbodyConstraints.None;
     //   myRB.constraints = RigidbodyConstraints.FreezePositionZ;

    }
    private void OnMouseUp()
    {
        drag = false;

    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
        if (!col)
        {

            Vector3 direction =  curPosition-myRB.transform.position;
            myRB.AddForce(direction.normalized * Vector3.Distance(curPosition,gameObject.transform.position)*30f);
           // transform.position = Vector3.Lerp(transform.position, curPosition, 50f * Time.deltaTime);
        }
        drag = true;
        placement = false;
        if(stuck && Vector3.Distance(transform.position, pObject.transform.position) >1f)
        {
            stuck = false;
        }
       
    }

    private void OnCollsionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            col = true;
            
            transform.position = Vector3.Lerp(transform.position, center.transform.position, 500f * Time.deltaTime);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            col = false;
        }
        if (other.CompareTag("placement"))
        {
            placement = false;
            transform.parent = null;
        //    myRB.constraints = RigidbodyConstraints.None;
          //  myRB.constraints = RigidbodyConstraints.FreezePositionZ;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("placement"))
        {
            if (!drag) { 
           
                stuck = true;
                pObject = other.gameObject;
                stuckOnPlace(other.gameObject);
            }
        }
    }
    
    
    void stuckOnPlace(GameObject placementObj)
    {
        if (stuck)
        {
            myRB.constraints = RigidbodyConstraints.FreezePosition;
            gameObject.transform.position = placementObj.transform.position;
        }
    }
    }

