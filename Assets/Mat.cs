using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;


[ExecuteInEditMode]
public class Mat : MonoBehaviour {
    public GameObject go;
   // private Transform[] GaO;
    public bool thucthi;
	// Use this for initialization
	void Start () {
     //   GaO = go.transform.GetChild
        
    }


    void WithForLoop()
    {
        int children = go.transform.childCount;
        for (int i = 0; i < children; ++i)
            go.transform.GetChild(i).name = "4_" + go.transform.GetChild(i).name;
    }
    // Update is called once per frame
    void Update () {
		if(thucthi)
        {
            WithForLoop();
            thucthi = false;
        }
	}
}
