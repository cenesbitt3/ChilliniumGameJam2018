using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera curCamera;
    float camRayLength = 100f;
    int CubeMask;
    void Awake()
    {
        CubeMask = LayerMask.GetMask("Float");
    }


    void Update()
    {
        Ray camRay = curCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit TargetHit;

        if (Physics.Raycast(camRay, out TargetHit, camRayLength, CubeMask))
        {
        }
    }
}
