using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float acceleration = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * acceleration, ForceMode.Impulse);
    }
}
