using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    //describes how fast the laser will accelerate over time
    public float acceleration = 10f;
    //describes the maximum speed that the laser will move
    public float maximumVelocity = 200f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if the laser isn't yet at maximum speed on any axis of movement  
        if (this.GetComponent<Rigidbody>().velocity.z < maximumVelocity && this.GetComponent<Rigidbody>().velocity.x < maximumVelocity && this.GetComponent<Rigidbody>().velocity.y < maximumVelocity)
        {
            //add acceleration to movement force
            this.GetComponent<Rigidbody>().AddForce(this.transform.forward * acceleration, ForceMode.Impulse);
        }
    }
}
