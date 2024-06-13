using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 3f;
    public float fallSpeed = 5f;
    public bool testbool = false;
    public float jumpForce = 500F; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(
            transform.position.x + speed * Time.deltaTime,
            transform.position.y,
            transform.position.z);

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("jump pressed");

            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
        }
	}
}
