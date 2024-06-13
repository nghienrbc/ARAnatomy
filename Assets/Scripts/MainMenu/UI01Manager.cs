using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI01Manager : MonoBehaviour {

    public GameObject Blur;
    public GameObject AboutApp;
    public GameObject AboutUS;
     
	// Use this for initialization
	void Start () {
        print("Start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // active aboutus
    public void AboutUSFunc()
    {
        Blur.SetActive(true);
        AboutUS.SetActive(true);
        Debug.Log("AboutUS");
    }

    public void AboutAppFunc()
    {
        Blur.SetActive(true);
        AboutApp.SetActive(true);
    }

    public void CloseFunc()
    {
        Blur.SetActive(false);
        AboutApp.SetActive(false);
        AboutUS.SetActive(false);
    }
    
}
