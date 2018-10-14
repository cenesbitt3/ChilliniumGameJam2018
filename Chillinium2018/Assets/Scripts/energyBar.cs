using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBar : MonoBehaviour {

    public Slider power;
    public GameObject fill;
    Color newColor;

    public void Start()
    {
         newColor = fill.GetComponent<Image>().color;
    }

    public void ChangeBrightness() {
        Debug.Log("Call Change brightness");
        newColor = new Color(0f, 1f, 0.96f, 1f);
        Invoke("RevertBright", 1.5f);
    }

    public void RevertBright() {
        newColor = new Color(0f, 1f, 0.96f, 0.5f);
    }
}
