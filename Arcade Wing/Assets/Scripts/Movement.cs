using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float forwardSpeed = 5f;
    public float turningSpeed = 0.5f;
    public GameObject self;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        //if (self.GetComponent<Rigidbody>().velocity)
        //{
            self.GetComponent<Rigidbody>().AddForce(self.transform.forward * forwardSpeed, ForceMode.Impulse);
        //}

        if (Input.GetKey(KeyCode.W))
        {
            self.transform.Rotate(Vector3.right * turningSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            self.transform.Rotate(Vector3.right * -turningSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            self.transform.Rotate(Vector3.up * turningSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            self.transform.Rotate(Vector3.up * -turningSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            self.transform.Rotate(Vector3.forward * turningSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            self.transform.Rotate(Vector3.forward * -turningSpeed);
        }
    }
}
