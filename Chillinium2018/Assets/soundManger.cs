using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundManger : MonoBehaviour {
    public AudioClip mainSong;
    public AudioSource source;

   
    void Awake () {
        //source = gameObject.GetComponent<AudioSource>();
        source.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
