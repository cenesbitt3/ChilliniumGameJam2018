using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloatBox : MonoBehaviour {
    Rigidbody myRB;
    float min = 20f;
    float max = 40f;
    public Camera cam;
    bool drag= false;
    private Vector3 screenPoint;
    private Vector3 offset;
    // float camRayLength = 10000;
    int CubeMask;
    void Awake () {
        cam = GameObject.Find("MainCam").GetComponent<Camera>();
        CubeMask = LayerMask.GetMask("Float");
        myRB = gameObject.GetComponent<Rigidbody>();
        myRB.AddForce(new Vector3(Random.Range(min,max ), Random.Range(min, max), Random.Range(min, max)));
        myRB.AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));

    }
    
   
    void Update()
    {
       /* Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit CubeHit;
        
        if (Input.GetButton("Fire1"))
        {

            if (Physics.Raycast(camRay, out CubeHit, Mathf.Infinity, CubeMask))
            {
                drag = true;
                Drag(CubeHit.collider.gameObject);
            }

        }
        else
        {
            drag = false;
        }*/
        
        
    }
    
    private void Drag(GameObject curCube)
    {
      /*  if (drag)
        {
            Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit CubeHit;
            if (Physics.Raycast(camRay, out CubeHit, Mathf.Infinity))
            {
                Vector3 dir = Vector3.Lerp(transform.position, CubeHit.point, 50f * Time.deltaTime);
                dir.z = 0f;
                curCube.transform.position = (dir);
            }
        }
        /*  Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
          RaycastHit CubeHit;

          if (Physics.Raycast(camRay, out CubeHit, Mathf.Infinity, CubeMask))
          {

                  Vector3 dir = Vector3.Lerp(transform.position, CubeHit.point, 50f * Time.deltaTime);
                  dir.z = 0f;
                 curCube.transform.position = (dir);

          }*/
    }

    void OnMouseDown()
    {
        screenPoint = cam.WorldToScreenPoint(transform.position);
        offset = transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = Vector3.Lerp(transform.position, curPosition, 50f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        
        
        if (other.gameObject.CompareTag("wall")|| other.gameObject.CompareTag("float"))
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
