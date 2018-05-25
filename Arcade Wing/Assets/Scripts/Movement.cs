using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //define how fast the player should accelerate forward
    public float forwardSpeed = 5f;
    //define how fast the player should turn
    public float turningSpeed = 0.5f;
    //determine maximum speed
    public float maximumVelocity = 100f;
    //determine what the player is
    public GameObject self;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //if the maximum speed has not been exceeded in on any axis of velocity
        if (self.GetComponent<Rigidbody>().velocity.z < maximumVelocity && self.GetComponent<Rigidbody>().velocity.x < maximumVelocity && self.GetComponent<Rigidbody>().velocity.y < maximumVelocity)
        {
            //add force to player forward
            self.GetComponent<Rigidbody>().AddForce(self.transform.forward * forwardSpeed, ForceMode.Impulse);
        }

        //if player presses button, they should be pointed downwards
        if (Input.GetKey(KeyCode.W))
        {
            self.transform.Rotate(Vector3.right * turningSpeed);
        }
        //if player presses button, they should be pointed upwards
        if (Input.GetKey(KeyCode.S))
        {
            self.transform.Rotate(Vector3.right * -turningSpeed);
        }
        //if player presses button, they should be pointed right
        if (Input.GetKey(KeyCode.E))
        {
            self.transform.Rotate(Vector3.up * turningSpeed);
        }
        //if player presses button, they should be pointed left
        if (Input.GetKey(KeyCode.Q))
        {
            self.transform.Rotate(Vector3.up * -turningSpeed);
        }
        //if player presses button, they should roll to the left
        if (Input.GetKey(KeyCode.A))
        {
            self.transform.Rotate(Vector3.forward * turningSpeed);
        }
        //if player presses button, they should roll to the right
        if (Input.GetKey(KeyCode.D))
        {
            self.transform.Rotate(Vector3.forward * -turningSpeed);
        }
    }
}
