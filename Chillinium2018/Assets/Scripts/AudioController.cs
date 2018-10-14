using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource mainSoung;
    public AudioSource introSong;

    public void Start()
    {
        introSong.Play();
    }

    public void EndIntroMusic() {
        introSong.Stop();
        mainSoung.Play();
    }

    public void MainMusic() {
        //source.Play();

    }
}
