using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataAfterTrackingFound : MonoBehaviour {

    LoadAllDatabase loadalldata;
    // Use this for initialization
    void Start () { 
        loadalldata = GameObject.FindGameObjectWithTag("GameController").GetComponent<LoadAllDatabase>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadDataTrackingFound(string name, Transform obj)
    {
        Debug.LogWarning("nhanaj biet va thuc thi tracking");
        loadalldata.FindListDatabaseAndLoadModel(name);
        gameObject.transform.parent = obj;
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
        gameObject.transform.localScale = new Vector3(0.007236839f, 0.007236839f, 0.007236839f);
    }
}
