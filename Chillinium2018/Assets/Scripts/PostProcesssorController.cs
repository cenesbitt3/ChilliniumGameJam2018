using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.Rendering;

public class PostProcesssorController : MonoBehaviour {
    public List<UnityEngine.PostProcessing.PostProcessingProfile> newProfile = new List<UnityEngine.PostProcessing.PostProcessingProfile>();
    public PostProcessingBehaviour behavior;

    public int hueChnage = -1;

    // Use this for initialization
    void Start () {
       // gameObject.GetComponent<PostProcessingBehaviour>().profile;
	}

    // Update is called once per frame
    public void AddToHue() {
        if (hueChnage == 4)
        {
            hueChnage = 0;
        }
        else {
            hueChnage++;
        }
        ChangeHueOnInt(hueChnage);
    }

    public void ChangeHueOnInt(int changeProfile) {
        Debug.Log("Thee hue int is " + changeProfile);
        switch (changeProfile) {
            case 0:
                behavior.profile = newProfile[changeProfile];
                break;
            case 1:
                behavior.profile = newProfile[changeProfile];
                break;
            case 2:
                behavior.profile = newProfile[changeProfile];
                break;
            case 3:
                behavior.profile = newProfile[changeProfile];
                break;
        }

    }

    public void ChangeHueProfileOne() {
        behavior.profile = newProfile[0];
    }

    public void ChangeHueProfileTwo()
    {
        behavior.profile = newProfile[1];
    }

    public void ChangeHueProfileThree()
    {
        behavior.profile = newProfile[2];
    }

    public void ChangeHueProfileFour()
    {
        behavior.profile = newProfile[3];
    }
}
