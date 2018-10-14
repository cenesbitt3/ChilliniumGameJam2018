using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBar : MonoBehaviour {

    Score score;
	void Start () {
        score = GameObject.Find("GameManger").GetComponent<Score>();
	}
	
	
	void Update () {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y +( score.score /2), transform.localScale.z );
	}
}
