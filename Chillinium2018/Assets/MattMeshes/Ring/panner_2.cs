using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panner_2 : MonoBehaviour {

    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;
    	
	// Update is called once per frame
	void Update () {

        float OffsetY = Time.time * ScrollY;


        float OffsetX = Time.time * ScrollX;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}
