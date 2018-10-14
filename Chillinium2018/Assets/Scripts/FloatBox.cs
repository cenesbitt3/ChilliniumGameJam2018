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
    bool raised = false;
    public LayerMask tileMask;
    
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
        if (drag)
        {
            //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
        }
    /*    if (!stuck)
        {
            myRB.constraints = RigidbodyConstraints.None;
              myRB.constraints = RigidbodyConstraints.FreezePositionZ;
        }*/
        
    }
    void OnMouseDown()
    {
        
            stuck = false;
            screenPoint = cam.WorldToScreenPoint(transform.position);
            offset = transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //placement = false;
        if (!raised)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 60f), 2f * Time.deltaTime);
            raised = true;
        }
    }
    private void OnMouseUp()
    {
        drag = false;
        if (raised)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 60f), 2f * Time.deltaTime);
            raised = false;
        }
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = new Vector3(curPosition.x, curPosition.y, transform.position.z );
        RaycastHit hit;
             if (Physics.Raycast(transform.position, -curPosition, out hit, Mathf.Infinity, tileMask))
            {
                hit.collider.gameObject.GetComponent<placementObj>().hover = true;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
        }
        else
        {
            hit.collider.gameObject.GetComponent<placementObj>().hover = false;
        }
        // Vector3 direction =  curPosition-myRB.transform.position;
        //myRB.AddForce(direction.normalized *30f);
        //myRB.velocity = Vector3.zero;
        //  transform.position = Vector3.Lerp(transform.position, curPosition, 50f * Time.deltaTime);


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
        Debug.Log("Float box on trigger enter");
        if (other.CompareTag("placement"))
        {
            placementObj place = other.gameObject.GetComponent<placementObj>();
            Debug.Log("What is place filled" + place.filled);
            if (place.filled)
            {
                //return;
            }
            // if (place.filled) { 

            stuck = true;
                pObject = other.gameObject;
                stuckOnPlace(other.gameObject);
           // }
        }
    }
    
    
    void stuckOnPlace(GameObject pObj)
    {
        if (stuck&&!drag)
        {
            pObj.GetComponent<placementObj>().filled = true;
            myRB.constraints = RigidbodyConstraints.FreezePosition;
            gameObject.transform.position = pObj.transform.position;
        }
    }
    }

