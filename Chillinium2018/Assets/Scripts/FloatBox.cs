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
    // float camRayLength = 10000;
    int CubeMask;
    void Awake()
    {
        cam = GameObject.Find("MainCam").GetComponent<Camera>();
        CubeMask = LayerMask.GetMask("Float");
        myRB = gameObject.GetComponent<Rigidbody>();
        myRB.AddForce(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
        myRB.AddTorque(new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));

    }


    void Update()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit CubeHit;

        if (Input.GetButtonDown("Fire1"))
        {

            if (Physics.Raycast(camRay, out CubeHit, Mathf.Infinity, CubeMask))
            {
                Drag(CubeHit.collider.gameObject);
            }

        }


    }
    private void Drag(GameObject curCube)
    {
        Vector3 dir = Vector3.Lerp(transform.position, cam.ScreenToViewportPoint(Input.mousePosition), 50f * Time.deltaTime);
        dir.z = 0f;
        curCube.transform.position = (dir);
        /*  Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
          RaycastHit CubeHit;

          if (Physics.Raycast(camRay, out CubeHit, Mathf.Infinity, CubeMask))
          {

                  Vector3 dir = Vector3.Lerp(transform.position, CubeHit.point, 50f * Time.deltaTime);
                  dir.z = 0f;
                 curCube.transform.position = (dir);

          }*/
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
